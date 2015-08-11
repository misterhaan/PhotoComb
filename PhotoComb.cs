using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace au.Applications.PhotoComb {
  public partial class PhotoComb : Form {
    [STAThread]
    static void Main() {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new PhotoComb());
    }

    PCSettings _settings;

    public PhotoComb() {
      InitializeComponent();
    }

    private void PhotoComb_Load(object sender, EventArgs e) {
      _settings = new PCSettings();
      _settings.Load();
      _fnbSource.FolderFullName = _settings.LastSourceDir;
      _fnbDest.FolderFullName = _settings.LastDestDir;
      if(_settings.Display.Size.Width != -42 && _settings.Display.Size.Height != -42)
        Size = _settings.Display.Size;
      if(_settings.Display.Location.X != -42 && _settings.Display.Location.Y != -42)
        Location = _settings.Display.Location;
      else
        CenterToScreen();
      WindowState = _settings.Display.WindowState;
      ResizeEnd += new System.EventHandler(PhotoComb_ResizeEnd);
      LocationChanged += new System.EventHandler(PhotoComb_LocationChanged);
    }

    private void _chkWriteDest_CheckedChanged(object sender, EventArgs e) {
      _chkKeepSource.Enabled = _chkWriteDest.Checked;
      _chkKeepSource.Checked &= _chkWriteDest.Checked;
    }

    private void _btnRun_Click(object sender, EventArgs e) {
      if(!CheckFields())
        return;
      try {
        Regex findNum = null;
        if(_txtOutputPattern.Text.Contains("%NUM%"))
          findNum = new Regex(_txtInputMask.Text, RegexOptions.IgnoreCase);
        string pattern = _txtOutputPattern.Text.Replace("%DATE%", "{0}").Replace("%TIME%", "{1}").Replace("%CAMERA%", "{2}").Replace("%NUM%", "{3}");
        try {
          DirectoryInfo dirSource = new DirectoryInfo(_fnbSource.FolderFullName);
          _lvResults.Items.Clear();
          foreach(FileInfo file in dirSource.GetFiles()) {
            string newName;
            try {
              FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.Read);
              bool streamOpen = true;
              try {
                BitmapSource bmp = BitmapFrame.Create(stream);
                try {
                  BitmapMetadata meta = (BitmapMetadata)bmp.Metadata;
                  try {
                    DateTime taken = DateTime.Parse(meta.DateTaken);
                    try {
                      string camera = string.IsNullOrEmpty(_txtCamera.Text) ? meta.CameraModel : _txtCamera.Text;
                      stream.Close();
                      streamOpen = false;
                      string number = "";
                      try {
                        if(findNum != null)
                          number = findNum.Match(file.Name).Groups[1].Value;
                        newName = string.Format(pattern, taken.ToString("yyyyMMdd"), taken.ToString("HHmmss"), camera, number);
                        _lvResults.Items.Add(new ListViewItem(new string[] { file.Name, newName }));
                        if(_chkWriteDest.Checked)
                          try {
                            if(_chkKeepSource.Checked)
                              file.CopyTo(Path.Combine(_fnbDest.FolderFullName, newName));
                            else
                              file.MoveTo(Path.Combine(_fnbDest.FolderFullName, newName));
                          } catch {
                            newName = "Unable to write " + newName;
                          }
                        continue;
                      } catch {
                        newName = "Unable to find image number in filename";
                      }
                    } catch {
                      newName = "Unable to read camera model";
                    }
                  } catch {
                    newName = "Unable to understand date taken";
                  }
                } catch {
                  newName = "Unable to read EXIF data";
                }
              } catch {
                newName = "Unable to read file as image";
              }
              if(streamOpen)
                stream.Close();
            } catch {
              newName = "Unable to open file";
            }
            _lvResults.Items.Add(new ListViewItem(new string[] { file.Name, newName }));
          }
        } catch {
          MessageBox.Show(this, Text, "Unable to open directory " + _fnbSource.FolderFullName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      } catch {
        MessageBox.Show(this, Text, "Invalid regular expression: " + _txtInputMask.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private bool CheckFields() {
      if(!_fnbSource.FolderExists) {
        FieldError(_fnbSource, "Select an existing folder that contains photos to rename.");
        return false;
      }
      if(_chkWriteDest.Checked && !_fnbDest.FolderExists)
        if(string.IsNullOrEmpty(_fnbDest.FolderFullName))
          _fnbDest.FolderFullName = _fnbSource.FolderFullName;
        else {
          FieldError(_fnbDest, "Select an existing folder to place renamed photos in, or leave blank to rename photos within the same folder.");
          return false;
        }
      // would validate that _txtInputMask is a valid regex, but no good way to do that.
      if(string.IsNullOrEmpty(_txtOutputPattern.Text)) {
        FieldError(_txtOutputPattern, "Enter an output filename pattern.  Macros %DATE%, %TIME%, %CAMERA%, and %NUM% will be replaced using image metadata.");
        return false;
      }
      if(_txtOutputPattern.Text.IndexOfAny(Path.GetInvalidPathChars()) >= 0) {
        FieldError(_txtOutputPattern, "Output filename pattern cannot contain any of the following characters:\n\n/ : * ? \" < > |");
        return false;
      }
      if(_txtOutputPattern.Text.Contains("%NUM%") && (string.IsNullOrEmpty(_txtInputMask.Text) || !Regex.Match(_txtInputMask.Text, @"\(.+\)").Success)) {
        FieldError(_txtInputMask, "When %NUM% is used, source filename pattern must contain a parenthesized section which is the source of %NUM%");
        return false;
      }
      if(_txtCamera.Text.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0) {
        FieldError(_txtCamera, "Camera name cannot contain any of the following characters:\n\n\\ / : * ? \" < > |");
        return false;
      }
      return true;
    }

    private void FieldError(Control control, string message) {
      MessageBox.Show(this, message, Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
      control.Focus();
    }

    private void PhotoComb_FormClosed(object sender, FormClosedEventArgs e) {
      _settings.LastSourceDir = _fnbSource.FolderFullName;
      _settings.LastDestDir = _fnbDest.FolderFullName;
      _settings.Display.WindowState = WindowState;
      _settings.Save();
    }

    private void PhotoComb_ResizeEnd(object sender, EventArgs e) {
      if(WindowState == FormWindowState.Normal) {
        _settings.Display.Size.Height = Height;
        _settings.Display.Size.Width = Width;
      }
    }

    private void PhotoComb_LocationChanged(object sender, EventArgs e) {
      if(WindowState == FormWindowState.Normal) {
        _settings.Display.Location.X = Left;
        _settings.Display.Location.Y = Top;
      }
    }
  }
}

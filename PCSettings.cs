using System;
using System.Diagnostics;
using System.IO;
using System.Xml;
using au.util.io;

namespace au.Applications.PhotoComb {
  public class PCSettings {
    private const string FILENAME = "PhotoComb.settings.xml";

    /// <summary>
    /// Full path to the settings file on disk.
    /// </summary>
    private string SettingsFilePath {
      get {
        if(string.IsNullOrEmpty(_settingsFilePath)) {
          _settingsFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), FILENAME);
        }
        return _settingsFilePath;
      }
    }
    private string _settingsFilePath = null;

    public string LastSourceDir = null;
    public string LastDestDir = null;

    public PCSettings() {
      LastSourceDir = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
      LastDestDir = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
    }

    /// <summary>
    /// Settings pertaining to the display.
    /// </summary>
    public DisplaySettings Display {
      get {
        if(_display == null)
          _display = new DisplaySettings();
        return _display;
      }
      private set { _display = value; }
    }
    private DisplaySettings _display;

    public bool Load() {
      if(File.Exists(SettingsFilePath)) {
        using(FileStream stream = File.Open(SettingsFilePath, FileMode.Open, FileAccess.Read, FileShare.Read)) {
          XmlDocument xml = new XmlDocument();
          xml.Load(stream);
          foreach(XmlNode node in xml.LastChild.ChildNodes)  // LastChild because the document's children are the xml declaration and then the root node
            try {
              switch(node.Name) {
                case "LastSourceDir":
                  try {
                    DirectoryInfo dir = new DirectoryInfo(node.InnerText);
                    while(!dir.Exists && dir.Parent != null)  // find nearest existing ancestor if possible
                      dir = dir.Parent;
                    if(dir.Exists)
                      LastSourceDir = dir.FullName;
                  } catch { }
                  break;
                case "LastDestDir":
                  try {
                    DirectoryInfo dir = new DirectoryInfo(node.InnerText);
                    if(dir.Exists)
                      LastDestDir = dir.FullName;
                  } catch { }
                  break;
                case "Display":
                  Display = new DisplaySettings(node);
                  break;
              }
            } catch(Exception e) {
              Trace.WriteLine("PCSettings.Load() ERROR reading node " + node.Name + " so it was skipped.  Details:\n" + e);
            }
        }
        return true;
      }
      return false;
    }

    public void Save() {
      XmlDocument xml = new XmlDocument();
      xml.AppendChild(xml.CreateXmlDeclaration("1.0", "UTF-8", null));
      XmlNode pc = xml.CreateElement("PhotoComb");
      xml.AppendChild(pc);
      if(!string.IsNullOrEmpty(LastSourceDir))
        pc.AddElement("LastSourceDir", LastSourceDir);
      if(!string.IsNullOrEmpty(LastDestDir))
        pc.AddElement("LastDestDir", LastDestDir);
      XmlNode disp = pc.AddElement("Display");
      Display.SaveTo(disp);
      using(FileStream stream = File.Open(SettingsFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
        xml.Save(stream);
    }
  }
}

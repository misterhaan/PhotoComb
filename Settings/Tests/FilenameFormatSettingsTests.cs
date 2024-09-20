using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace au.Applications.PhotoComb.Settings.Tests {
	[TestClass]
	public class FilenameFormatSettingsTests {
		private const string _sepNone = "";
		private const string _sepPeriod = ".";
		private const string _sepDash = "-";
		private const string _sepUnderscore = "_";
		private const string _badSepSlash = "/";
		private const string _badSepSpace = " ";
		private const string _badSepNull = null;
		private static readonly DateTime _taken = new(2016, 8, 4, 11, 22, 33);
		private const string _cameraName = "iphone";
		private const string _id = "1234";
		private const string _extension = "jpg";
		private const string _filenameNoneNoneDashNoExt = "20160804-112233-iphone-1234";
		private const string _filenameDashPeriodUnderscoreNoExt = "2016-08-04_11.22.33_iphone_1234";
		private const string _filenameNoneNoneDash = _filenameNoneNoneDashNoExt + "." + _extension;
		private const string _filenameDashPeriodUnderscore = _filenameDashPeriodUnderscoreNoExt + "." + _extension;


		[TestMethod]
		public void DateSeparator_DefaultNone() {
			FilenameFormatSettings settings = GetSettings();

			string separator = settings.DateSeparator;

			Assert.AreEqual(_sepNone, separator, $"{nameof(settings.DateSeparator)} should default to none.");
		}

		[DataTestMethod]
		[DataRow(_sepNone)]
		[DataRow(_sepPeriod)]
		[DataRow(_sepDash)]
		public void DateSeparator_Allowed_Accepted(string separator) {
			FilenameFormatSettings settings = GetSettings();

			settings.DateSeparator = separator;

			Assert.AreEqual(separator, settings.DateSeparator, $"{nameof(settings.DateSeparator)} should accept '{separator}' value.");
		}

		[DataTestMethod]
		[DataRow(_badSepSlash)]
		[DataRow(_badSepSpace)]
		[DataRow(_badSepNull)]
		public void DateSeparator_NotAllowed_Unchanged(string separator) {
			FilenameFormatSettings settings = GetSettings();
			string defaultSeparator = settings.DateSeparator;

			settings.DateSeparator = separator;

			Assert.AreEqual(defaultSeparator, settings.DateSeparator, $"{nameof(settings.DateSeparator)} should ignore sets to values like '{separator}' that are not allowed.");
		}

		[TestMethod]
		public void TimeSeparator_DefaultNone() {
			FilenameFormatSettings settings = GetSettings();

			string separator = settings.TimeSeparator;

			Assert.AreEqual(_sepNone, separator, $"{nameof(settings.TimeSeparator)} should default to none.");
		}

		[DataTestMethod]
		[DataRow(_sepNone)]
		[DataRow(_sepPeriod)]
		[DataRow(_sepDash)]
		public void TimeSeparator_Allowed_Accepted(string separator) {
			FilenameFormatSettings settings = GetSettings();

			settings.TimeSeparator = separator;

			Assert.AreEqual(separator, settings.TimeSeparator, $"{nameof(settings.TimeSeparator)} should accept '{separator}' value.");
		}

		[DataTestMethod]
		[DataRow(_badSepSlash)]
		[DataRow(_badSepSpace)]
		[DataRow(_badSepNull)]
		public void TimeSeparator_NotAllowed_Unchanged(string separator) {
			FilenameFormatSettings settings = GetSettings();
			string defaultSeparator = settings.TimeSeparator;

			settings.TimeSeparator = separator;

			Assert.AreEqual(defaultSeparator, settings.TimeSeparator, $"{nameof(settings.TimeSeparator)} should ignore sets to values like '{separator}' that are not allowed.");
		}

		[TestMethod]
		public void OverallSeparator_DefaultDash() {
			FilenameFormatSettings settings = GetSettings();

			string separator = settings.OverallSeparator;

			Assert.AreEqual(_sepDash, separator, $"{nameof(settings.OverallSeparator)} should default to dash.");
		}

		[DataTestMethod]
		[DataRow(_sepPeriod)]
		[DataRow(_sepDash)]
		[DataRow(_sepUnderscore)]
		public void OverallSeparator_Allowed_Accepted(string separator) {
			FilenameFormatSettings settings = GetSettings();

			settings.OverallSeparator = separator;

			Assert.AreEqual(separator, settings.OverallSeparator, $"{nameof(settings.OverallSeparator)} should accept '{separator}' value.");
		}

		[DataTestMethod]
		[DataRow(_badSepSlash)]
		[DataRow(_badSepSpace)]
		[DataRow(_badSepNull)]
		public void OverallSeparator_NotAllowed_Unchanged(string separator) {
			FilenameFormatSettings settings = GetSettings();
			string defaultSeparator = settings.OverallSeparator;

			settings.OverallSeparator = separator;

			Assert.AreEqual(defaultSeparator, settings.OverallSeparator, $"{nameof(settings.OverallSeparator)} should ignore sets to values like '{separator}' that are not allowed.");
		}

		[TestMethod]
		public void ExpandJpegExtension_DefaultFalse() {
			FilenameFormatSettings settings = GetSettings();

			bool expand = settings.ExpandJpegExtension;

			Assert.IsFalse(expand, $"{nameof(settings.ExpandJpegExtension)} should default to false.");
		}

		[DataTestMethod]
		[DataRow(_sepNone, _sepNone, _sepDash, _filenameNoneNoneDash)]
		[DataRow(_sepDash, _sepPeriod, _sepUnderscore, _filenameDashPeriodUnderscore)]
		public void FormatString_RespectsSeparators(string sepDate, string sepTime, string sepOverall, string expected) {
			FilenameFormatSettings settings = GetSettings(sepDate, sepTime, sepOverall);
			string id = sepOverall + _id;

			string formatted = string.Format(settings.FormatString, _taken, _cameraName, id, _extension);

			Assert.AreEqual(expected, formatted, $"{nameof(settings.FormatString)} did not produce expected filename {expected}.");
		}

		[DataTestMethod]
		[DataRow(_sepNone, _sepNone, _sepDash, _filenameNoneNoneDashNoExt)]
		[DataRow(_sepDash, _sepPeriod, _sepUnderscore, _filenameDashPeriodUnderscoreNoExt)]
		public void OutputFormat_RespectsSeparators(string sepDate, string sepTime, string sepOverall, string matchingFilename) {
			FilenameFormatSettings settings = GetSettings(sepDate, sepTime, sepOverall);

			bool isMatch = settings.OutputFormat.IsMatch(matchingFilename);

			Assert.IsTrue(isMatch, $"{nameof(settings.OutputFormat)} did not match filename {matchingFilename} when expected.");
		}

		private static FilenameFormatSettings GetSettings()
			=> new();

		private static FilenameFormatSettings GetSettings(string sepDate, string sepTime, string sepOverall)
			=> new() {
				DateSeparator = sepDate,
				TimeSeparator = sepTime,
				OverallSeparator = sepOverall
			};
	}
}

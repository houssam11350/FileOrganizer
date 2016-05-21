using System;
using System.Drawing;
using System.IO;
using Microsoft.Win32;

namespace FileOrganizer.CTRL
{
    /// <summary>
    /// A Class with a list of Common Static Methods...
    /// </summary>
    public class Common
    {
        
        public static StringFormat StringFormatAlignment (ContentAlignment textalign)
        {
            StringFormat sf = new StringFormat();
            switch (textalign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopRight:
                    sf.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleRight:
                    sf.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomRight:
                    sf.LineAlignment = StringAlignment.Far;
                    break;
            }
            switch (textalign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.BottomLeft:
                    sf.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopCenter:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.BottomCenter:
                    sf.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.BottomRight:
                    sf.Alignment = StringAlignment.Far;
                    break;
            }
            return sf;
        }

        /// <summary>
        /// Struct for the configuration settings for a editor...
        /// </summary>
        public struct EditorConfig
        {
            public bool ShowEOL;
            public bool ShowInvalidLines;
            public bool ShowSpaces;
            public bool ShowTabs;
            public bool ShowMatchingBracket;
            public bool ShowLineNumbers;
            public bool ShowVRuler;
            public bool ShowHRuler;
            public bool EnableCodeFolding;
            public bool ConvertTabs;
            public bool UseAntiAlias;
            public bool AllowCaretBeyondEOL;
            public bool HighlightCurrentLine;
            public bool AutoInsertBracket;
            public int TabIndent;
            public int VerticalRulerCol;
            public string IndentStyle;
            public string BracketMatchingStyle;
            public Font EditorFont;
        };
    }

    /*
        FileTypeRegistrar fileReg = new FileTypeRegistrar();
        { 
            fileReg.FullPath = Path_To_Executable; 
            fileReg.FileExtension = Extension_To_Register; 
            fileReg.ContentType = "application/" + Your_Description; 
            fileReg.IconIndex = Icon_Index_In_Application; 
            fileReg.IconPath = Path_To_Executable; 
            fileReg.ProperName = Name_Of_Executable; 
            fileReg.CreateType(); 
        } 
     */
    public class FileTypeRegistrar
    {

        #region "Properties & Property Variables"
        private string _ProperName;
        public string ProperName
        {
            get { return _ProperName; }
            set { _ProperName = value; }
        }

        private string _ContentType;
        public string ContentType
        {
            get { return _ContentType; }
            set { _ContentType = value; }
        }

        private string _FullPath;
        public string FullPath
        {
            get { return _FullPath; }
            set { _FullPath = value; }
        }

        private string _FileExtension;
        public string FileExtension
        {
            get { return _FileExtension; }
            set { _FileExtension = value.Replace(".", ""); }
        }

        private string _IconPath;
        public string IconPath
        {
            get { return _IconPath; }
            set { _IconPath = value; }
        }

        private int _IconIndex;
        public int IconIndex
        {
            get { return _IconIndex; }
            set { _IconIndex = value; }
        }
        #endregion

        #region "Public Methods"
        public void CreateType()
        {
            string fileName = Path.GetFileNameWithoutExtension(FullPath);
            string Ext = "." + FileExtension.ToLower();
            RegistryKey extKey = Registry.ClassesRoot.CreateSubKey(Ext);

            extKey.SetValue("", fileName);
            extKey.SetValue("Content Type", ContentType);
            extKey.Close();

            RegistryKey mainKey = Registry.ClassesRoot.CreateSubKey(fileName);
            RegistryKey defIconKey = mainKey.CreateSubKey("DefaultIcon");

            defIconKey.SetValue("", IconPath + ", " + IconIndex);
            defIconKey.Close();

            RegistryKey shellKey = mainKey.CreateSubKey("shell");
            RegistryKey OpenKey = shellKey.CreateSubKey("Open");
            RegistryKey cmdKey = OpenKey.CreateSubKey("command");

            cmdKey.SetValue("", "\"" + FullPath + " %1\"");
            cmdKey.Close();
            OpenKey.Close();
            shellKey.Close();
            mainKey.Close();

        }

        public void DeleteType()
        {
            string fileName = Path.GetFileNameWithoutExtension(FullPath);
            string Ext = "." + FileExtension.ToLower();

            Registry.ClassesRoot.DeleteSubKey(Ext);
            Registry.ClassesRoot.DeleteSubKey(fileName);

        }
        #endregion

    }
}

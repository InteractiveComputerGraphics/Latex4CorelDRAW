using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Latex4CorelDraw
{
    public class SettingsManager
    {
        static private SettingsManager m_current = null;

        private Settings m_settings;
        public Settings SettingsData
        {
            get { return m_settings; }
            set { m_settings = value; }
        }

        public SettingsManager()
        {
            m_settings = new Settings();
        }

        public static SettingsManager getCurrent()
        {
            if (m_current == null)
            {
                m_current = new SettingsManager();
                m_current.loadSettings();
            }
            return m_current;
        }

        // Serialization
        public void saveSettings()
        {
            try
            {
                string path = AddinUtilities.getAppDataLocation();
                XmlSerializer s = new XmlSerializer(typeof(Settings));
                TextWriter w = new StreamWriter(path + "\\settings.xml");
                s.Serialize(w, m_settings);
                w.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Deserialization
        public bool loadSettings()
        {
            bool result = true;
            try
            {
                string path = AddinUtilities.getAppDataLocation();
                XmlSerializer s = new XmlSerializer(typeof(Settings));
                TextReader r = new StreamReader(path + "\\settings.xml");
                m_settings = (Settings)s.Deserialize(r);
                r.Close();
            }
            catch 
            {
                // Set default values
                m_settings = new Settings();
                m_settings.textColor = "0,0,0";
                m_settings.fontSize = "12";
                m_settings.font = "Times Roman";
                m_settings.fontSeries = "Standard";
                m_settings.fontShape = "Standard";
                m_settings.insertAtCursor = true;
                result = false;
            }
            // If the miktex path was not found, try to find it in the registry
            if ((m_settings.miktexPath == null) || (m_settings.miktexPath == ""))
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\MiKTeX 2.8", false);
                if (key != null)
                {
                    m_settings.miktexPath = (string)key.GetValue("InstallLocation", "");
                    if (m_settings.miktexPath != "")
                    {
                        m_settings.miktexPath += "\\miktex\\bin";
                    }
                }
            }

//             // If the GS path was not found, try to find it in the registry
//             if ((m_settings.gsPath == null) || (m_settings.gsPath == ""))
//             {
//                 RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\GPL Ghostscript", false);
//                 if (key != null)
//                 {
//                     string [] versionKeys = key.GetSubKeyNames();
//                     if (versionKeys.Length > 0)
//                     {
//                         // Just take the first version 
//                         key = Registry.LocalMachine.OpenSubKey("Software\\GPL Ghostscript\\" + versionKeys[0], false);
//                         if (key != null)
//                         {
//                             m_settings.gsPath = Path.GetDirectoryName((string)key.GetValue("GS_DLL", ""));
//                         }
//                     }
//                 }
//             }
            return result;
        }
    }

    public class Settings
    {
        public string textColor; 
        public string fontSize;
        public string miktexPath;
        //public string gsPath;
        public string font;
        public string fontSeries;
        public string fontShape;
        public bool insertAtCursor;
    }
}
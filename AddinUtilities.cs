using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Latex4CorelDraw
{
    public class AddinUtilities
    {
        private static string m_procOutput = "";

        private static List<LatexFont> m_latexFonts = null;
        public static List<LatexFont> LatexFonts
        {
            get { return m_latexFonts; }
            set { m_latexFonts = value; }
        }

        private static List<LatexFontSeries> m_latexFontSeries = null;
        public static List<LatexFontSeries> LatexFontSeries
        {
            get { return m_latexFontSeries; }
            set { m_latexFontSeries = value; }
        }

        private static List<LatexFontShape> m_latexFontShapes = null;
        public static List<LatexFontShape> LatexFontShapes
        {
            get { return m_latexFontShapes; }
            set { m_latexFontShapes = value; }
        }

        public static void initFonts()
        {
            if (m_latexFonts == null)
            {
                m_latexFonts = new List<LatexFont>();
                m_latexFonts.Add(new LatexFont("Times Roman", "ptm"));
                m_latexFonts.Add(new LatexFont("Palatino", "ppl"));
                m_latexFonts.Add(new LatexFont("New Century Schoolbook", "pnc"));
                m_latexFonts.Add(new LatexFont("Bookman", "pbk"));
                m_latexFonts.Add(new LatexFont("Helvetica", "phv"));
                m_latexFonts.Add(new LatexFont("Avant Garde", "pag"));
                m_latexFonts.Add(new LatexFont("Courier", "pcr"));
            }
            if (m_latexFontSeries == null)
            {
                m_latexFontSeries = new List<LatexFontSeries>();
                m_latexFontSeries.Add(new LatexFontSeries("Standard", "m"));
                m_latexFontSeries.Add(new LatexFontSeries("Bold", "b"));
                m_latexFontSeries.Add(new LatexFontSeries("Bold extended", "bx"));
                m_latexFontSeries.Add(new LatexFontSeries("Semibold condensed", "sbc"));
                m_latexFontSeries.Add(new LatexFontSeries("Bold condensed", "bc"));
            }
            if (m_latexFontShapes == null)
            {
                m_latexFontShapes = new List<LatexFontShape>();
                m_latexFontShapes.Add(new LatexFontShape("Standard", "n"));
                m_latexFontShapes.Add(new LatexFontShape("Italic", "it"));
                m_latexFontShapes.Add(new LatexFontShape("Slanted", "sl"));
                m_latexFontShapes.Add(new LatexFontShape("Small caps", "sc"));
            }
        }

        public static LatexFont getLatexFont(string name)
        {
            foreach (LatexFont f in m_latexFonts)
            {
                if (f.fontName == name)
                    return f;
            }
            return null;
        }

        public static LatexFontSeries getLatexFontSeries(string name)
        {
            foreach (LatexFontSeries f in m_latexFontSeries)
            {
                if (f.fontSeries == name)
                    return f;
            }
            return null;
        }

        public static LatexFontShape getLatexFontShape(string name)
        {
            foreach (LatexFontShape f in m_latexFontShapes)
            {
                if (f.fontShape == name)
                    return f;
            }
            return null;
        }

        public static Color stringToColor(string colorText)
        {
            if (colorText == null)
            {
                return Color.Black;
            }
            string[] col = colorText.Split(',');
            float fred = Convert.ToSingle(col[0].Replace('.', ',')) * 255.0f;
            float fgreen = Convert.ToSingle(col[1].Replace('.', ',')) * 255.0f;
            float fblue = Convert.ToSingle(col[2].Replace('.', ',')) * 255.0f;
            return Color.FromArgb((int)fred, (int)fgreen, (int)fblue);
        }

        public static string colorToString(Color color)
        {
            if (color == null)
            {
                return "0,0,0";
            }
            double r = (double)color.R / 255.0;
            double g = (double)color.G / 255.0;
            double b = (double)color.B / 255.0;
            if (r > 1.0)
                r = 1.0;
            if (g > 1.0)
                g = 1.0;
            if (b > 1.0)
                b = 1.0;
            System.Globalization.CultureInfo ci;
            ci = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
            return r.ToString(ci) + "," +
                g.ToString(ci) + "," +
                b.ToString(ci);
        }


        public static string getVersionString()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return assembly.GetName().Version.ToString();
        }

        public static Version getVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return assembly.GetName().Version;
        }

        public static float[] getSystemDPI()
        {
            // Get system DPI
            float[] dpi = new float[2];

            Panel panel = new Panel();
            System.Drawing.Graphics g = panel.CreateGraphics();
            dpi[0] = g.DpiX;
            dpi[1] = g.DpiY;
            g.Dispose();
            return dpi;
        }

        public static bool getBool(string value, bool defaultValue)
        {
            bool result = defaultValue;
            try
            {
                result = Convert.ToBoolean(value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bool value exception: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public static int getInt(string value, int defaultValue)
        {
            int result = defaultValue;
            try
            {
                result = Convert.ToInt32(value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Int value exception: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public static float getFloat(string value, float defaultValue)
        {
            float result = defaultValue;
            try
            {
                result = Convert.ToSingle(value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Float value exception: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public static double getDouble(string value, double defaultValue)
        {
            double result = defaultValue;
            try
            {
                result = Convert.ToDouble(value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Double value exception: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public static string getAppDataLocation()
        {
            string appDataLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            appDataLocation = Path.Combine(appDataLocation, "Latex4CorelDraw");
            if (!Directory.Exists(appDataLocation))
            {
                Directory.CreateDirectory(appDataLocation);
            }
            return appDataLocation;
        }

        public static void copyLatexTemplate(string fileName, string templateText)
        {
            string templateFileName = AddinUtilities.getAppDataLocation() + "\\" + fileName;

            // Write resource template, if no file exists
            if (!File.Exists(templateFileName))
            {
                // Write template to app data location
                try
                {
                    StreamWriter sw;
                    sw = File.CreateText(templateFileName);
                    sw.Write(templateText);
                    sw.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void copyLanguageFile()
        {
            string fileName = AddinUtilities.getAppDataLocation() + "\\Language.xml";

            // Write resource template, if no file exists
            if (!File.Exists(fileName))
            {
                string text = Properties.Resources.Language;

                // Write template to app data location
                try
                {
                    StreamWriter sw;
                    sw = File.CreateText(fileName);
                    sw.Write(text);
                    sw.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static bool executeMikTex()
        {
            string output;
            SettingsManager mgr = SettingsManager.getCurrent();
            if (mgr.SettingsData.miktexPath == null)
            {
                MessageBox.Show("MiKTeX path not set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!startProcess("cmd.exe", "/c \"" + mgr.SettingsData.miktexPath + "\\latex.exe\" -interaction=nonstopmode teximport.tex", true, true, out output))
                return false;
            return true;
        }

        public static bool executeDviPng(LatexEquation equation, bool firstRun)
        {
            string appPath = AddinUtilities.getAppDataLocation();
            Directory.SetCurrentDirectory(appPath);

            // Check Dpi
            float[] systemDPI = AddinUtilities.getSystemDPI();

            float factor = equation.m_fontSize / 12.0f;
            float dpiValue = factor * systemDPI[0];   // Multiply chosen dpi with factor


            SettingsManager mgr = SettingsManager.getCurrent();         
            try
            {
                File.Delete(appPath + "\\teximport.png");
            }
            catch
            {
                MessageBox.Show("teximport.png could not be written. Permission denied.");
                return false;
            }

            string output = "";
            if (firstRun)
            {
                // In first run, run dvipng only once
                if (!startProcess("cmd.exe", "/c \"" + mgr.SettingsData.miktexPath + "\\dvipng.exe\" -T tight -bg Transparent --depth --noghostscript -D " + dpiValue.ToString() + " -o teximport.png teximport.dvi", true, false, out output))
                    return false;
            }
            else
            {
                if (!startProcess("cmd.exe", "/c \"" + mgr.SettingsData.miktexPath + "\\dvipng.exe\" -T tight -bg Transparent --depth --noghostscript -D " + dpiValue.ToString() + " -o teximport.png teximport.dvi", true, false, out output))
                    if (!startProcess("cmd.exe", "/c \"" + mgr.SettingsData.miktexPath + "\\dvipng.exe\" -T tight -bg Transparent --depth --noghostscript -D " + dpiValue.ToString() + " -o teximport.png teximport.dvi", true, true, out output))
                        return false;
            }
            return true;
        }

        public static bool executeDviPs(LatexEquation equation)
        {
            string appPath = AddinUtilities.getAppDataLocation();
            Directory.SetCurrentDirectory(appPath);


            SettingsManager mgr = SettingsManager.getCurrent();
            try
            {
                File.Delete(appPath + "\\teximport.ps");
            }
            catch
            {
                MessageBox.Show("teximport.ps could not be written. Permission denied.");
                return false;
            }

            string output = "";

            // run dvips
            startProcess("cmd.exe", "/c \"" + mgr.SettingsData.miktexPath + "\\dvips.exe\" teximport.dvi", true, false, out output);
  
            return true;
        }

        public static bool executePs2Pdf(LatexEquation equation)
        {
            string appPath = AddinUtilities.getAppDataLocation();
            Directory.SetCurrentDirectory(appPath);


            SettingsManager mgr = SettingsManager.getCurrent();
            try
            {
                File.Delete(appPath + "\\teximport.pdf");
            }
            catch
            {
                MessageBox.Show("teximport.pdf could not be written. Permission denied.");
                return false;
            }

            string output = "";

            // run ps2pdf
            startProcess("cmd.exe", "/c \"" + mgr.SettingsData.miktexPath + "\\ps2pdf.exe\" -dNoOutputFonts teximport.ps teximport.pdf", true, false, out output);

            return true;
        }

        public static bool createLatexPng(LatexEquation equation, bool firstRun)
        {
            // Check paths
            SettingsManager mgr = SettingsManager.getCurrent();            

            string appPath = AddinUtilities.getAppDataLocation();
            Directory.SetCurrentDirectory(appPath);
            LatexFileGenerator.writeTexFile(appPath + "\\teximport.tex", equation);
            if (!executeMikTex())
                return false;
            if (!executeDviPng(equation, firstRun))
                return false;

            return true;
        }

        public static bool createLatexPdf(LatexEquation equation)
        {
            // Check paths
            SettingsManager mgr = SettingsManager.getCurrent();

            string appPath = AddinUtilities.getAppDataLocation();
            Directory.SetCurrentDirectory(appPath);
            LatexFileGenerator.writeTexFile(appPath + "\\teximport.tex", equation);
            if (!executeMikTex())
                return false;
            if (!executeDviPs(equation))
                return false;
            if (!executePs2Pdf(equation))
                return false;

            return true;
        }



        public static bool startProcess(string cmd, string args, bool createNoWindow, bool errorDialog, out string output)
        {
            try
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = cmd;
                proc.StartInfo.Arguments = args;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.CreateNoWindow = createNoWindow;
                m_procOutput = "";
                proc.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(proc_OutputDataReceived);
                string errorStr = "";
                try
                {
                    proc.Start();
                    proc.BeginOutputReadLine();
                    errorStr = proc.StandardError.ReadToEnd();
                    proc.WaitForExit(1000);
                }
                catch
                {
                    output = m_procOutput;
                    if (errorDialog)
                    {
                        string label = "Error occurred while executing\n\n" + cmd + " " + args;
                        ErrorDialog dialog = new ErrorDialog(label, output + errorStr);
                        dialog.ShowDialog();
                    }
                    return false;
                }
                output = m_procOutput;
                if ((proc.ExitCode != 0) || (errorStr != ""))
                {
                    if (errorDialog)
                    {
                        string label = "Error occurred while executing\n\n" + cmd + " " + args;
                        ErrorDialog dialog = new ErrorDialog(label, output + errorStr);
                        dialog.ShowDialog();
                    }
                    //MessageBox.Show("Error occurred while executing\n\n" + cmd + "\n\nwith arguments\n\n" + args + "\n\nOutput:\n" + output + err);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                output = "";
                return false;
            }
            return true;
        }

        static void proc_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.Data))
            {
                m_procOutput = m_procOutput + e.Data + "\n";
            }
        }

        public static void changeOptions()
        {
            SettingsManager mgr = SettingsManager.getCurrent();
            OptionsDialog dialog = new OptionsDialog();
            dialog.MiktexPath = mgr.SettingsData.miktexPath;
            if (dialog.ShowDialog() == DialogResult.OK)
            {                
                mgr.SettingsData.miktexPath = dialog.MiktexPath;
                mgr.saveSettings();
            }
        }
    }
}

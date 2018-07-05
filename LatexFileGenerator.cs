﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Latex4CorelDraw
{
    public class LatexEquation
    {
        public string m_code;
        public float m_fontSize;
        public string m_color;
        public LatexFont m_font;
        public LatexFontSeries m_fontSeries;
        public LatexFontShape m_fontShape;
        public LatexMathFont m_mathFont;
        public int m_textShapeId;
        public int m_imageWidth;
        public int m_imageHeight;
        public Corel.Interop.VGCore.Shape m_shape;

        public LatexEquation(string latexCode, float fontSize, string textColor, LatexFont font, LatexFontSeries fontSeries, LatexFontShape fontShape, LatexMathFont mathFont)
        {
            m_code = latexCode;
            m_fontSize = fontSize;
            m_color = textColor;
            m_font = font;
            m_fontSeries = fontSeries;
            m_fontShape = fontShape;
            m_mathFont = mathFont;
            m_imageWidth = 0;
            m_imageHeight = 0;
            m_textShapeId = -1;
        }

        public LatexEquation(string latexCode, float fontSize, string textColor, LatexFont font, LatexFontSeries fontSeries, LatexFontShape fontShape, LatexMathFont mathFont, int textShapeId)
        {
            m_code = latexCode;
            m_fontSize = fontSize;
            m_color = textColor;
            m_font = font;
            m_fontSeries = fontSeries;
            m_fontShape = fontShape;
            m_mathFont = mathFont;
            m_imageWidth = 0;
            m_imageHeight = 0;
            m_textShapeId = textShapeId;
        }
    }

    public class LatexFileGenerator
    {
        public static void writeTexFile(string fileName, LatexEquation equation)
        {
            string templateText = "";
            string templateFileName = AddinUtilities.getAppDataLocation() + "\\LatexTemplate.txt";

            // Use resource template, if no file exists
            if (!File.Exists(templateFileName))
            {
                templateText = Properties.Resources.LatexTemplate;
            }
            else  // Otherwise use the file
            {
                // Read template
                try
                {

                    SettingsManager mgr = SettingsManager.getCurrent();

                    StreamReader sr;
                    sr = File.OpenText(templateFileName);
                    templateText = sr.ReadToEnd();
                    sr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            string addonPackages = "";
            if (equation.m_mathFont.fontName != "Standard")
            {
                addonPackages += "\\usepackage{" + equation.m_mathFont.latexPackageName + "}\n";
            }
            templateText = templateText.Replace("${addonPackages}", addonPackages);

            string content = "";
            content += "\\definecolor{txtcolor}{rgb}{" + equation.m_color + "}\n";
            content += "\\color{txtcolor}\n";
            content += "\\changefont{" + equation.m_font.latexFontName + "}{" +
                                         equation.m_fontSeries.latexFontSeries + "}{" +
                                         equation.m_fontShape.latexFontShape + "}{" +
                                         equation.m_fontSize.ToString() + "}{" +
                                         ((equation.m_fontSize * 1.2)).ToString(System.Globalization.CultureInfo.InvariantCulture) + "}\n";
            content += equation.m_code;

            templateText = templateText.Replace("${Content}", content);

            // Write Latex file
            try
            {
                StreamWriter sw = File.CreateText(fileName);
                sw.Write(templateText);
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

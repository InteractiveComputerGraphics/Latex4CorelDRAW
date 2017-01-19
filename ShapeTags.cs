using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Corel.Interop.VGCore;

namespace Latex4CorelDraw
{
    public class ShapeTags
    {
        public static void addTag(Shape shape, string name, string value)
        {
            if (!DockerUI.Current.CorelApp.ActiveDocument.DataFields.IsPresent(name))
            {
                DataField df = DockerUI.Current.CorelApp.ActiveDocument.DataFields.Add(name, "\""+ value + "\"");
                shape.ObjectData.Add(df);
            }
            shape.ObjectData[name].Value = value;
        }
        public static void setShapeTags(LatexEquation equation)
        {
            addTag(equation.m_shape, "LatexCode", equation.m_code.Replace("\r\n", "\\r\\n"));
            addTag(equation.m_shape, "LatexFontSize", equation.m_fontSize.ToString());
            addTag(equation.m_shape, "LatexTextColor", equation.m_color);
            addTag(equation.m_shape, "LatexFont", equation.m_font.fontName);
            addTag(equation.m_shape, "LatexFontSeries", equation.m_fontSeries.fontSeries);
            addTag(equation.m_shape, "LatexFontShape", equation.m_fontShape.fontShape);
            addTag(equation.m_shape, "LatexTextShapeId", equation.m_textShapeId.ToString());
            addTag(equation.m_shape, "Latex4CorelDrawVersion", AddinUtilities.getVersionString());
        }

        public static LatexEquation getLatexEquation(Shape s)
        {
            if ((getLatexCode(s) != null) && (getLatexCode(s) != ""))
            {
                return new LatexEquation(
                        getLatexCode(s),
                        getLatexFontSize(s),
                        getLatexTextColor(s),
                        getLatexFont(s),
                        getLatexFontSeries(s),
                        getLatexFontShape(s));
            }
            return null;
        }

        public static string getLatexCode(Shape s)
        {
            string str = (string) s.ObjectData["LatexCode"].Value;
            if (str != null)
                str = str.Replace("\\r\\n", "\r\n");
            return str;
        }

        public static string getLatexTextColor(Shape s)
        {
            return (string) s.ObjectData["LatexTextColor"].Value;
        }

        public static LatexFont getLatexFont(Shape s)
        {
            string str = (string)s.ObjectData["LatexFont"].Value;
            if (str != null)
                return AddinUtilities.getLatexFont(str);
            return null;
        }

        public static LatexFontShape getLatexFontShape(Shape s)
        {
            string str = (string)s.ObjectData["LatexFontShape"].Value;
            if (str != null)
                return AddinUtilities.getLatexFontShape(str);
            return null;
        }

        public static LatexFontSeries getLatexFontSeries(Shape s)
        {
            string str = (string)s.ObjectData["LatexFontSeries"].Value;
            if (str != null)
                return AddinUtilities.getLatexFontSeries(str);
            return null;
        }

        public static string getLatexAddinVersion(Shape s)
        {
            return (string)s.ObjectData["LatexAddinVersion"].Value;
        }

        public static float getLatexFontSize(Shape s)
        {
            string str = (string)s.ObjectData["LatexFontSize"].Value.ToString();
            float fontSizeValue = 12.0f;
            if (str != null)
                fontSizeValue = AddinUtilities.getFloat(str, 12.0f);
            return fontSizeValue;
        }

        public static int getLatexTextShapeId(Shape s)
        {
            string str = (string)s.ObjectData["LatexTextShapeId"].Value.ToString();
            int value = -1;
            if ((str != null) && (str != ""))
                value = AddinUtilities.getInt(str, -1);
            return value;
        }
    }
          
}

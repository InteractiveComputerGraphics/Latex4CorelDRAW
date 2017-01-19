using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.PowerPoint;

namespace LatexAddin
{
    public class SelectionHandler
    {
        Microsoft.Office.Interop.PowerPoint.EApplication_WindowSelectionChangeEventHandler m_eventHandler = null;
        Microsoft.Office.Interop.PowerPoint.Shape m_oldShape = null;

        public void init()
        {
            m_eventHandler = new Microsoft.Office.Interop.PowerPoint.EApplication_WindowSelectionChangeEventHandler(Application_WindowSelectionChange);
            ThisAddIn.Current.Application.WindowSelectionChange += m_eventHandler;
        }

        public void cleanup()
        {
            ThisAddIn.Current.Application.WindowSelectionChange -= m_eventHandler;
        }

        void Application_WindowSelectionChange(Microsoft.Office.Interop.PowerPoint.Selection Sel)
        {
            Microsoft.Office.Interop.PowerPoint.Shape shape = null;
            bool run = false;
            if (Sel.Type == Microsoft.Office.Interop.PowerPoint.PpSelectionType.ppSelectionNone)
            {
                run = true;
            }
            else //if (Sel.Type == Microsoft.Office.Interop.PowerPoint.PpSelectionType.ppSelectionShapes)
            {
                if (Sel.ShapeRange.Count > 0)
                {
                    shape = Sel.ShapeRange[1];

                    // Check if inline equation shape was selected
                    selectTextShape(shape);
                    if (shape != m_oldShape)
                    {
                        //removeInlineEquationShapes(shape);
                        run = true;

                    }
                }
            }
            if (run)
            {                
                if (m_oldShape != null)
                {
                    InlineLatex.createInlineEquations(m_oldShape);
                }
                m_oldShape = shape;
            }
        }

        /** Select the text shape if an inline equation shape was selected.
         */
        private void selectTextShape(Shape eqShape)
        {
            // Check if inline equation shape was selected
            int textShapeId = ShapeTags.getLatexTextShapeId(eqShape);
            if (textShapeId != -1)
            {
                // Select corresponding text shape
                Slide slide = (Slide)eqShape.Parent;
                foreach (Shape s in slide.Shapes)
                {
                    if (s.Id == textShapeId)
                    {
                        s.Select(Microsoft.Office.Core.MsoTriState.msoTrue);
                    }
                }
                
            }
        }

        private void removeInlineEquationShapes(Shape shape)
        {
            Slide slide = (Slide)shape.Parent;
            List<Shape> toDelete = new List<Shape>();
            foreach (Shape s in slide.Shapes)
            {
                if (ShapeTags.getLatexTextShapeId(s) == shape.Id)
                {
                    toDelete.Add(s);
                }
            }
            foreach (Shape s in toDelete)
            {
                s.Delete();
            }
        }   
    }
}

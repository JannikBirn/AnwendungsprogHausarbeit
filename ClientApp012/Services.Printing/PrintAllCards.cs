using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Printing;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Media;

namespace De.HsFlensburg.ClientApp012.Services.Printing
{
    public class PrintAllCards
    {

        public void PrintCards(object cards)
        {
            // Create a PrintDialog  
            PrintDialog printDlg = new PrintDialog();
            //string myCards = cards.ToString(); //Ausgabe: System.Windows.Controls.DataGrid Items.Count:2
            // Create a FlowDocument dynamically. 
            //FlowDocument doc = new FlowDocument(new Paragraph(new Run(myCards)));
            //doc.Name = "FlowDoc";
            //FormatFlowDocument(doc);
            // Create IDocumentPaginatorSource from FlowDocument 
            //IDocumentPaginatorSource idpSource = doc;

            Nullable<Boolean> print = printDlg.ShowDialog();
            if (print == true)
            {
                // Call PrintDocument method to send document to printer 
                //printDlg.PrintVisual(cards , "Grid Printing.");
            }
        }

        private FlowDocument FormatFlowDocument(FlowDocument doc)
        {
            //Create Section
            Section sec = new Section();
            //Create first Paragraph
            Paragraph p1 = new Paragraph();
            //Create and add FontStyle. Got from DataGrid
            
            p1.FontStyle = doc.FontStyle;
            p1.FontSize = doc.FontSize;
            p1.FontFamily = doc.FontFamily;

            //Add Paragraph to Section
            sec.Blocks.Add(p1);
            //Add Section to FlowDocument
            doc.Blocks.Add(sec);

            return doc;
        }
    }
}

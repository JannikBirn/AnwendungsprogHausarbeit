using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Printing;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows; // needed for RoutedEventArgs

namespace De.HsFlensburg.ClientApp012.Services.Printing
{
    public class PrintTest
    {
        //This method is printing a single line directly
        public void PrintTestWindow()   //Die Parameter sind im Beispiel hier nicht drin
        {
            //Create a PrintDialog
            PrintDialog printDlg = new PrintDialog();

            // Create a FlowDocument dynamically
            FlowDocument doc = new FlowDocument(new Paragraph(new Run("This is a Test print. Please enjoy.")));
            doc.Name = "FlowDoc";
            FormatFlowDocument(doc);
            // Create IDocumentPaginatorSource from FlowDocument
            IDocumentPaginatorSource idpSource = doc;

            // Call PrintDocument method to send document to printer
            printDlg.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing");
        }

        //This is showing the default Windows Printing Preview before printing
        public void TestPrintWithDialogue() //with selecting printer
        {
            // Parts of  Code from https://www.c-sharpcorner.com/uploadfile/mahesh/printing-in-wpf/

            // Create a PrintDialog  
            PrintDialog printDlg = new PrintDialog();

            // Create a FlowDocument dynamically. 
            FlowDocument doc = new FlowDocument(new Paragraph(new Run("Here is some Text. Please enjoy.")));
            doc.Name = "FlowDoc";
            FormatFlowDocument(doc);
            // Create IDocumentPaginatorSource from FlowDocument 
            IDocumentPaginatorSource idpSource = doc;

            Nullable<Boolean> print = printDlg.ShowDialog();
            if (print == true)
            {
                // Call PrintDocument method to send document to printer 
                printDlg.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing.");
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

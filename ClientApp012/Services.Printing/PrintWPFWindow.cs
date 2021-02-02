using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Windows;

namespace De.HsFlensburg.ClientApp012.Services.Printing
{
   public class PrintWPFWindow
    {
        public void PrintSimpleTextButton_Click(object sender, RoutedEventArgs e)
        {
            // Parts of  Code from https://www.c-sharpcorner.com/uploadfile/mahesh/printing-in-wpf/

            // Create a PrintDialog  
            PrintDialog printDlg = new PrintDialog();
            //printDlg.PrintVisual(this, "Grid Printing");

            ////CreateFlowDocument(sender);  wie wird das DataGrid übergeben?

            //// Create a FlowDocument dynamically. 
            //FlowDocument doc = new FlowDocument(new Paragraph(new Run("Here is some Text.")));
            //doc.Name = "FlowDoc";

            //// Create IDocumentPaginatorSource from FlowDocument 
            //IDocumentPaginatorSource idpSource = doc;

            //// Call PrintDocument method to send document to printer 
            //printDlg.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing");

            //Nullable<Boolean> print = printDlg.ShowDialog();
            //if (print == true)
            //{
            //    // Call PrintDocument method to send document to printer 
            //    printDlg.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing.");
            //}

        }
        private FlowDocument CreateFlowDocument(DataGrid dataGrid)
        {
            //Create FlowDocument
            FlowDocument doc = new FlowDocument();
            //Create Section
            Section sec = new Section();
            //Create first Paragraph
            Paragraph p1 = new Paragraph();
            //Create and add FontStyle. Got from DataGrid
            p1.FontStyle = dataGrid.FontStyle;
            p1.FontSize = dataGrid.FontSize;
            p1.FontFamily = dataGrid.FontFamily;

            //Add Paragraph to Section
            sec.Blocks.Add(p1);
            //Add Section to FlowDocument
            doc.Blocks.Add(sec);

            return doc;
        }
    }
}

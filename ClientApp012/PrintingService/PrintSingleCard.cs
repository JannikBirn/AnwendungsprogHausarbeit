using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Printing;
using System.Windows.Controls;
using System.Windows.Documents;

namespace PrintingService
{
    class PrintSingleCard
    {
        public PrintSingleCard()
        {

        }
        public void TestPrint()
        {
            //Create a PrintDialog
            PrintDialog printDlg = new PrintDialog();

            // Create a FlowDocument dynamically
            FlowDocument doc = new FlowDocument(new Paragraph(new Run("Here is some Text.")));
            doc.Name = "FlowDoc";

            // Create IDocumentPaginatorSource from FlowDocument
            IDocumentPaginatorSource idpSource = doc;

            // Call PrintDocument method to send document to printer
            printDlg.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing");
        }
        public void TestPrintWithDialogue()
        {
            // Parts of  Code from https://www.c-sharpcorner.com/uploadfile/mahesh/printing-in-wpf/

            // Create a PrintDialog  
            PrintDialog printDlg = new PrintDialog();

            // Create a FlowDocument dynamically. 
            FlowDocument doc = new FlowDocument(new Paragraph(new Run("Here is some Text.")));
            doc.Name = "FlowDoc";

            // Create IDocumentPaginatorSource from FlowDocument 
            IDocumentPaginatorSource idpSource = doc;

            // Call PrintDocument method to send document to printer 
            printDlg.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing");

            Nullable<Boolean> print = printDlg.ShowDialog();
            if (print == true)
            {
                // Call PrintDocument method to send document to printer 
                printDlg.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing.");
            }
        }

    }
}

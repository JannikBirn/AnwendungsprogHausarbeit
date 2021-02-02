﻿using System;
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
        public void PrintTestWindow()   //Die Parameter sind im Beispiel hier nicht drin
        {
            //Create a PrintDialog
            PrintDialog printDlg = new PrintDialog();

            // Create a FlowDocument dynamically
            FlowDocument doc = new FlowDocument(new Paragraph(new Run("This is a Test print. Please enjoy.")));
            doc.Name = "FlowDoc";

            // Create IDocumentPaginatorSource from FlowDocument
            IDocumentPaginatorSource idpSource = doc;

            // Call PrintDocument method to send document to printer
            printDlg.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing");
        }
        public void TestPrintWithDialogue() //with selecting printer
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

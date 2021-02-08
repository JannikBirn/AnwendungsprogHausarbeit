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
using System.IO;
using System.Windows.Xps.Packaging;
using System.Windows.Xps;
using System.Windows.Documents.Serialization;

namespace De.HsFlensburg.ClientApp012.Services.Printing
{
    public class PrintAllCards
    {
        public bool Landscape { get; set; }
        public int ScalingFactor { get; set; }
        public int NumberOfPages { get; set; }
        private DataGrid dataGrid;
        public PrintAllCards()
        {
        }

        public void PrintCards(object cards)
        {
            // Create a PrintDialog  
            PrintDialog printDlg = new PrintDialog();
            //casts the object cards to DataGrid
            DataGrid dg = cards as DataGrid;
            //if passed object is a DataGrid, this will return TRUE
            if (dg != null)
            {
                Nullable<Boolean> print = printDlg.ShowDialog();
                if (print == true)
                {
                    // Call PrintDocument method to send document to printer 
                    printDlg.PrintVisual(dg, "Grid Printing.");
                }
            }
        }

        public void PrintCardsDirectly(object cards)
        {
            // Create a PrintDialog  
            PrintDialog printDlg = new PrintDialog();
            //casts the object cards to DataGrid
            dataGrid = cards as DataGrid;
            //sets Preview
           // PrintWindowPreview(dataGrid);
            //prepares a formatted page
            FormatPrintDialoge(printDlg);

            if (dataGrid != null)
            {
                    // Call PrintDocument method to send document to printer 
                    printDlg.PrintVisual(dataGrid, "Grid Printing.");
            }
        }

        public FixedDocumentSequence PrintWindowPreview(DataGrid dg)
        {
            //sets a filename an checks, if this name is already taken. in this case, the old file would be deleted
            // .xps is an alternative file type to pdf
            string printFileName = "print_preview.xps";
            if (File.Exists(printFileName) == true)
            {
                File.Delete(printFileName);
            }

            //create xps doc
            XpsDocument doc = new XpsDocument(printFileName, FileAccess.ReadWrite);
            XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(doc);

            //creates new Document wich is shown in PrintWindow.xaml
            SerializerWriterCollator output_Doument = writer.CreateVisualsCollator();
            output_Doument.BeginBatchWrite();
            output_Doument.Write(dg);
            output_Doument.EndBatchWrite();

            //open it
            FixedDocumentSequence preview = doc.GetFixedDocumentSequence();
            //cards.Print_Window print_Window = new cards.Print_Window(preview);

            //close 
            doc.Close();
            writer = null;
            output_Doument = null;
            doc = null;

            return preview;

        }

        private PrintDialog FormatPrintDialoge(PrintDialog pd)
        {
            //Gets Default Printer
            pd.PrintQueue = LocalPrintServer.GetDefaultPrintQueue();
            pd.PrintTicket = pd.PrintQueue.DefaultPrintTicket;
            if (Landscape)
            {
                pd.PrintTicket.PageOrientation = PageOrientation.Landscape;
            }
            else
            {
                pd.PrintTicket.PageOrientation = PageOrientation.Portrait;
            }
            //defines scaling
            pd.PrintTicket.PageScalingFactor = ScalingFactor;
            //defines page size
            pd.PrintTicket.PageMediaSize = new PageMediaSize(PageMediaSizeName.ISOA4);
            //defines number of pages
            pd.PrintTicket.PagesPerSheet = NumberOfPages;
            pd.PrintTicket.PageBorderless = PageBorderless.None;
            return pd;
        }



    }
}

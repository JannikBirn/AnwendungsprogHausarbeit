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
        public bool landscape;
        public int scalingFactor;
        public int numberOfPages;
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
            DataGrid dg = cards as DataGrid;
            FormatPrintDialoge(printDlg);

        }

        private PrintDialog FormatPrintDialoge(PrintDialog pd)
        {
            //Gets Default Printer
            pd.PrintQueue = LocalPrintServer.GetDefaultPrintQueue();
            pd.PrintTicket = pd.PrintQueue.DefaultPrintTicket;
            if (landscape)
            {
                pd.PrintTicket.PageOrientation = PageOrientation.Landscape;
            }
            else
            {
                pd.PrintTicket.PageOrientation = PageOrientation.Portrait;
            }
            //defines scaling
            pd.PrintTicket.PageScalingFactor = scalingFactor;
            //defines page size
            pd.PrintTicket.PageMediaSize = new PageMediaSize(PageMediaSizeName.ISOA4);
            //defines number of pages
            pd.PrintTicket.PagesPerSheet = numberOfPages;
            pd.PrintTicket.PageBorderless = PageBorderless.Borderless;
            return pd;
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

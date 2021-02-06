using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Printing;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Windows;

namespace De.HsFlensburg.ClientApp012.Services.Printing
{
   public class PrintWPFWindow
    {
        public void PrintWindow(object window) //how to pass a Visual here????
        {

            // Create a PrintDialog  
            PrintDialog printDlg = new PrintDialog();
            Window w1 = new Window();
            w1 = window as Window;
            Nullable<Boolean> print = printDlg.ShowDialog();
            if (window != null)
            {
                if (print == true)
                {
                    // Call PrintDocument method to send document to printer 
                    printDlg.PrintVisual(w1, "User Control Printing");
                }
            }
        }
       
    }
}

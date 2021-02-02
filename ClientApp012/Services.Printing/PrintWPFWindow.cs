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
        public void PrintWindow(object param) //how to pass a Visual here????
        {
            // Parts of  Code from https://www.c-sharpcorner.com/uploadfile/mahesh/printing-in-wpf/

            // Create a PrintDialog  
            PrintDialog printDlg = new PrintDialog();
            UserControl uc = new UserControl();
            Nullable<Boolean> print = printDlg.ShowDialog();
            if (print == true)
            {
                // Call PrintDocument method to send document to printer 
                printDlg.PrintVisual(uc, "User Control Printing");
            }
        }
       
    }
}

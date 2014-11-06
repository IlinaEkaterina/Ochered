using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для screen.xaml
    /// </summary>
    public partial class screen : Window
    {
        ServiceReference1.Service1Client cli = new ServiceReference1.Service1Client();
        List <enrollee> asas = new List <enrollee> ();
        int ggg=0;
        public screen()
        {
            InitializeComponent();           
            
        }

        void cli_turn_cashCompleted(object sender, ServiceReference1.turn_cashCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (e.Result.ToString().Substring(0, 1) == "1")
                {
                    lblOKNO1.Tag = e.Result.ToString().Substring(1, 1); ggg++;
                }
                if (e.Result.ToString().Substring(0, 1) == "2")
                {
                    lblOKNO2.Tag = e.Result.ToString().Substring(1, 1); ggg++;
                }
                if (e.Result.ToString().Substring(0, 1) == "3")
                {
                    lblOKNO3.Tag = e.Result.ToString().Substring(1, 1); ggg++;
                }
                if (e.Result.ToString().Substring(0, 1) == "4")
                {
                    lblOKNO4.Tag = e.Result.ToString().Substring(1, 1); ggg++;
                }
                if (e.Result.ToString().Substring(0, 1) == "5")
                {
                    lblOKNO5.Tag = e.Result.ToString().Substring(1, 1); ggg++;
                }
                if (e.Result.ToString().Substring(0, 1) == "6")
                {
                    lblOKNO6.Tag = e.Result.ToString().Substring(1, 1); ggg++;
                }

                if (ggg == 6)
                {
                    cli.vozvr_spisCompleted += cli_vozvr_spisCompleted;
                    cli.vozvr_spisAsync();
                }
            }
            

        }

        private void scr_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }


        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            cli.turn_cashCompleted += cli_turn_cashCompleted;
            cli.turn_cashAsync(1);
            cli.turn_cashAsync(2);
            cli.turn_cashAsync(3);
            cli.turn_cashAsync(4);
            cli.turn_cashAsync(5);
            cli.turn_cashAsync(6);
            

       }

       

        void cli_vozvr_spisCompleted(object sender, ServiceReference1.vozvr_spisCompletedEventArgs e)
        {

                if (e.Error == null)
                {
                    int jj = 0;
                    bool q =false;
                    while(q==false)
                    {
                        if (lblOKNO1.IsVisible == true && e.Result[jj].Substring(0, 1) == lblOKNO1.Tag.ToString()) { txt1.Content = e.Result[jj].Substring(1); e.Result[jj] = e.Result[jj].Substring(1); q = true; }
                        if (e.Result.Count() == jj + 1) { q = true; }
                        jj++;
                    }

                    jj = 0;
                    q = false;
                    while (q == false)
                    {
                        if (lblOKNO2.IsVisible == true && e.Result[jj].Substring(0, 1) == lblOKNO2.Tag.ToString()) { txt2.Content = e.Result[jj].Substring(1); e.Result[jj] = e.Result[jj].Substring(1); q = true; }
                        if (e.Result.Count() == jj + 1) { q = true; }
                        jj++;
                    }

                    jj = 0;
                    q = false;
                    while (q == false)
                    {
                        if (lblOKNO3.IsVisible == true && e.Result[jj].Substring(0, 1) == lblOKNO3.Tag.ToString()) { txt3.Content = e.Result[jj].Substring(1); e.Result[jj] = e.Result[jj].Substring(1); q = true; }
                        if (e.Result.Count() == jj + 1) { q = true; }
                        jj++;
                    }

                    jj = 0;
                    q = false;
                    while (q == false)
                    {
                        if (lblOKNO4.IsVisible == true && e.Result[jj].Substring(0, 1) == lblOKNO4.Tag.ToString()) { txt4.Content = e.Result[jj].Substring(1); e.Result[jj] = e.Result[jj].Substring(1); q = true; }
                        if (e.Result.Count() == jj + 1) { q = true; }
                        jj++;
                    }

                    jj = 0;
                    q = false;
                    while (q == false)
                    {
                        if (lblOKNO5.IsVisible == true && e.Result[jj].Substring(0, 1) == lblOKNO5.Tag.ToString()) { txt5.Content = e.Result[jj].Substring(1); e.Result[jj] = e.Result[jj].Substring(1); q = true; }
                        if (e.Result.Count() == jj + 1) { q = true; }
                        jj++;
                    }

                    jj = 0;
                    q = false;
                    while (q == false)
                    {
                        if (lblOKNO6.IsVisible == true && e.Result[jj].Substring(0, 1) == lblOKNO6.Tag.ToString()) { txt6.Content = e.Result[jj].Substring(1); e.Result[jj] = e.Result[jj].Substring(1); q = true; }
                        if (e.Result.Count() == jj + 1) { q = true; }
                        jj++;
                    }

                    jj = 0;
                    q = false;
                    while (q == false)
                    {
                        if (e.Result[jj].Substring(0, 1) == "1" || e.Result[jj].Substring(0, 1) == "2" || e.Result[jj].Substring(0, 1) == "3") { lv1.Items.Add(e.Result[jj].Substring(1)); }
                        if (e.Result.Count() == jj + 1) { q = true; }
                        jj++;
                    }
                    
                    //if (lblOKNO1.IsVisible == true) { txt1.Content = e.Result[jj]; jj++; }
                    //if (lblOKNO2.IsVisible == true) { txt2.Content = e.Result[jj]; jj++; }
                    //if (lblOKNO3.IsVisible == true) { txt3.Content = e.Result[jj]; jj++; }
                    //if (lblOKNO4.IsVisible == true) { txt4.Content = e.Result[jj]; jj++; }
                    //if (lblOKNO5.IsVisible == true) { txt5.Content = e.Result[jj]; jj++; }
                    //if (lblOKNO6.IsVisible == true) { txt6.Content = e.Result[jj]; jj++; }

                    //      for (int i = jj; i < e.Result.Count(); i++)
                    //       {
                    //            lv1.Items.Add(e.Result[i]);
                    //       }
                       
                }
            
        }
        
    }
}
        
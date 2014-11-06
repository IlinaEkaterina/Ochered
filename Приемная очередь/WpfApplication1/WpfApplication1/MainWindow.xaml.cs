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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public class enrollee
    {
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public string date_coming { get; set; }
        public string time_coming { get; set; }
        public string date_call { get; set; }
        public string time_call { get; set; }
        public string status { get; set; }
        public string turn { get; set; }
        public string cash { get; set; }
    }

    public partial class MainWindow : Window
    {
        ServiceReference1.Service1Client cli = new ServiceReference1.Service1Client();
        public MainWindow()
        {
            InitializeComponent();
            cli.vivodCompleted += cli_vivod;
            cli.vivodAsync();      
        }

        void cli_vivod(object sender, ServiceReference1.vivodCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                grMain.ItemsSource = e.Result;
            }
        }

        private void Dob_abit_Click(object sender, RoutedEventArgs e)
        {
            dobav dd = new dobav();
            dd.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cli.vivodCompleted += cli_vivod;
            cli.vivodAsync();      
        }

        private void nacpr_Click_1(object sender, RoutedEventArgs e)
        {
            cash cc = new cash();
            cc.Show();
            this.Close();
        }

        private void sc_Click_1(object sender, RoutedEventArgs e)
        {
            

            cli.actcashCompleted += cli_actcashCompleted;
            cli.actcashAsync();
            
            
        }

        //void cli_turn_cashCompleted(object sender, ServiceReference1.turn_cashCompletedEventArgs e)
        //{
        //    if (e.Error == null)
        //    {
        //        if (e.Result.ToString().Substring(0, 1) == "1")
        //        {
        //            l1.Tag = e.Result.ToString().Substring(1, 1);
        //        }
        //        if (e.Result.ToString().Substring(0, 1) == "2")
        //        {
        //            l2.Tag = e.Result.ToString().Substring(1, 1);
        //        }
        //        if (e.Result.ToString().Substring(0, 1) == "3")
        //        {
        //            l3.Tag = e.Result.ToString().Substring(1, 1);
        //        }
        //        if (e.Result.ToString().Substring(0, 1) == "4")
        //        {
        //            l4.Tag = e.Result.ToString().Substring(1, 1);
        //        }
        //        if (e.Result.ToString().Substring(0, 1) == "5")
        //        {
        //            l5.Tag = e.Result.ToString().Substring(1, 1);
        //        }
        //        if (e.Result.ToString().Substring(0, 1) == "6")
        //        {
        //            l6.Tag = e.Result.ToString().Substring(1, 1);
        //        }
        //    }
        //}

        void cli_actcashCompleted(object sender, ServiceReference1.actcashCompletedEventArgs e)
        {
            screen cc = new screen();
            if (e.Error == null)
            {
                if (e.Result[0] == false)
                {
                    cc.oc1.Visibility = Visibility.Hidden;
                    cc.lblOKNO1.Visibility = Visibility.Hidden;
                }
                if (e.Result[1] == false)
                {
                    cc.oc2.Visibility = Visibility.Hidden;
                    cc.lblOKNO2.Visibility = Visibility.Hidden;
                }
                if (e.Result[2] == false)
                {
                    cc.oc3.Visibility = Visibility.Hidden;
                    cc.lblOKNO3.Visibility = Visibility.Hidden;
                }
                if (e.Result[3] == false)
                {
                    cc.oc4.Visibility = Visibility.Hidden;
                    cc.lblOKNO4.Visibility = Visibility.Hidden;
                }
                if (e.Result[4] == false)
                {
                    cc.oc5.Visibility = Visibility.Hidden;
                    cc.lblOKNO5.Visibility = Visibility.Hidden;
                }
                if (e.Result[5] == false)
                {
                    cc.oc6.Visibility = Visibility.Hidden;
                    cc.lblOKNO6.Visibility = Visibility.Hidden;
                }

              
                cc.Show();
                this.Close();
            }
        }
     
    }
}

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
    /// Логика взаимодействия для start_work.xaml
    /// </summary>
    public partial class start_work : Window
    {
        ServiceReference1.Service1Client cli = new ServiceReference1.Service1Client();
        public start_work()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            start_work cc = new start_work();
            cc.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            start_work cc = new start_work();
            cc.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            cli.cash_offCompleted += cli_cash_offCompleted;
            cli.cash_offAsync(Convert.ToInt32(this.Tag));
            cash cc = new cash();
            cc.Show();
            this.Close();
        }

        void cli_cash_offCompleted(object sender, ServiceReference1.cash_offCompletedEventArgs e)
        {
            if (e.Error == null) { if (e.Result == true) { MessageBox.Show("Прием окончен!"); } }
        }

        private void scr_Click_1(object sender, RoutedEventArgs e)
        {
            cash mw = new cash();
            mw.Show();
            this.Close();
        }
    }
}

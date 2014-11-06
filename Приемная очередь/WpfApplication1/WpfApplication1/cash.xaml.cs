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
    /// Логика взаимодействия для cash.xaml
    /// </summary>
    public partial class cash : Window
    {
        ServiceReference1.Service1Client cli = new ServiceReference1.Service1Client();
        public cash()
        {
               InitializeComponent();
               oche.Items.Add("Очная");
               oche.Items.Add("Заочная");
               oche.Items.Add("Льготно-очная");
            
               och.Items.Add("1 окно");
               och.Items.Add("2 окно");
               och.Items.Add("3 окно");
               och.Items.Add("4 окно");
               och.Items.Add("5 окно");
               och.Items.Add("6 окно");
         }

        private void Exit_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow cc = new MainWindow();
            cc.Show();
            this.Close();
        }

        private void occ_Click(object sender, RoutedEventArgs e)
        {
            cli.actactCompleted += cli_actactCompleted;
            cli.actactAsync(Convert.ToInt32(och.SelectedValue.ToString().Substring(0,1)), oche.SelectedIndex + 1);
           
            start_work cc = new start_work();
            cc.Tag = och.SelectedValue.ToString().Substring(0, 1);
            cc.Show();
            this.Close();
        }

        void cli_actactCompleted(object sender, ServiceReference1.actactCompletedEventArgs e)
        {
            if (e.Error == null) { if (e.Result == true) { MessageBox.Show("Окно добавлено!"); } }
        }

    }
}

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
    /// Логика взаимодействия для dobav.xaml
    /// </summary>
    public partial class dobav : Window
    {
        ServiceReference1.Service1Client cli = new ServiceReference1.Service1Client();
        public dobav()
        {
            InitializeComponent();
            oche.Items.Add("Очная");
            oche.Items.Add("Заочная");
            oche.Items.Add("Льготно-очная");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        void cli_dobav1Completed(object sender, ServiceReference1.dobav1CompletedEventArgs e)
        {
            if (e.Error == null)
            {
                this.Tag = e.ToString();
            }
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string ds;
            string ts;

            Random rnd = new Random();
            int casa = rnd.Next(1, 6);

            DateTime vv = DateTime.Now;
            ds = vv.ToString("dd.MM.yyyy");
            ts = vv.ToString(@"hh\:mm");
            cli.dobav1Completed +=cli_dobav1Completed;
            cli.dobav1Async  ( "8", casa.ToString() , ds, ts );
            podtver mw = new podtver();
            mw.turn.Tag = (oche.SelectedIndex+1).ToString();
            mw.f.Content = ff.Text;
            mw.i.Content = ii.Text;
            mw.ot.Content = otot.Text;
            mw.och.Content = oche.Text;
            mw.nc.Content = casa.ToString();
            mw.idtp.Tag = "8";
            mw.ds.Tag = ds;
            mw.ts.Tag = ts;
            mw.Show();
            this.Close();
        }
    }
}

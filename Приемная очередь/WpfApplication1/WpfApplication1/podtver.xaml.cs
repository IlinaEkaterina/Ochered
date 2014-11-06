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
    /// Логика взаимодействия для podtver.xaml
    /// </summary>
    public partial class podtver : Window
    {
        ServiceReference1.Service1Client cli = new ServiceReference1.Service1Client();
        public podtver()
        {
            InitializeComponent();
            
            DateTime vv = DateTime.Now;
            dt1.Content = vv;
            dt2.Content = vv;

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            DateTime data =Convert.ToDateTime( dt1.Content);
            DateTime data2 = Convert.ToDateTime(dt2.Content);
            cli.dobavCompleted += cli_dobavCompleted;
            cli.dobavAsync(f.Content.ToString(), i.Content.ToString(), ot.Content.ToString(), data.ToString("dd.MM.yyyy"), data.ToString(@"hh\:mm"), data2.ToString("dd.MM.yyyy"), data2.ToString(@"hh\:mm"), idt.Content.ToString(), turn.Tag.ToString());
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        void cli_dobavCompleted(object sender, ServiceReference1.dobavCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                nc.Tag = e.ToString();
            }
        }
       void cli_getidstatusCompleted(object sender, ServiceReference1.getidstatusCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                idt.Content = e.Result;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            dobav mw = new dobav();
            mw.Show();
            this.Close();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            cli.getidstatusCompleted += cli_getidstatusCompleted;
            cli.getidstatusAsync(idtp.Tag.ToString(), nc.Content.ToString(), ds.Tag.ToString(), ts.Tag.ToString());
        }
       
    }
}

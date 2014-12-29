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

namespace Folder_Sync
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            Create_task cr = new Create_task();
            this.IsEnabled = false;
            this.Close() ;
            cr.Show();
        }

        private void bt2_Click(object sender, RoutedEventArgs e)
        {
            Manage_task cr = new Manage_task();
            this.IsEnabled = false;
            this.Close();
            cr.Show();
        }

        private void bt3_Click(object sender, RoutedEventArgs e)
        {
            Run_task cr = new Run_task();
            this.IsEnabled = false;
            this.Close();
            cr.Show();
        }
    }
}

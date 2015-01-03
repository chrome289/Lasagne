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
using Ookii.Dialogs.Wpf;
using System.IO;
using System.Data.SQLite;

namespace Folder_Sync
{
    
    public partial class Create_task : Window
    {
        public Create_task()
        {
            InitializeComponent();
            tb1.Text = "";
            tb2.Text = "";
            SQLiteConnection dbConnection;
            dbConnection = new SQLiteConnection("Data Source=Database.sqlite;Version=3;");
            dbConnection.Open();

            string sql = "create table if not exists sync (name varchar(100),First_Folder varchar(500), Second_Folder varchar(500))";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
            dbConnection.Close();
        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            VistaFolderBrowserDialog vd = new VistaFolderBrowserDialog();
            vd.RootFolder = System.Environment.SpecialFolder.Desktop;
            vd.ShowDialog();
            tb1.Text = vd.SelectedPath;
        }

        private void bt2_Click(object sender, RoutedEventArgs e)
        {
            VistaFolderBrowserDialog vd = new VistaFolderBrowserDialog();
            vd.ShowDialog();
            tb2.Text = vd.SelectedPath;
        }

        private void bt3_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection dbConnection; 
            dbConnection = new SQLiteConnection("Data Source=Database.sqlite;Version=3;");
            dbConnection.Open();
            string sql = "insert into sync (Name,First_Folder,Second_Folder) values ('"+tb3.Text+"','"+tb1.Text+"','"+tb2.Text+"')";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
            dbConnection.Close();
            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            String sMessageBoxText = "Sync task saved";
            string sCaption = "Folder Sync";
            MessageBoxButton btnMessageBox = MessageBoxButton.OK;
            MessageBoxImage icnMessageBox = MessageBoxImage.Information;
            MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Main m = new Main();
            m.Show();
        }


        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {

        }

    }
}

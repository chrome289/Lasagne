using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Data.SQLite;
using System.Data;


namespace Folder_Sync
{
    public partial class Run_job : Window
    {
        public static string sdir = "", ddir = "";

        public Run_job()
        {
            InitializeComponent();
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=Database.sqlite;Version=3;");
            m_dbConnection.Open();
            string sql = "select * from sync";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader=command.ExecuteReader();
            while (reader.Read())
            {
                //MessageBox.Show(reader.GetString(1));
                datagrid1.Items.Add(new { Col1 = reader.GetInt16(0), Col2 = reader.GetString(1), Col3 = reader.GetString(2), Col4 = reader.GetString(3) });
            }
            m_dbConnection.Close();
        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            string f=datagrid1.SelectedItem.ToString();
            string [] split=f.Split(",".ToCharArray(),4);
            string name, first_folder, second_folder;
            name = split[1].Substring(8);
            first_folder = split[2].Substring(8);
            second_folder = split[3].Substring(8);
            second_folder=second_folder.TrimEnd(" }".ToCharArray());
            sdir = first_folder;
            ddir = second_folder;
            ProcessDirectory(sdir);
            String sMessageBoxText = "Sync job completed";
            string sCaption = "Folder Sync";
            MessageBoxButton btnMessageBox = MessageBoxButton.OK;
            MessageBoxImage icnMessageBox = MessageBoxImage.Information;
            MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
        }

        public void ProcessDirectory(string targetDirectory)
        {
            try
            {
                // Process the list of files found in the directory. 
                string[] fileEntries = Directory.GetFiles(targetDirectory);
                foreach (string fileName in fileEntries)
                { ProcessFile(fileName); }

                // Recurse into subdirectories of this directory. 
                string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
                foreach (string subdirectory in subdirectoryEntries)
                    ProcessDirectory(subdirectory);
            }
            catch(System.IO.DirectoryNotFoundException e)
            {
                String sMessageBoxText = "Source Folder not present";
                string sCaption = "Folder Sync";
                MessageBoxButton btnMessageBox = MessageBoxButton.OK;
                MessageBoxImage icnMessageBox = MessageBoxImage.Error;
                MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
            }
            
        }

        public void ProcessFile(string path)
        {
            //create final path
            int sdir_len = sdir.Length, path_len = path.Length;
            //MessageBox.Show(sdir + "  " + sdir_len.ToString() + "     " + ddir + "        " + path + "        " + path_len.ToString());
            string cut_sdir_path = path.Substring(sdir_len, (path_len - sdir_len));
            string final_path = ddir + cut_sdir_path;


            try
            {
                if (File.Exists(final_path) == true)
                {
                    FileInfo f1 = new FileInfo(final_path);
                    FileInfo f2 = new FileInfo(path);
                    if (f1.Length != f2.Length)
                    {
                        Directory.CreateDirectory(System.IO.Path.GetDirectoryName(final_path));
                        File.Copy(path, final_path, true);
                        // tb1.Text = tb1.Text + "\n" + final_path;
                    }
                }
                else
                {
                    Directory.CreateDirectory(System.IO.Path.GetDirectoryName(final_path));
                    File.Copy(path, final_path, true);
                    //tb1.Text = tb1.Text + "\n" + final_path;
                }
            }
            catch (UnauthorizedAccessException un)
            {

            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Main m = new Main();
            m.Show();
        }
    }
}

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

namespace Folder_Sync
{
    public partial class Run_job : Window
    {
        public static string sdir = "C2004:\\SD card\\Funny Pictures", ddir = "c:\\test";

        public Run_job()
        {
            InitializeComponent();
        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            ProcessDirectory(sdir);
        }

        public void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory. 
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            // Recurse into subdirectories of this directory. 
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);

        }

        public void ProcessFile(string path)
        {
            //create final path
            int sdir_len = sdir.Length, path_len = path.Length;
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

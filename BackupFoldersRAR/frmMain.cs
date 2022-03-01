using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BackupFoldersRAR
{
    public partial class frmMain : Form
    {
        string rar = "";

        public frmMain()
        {
            InitializeComponent();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "WinRAR|rar.exe";
            ofd.InitialDirectory = Environment.ExpandEnvironmentVariables("%ProgramW6432%") + "\\winrar\\";
            if (ofd.ShowDialog() == DialogResult.OK)
                rar = ofd.FileName;
        }

        private void TxtLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (TxtLocation.Text != "")
                fbd.SelectedPath = TxtLocation.Text;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                TxtLocation.Text = fbd.SelectedPath;
                LstFiles.Items.Clear();

                string[] files = Directory.GetFiles(TxtLocation.Text);
                string[] folders = Directory.GetDirectories(TxtLocation.Text);

                foreach (string a in folders)
                    LstFiles.Items.Add(a);
                foreach (string a in files)
                    LstFiles.Items.Add(a);
            }
        }

        private void LstFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
                for (int a = 0; a < LstFiles.Items.Count; a++)
                    LstFiles.SetItemChecked(a, true);
        }

        private void BtnBackup_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "WinRAR file|.rar";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Random r = new Random();
                int b = r.Next();
                StreamWriter w = new StreamWriter("temp"+b+".txt", false, Encoding.UTF8);
                foreach (string a in LstFiles.CheckedItems)
                    w.WriteLine(a);
                w.Close();
                w = new StreamWriter("log.log", true);
                w.WriteLine(rar + " a " + sfd.FileName + " @temp" + b + ".txt");
                w.Close();

                Process p = new Process();
                p.StartInfo.FileName = rar;
                p.StartInfo.Arguments = "a -m0 -ep1 \"" + sfd.FileName + "\" @temp" + b + ".txt";
                p.Start();
                p.WaitForExit();

                File.Delete("temp" + b + ".txt");
            }
        }

        private void BtnRestore_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> b = new Dictionary<string, string>();
            foreach (string a in LstFiles.CheckedItems)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "Select folder for:" + a;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    b.Add(a, fbd.SelectedPath);
                }
            }
            foreach (KeyValuePair<string, string> a in b)
            {
                StreamWriter w = new StreamWriter("log.log", true);
                w.WriteLine(rar + " x -kb \"" + a.Key + "\" \"" + a.Value + "\"");
                w.Close();

                Process p = new Process();
                p.StartInfo.FileName = rar;
                p.StartInfo.Arguments = "x -kb \"" + a.Key + "\" \"" + a.Value + "\"";
                p.Start();
                p.WaitForExit();
            }
        }

        public static void CmdRun()
        {
            int exit = 9;
            string path = @"C:\Users";
            while (exit != 0)
            {
                Console.WriteLine("1. Type in folder");
                Console.WriteLine("2. List files in current folder");
                Console.WriteLine("3. Backup current folder to this flash drive");
                Console.WriteLine("0. Exit");
                Console.WriteLine();
                Console.WriteLine("Current folder: " + path);
                try { exit = Convert.ToInt32(Console.ReadLine()); }
                catch { exit = 9; /*nothing*/ }

                switch (exit)
                {
                    case 1:
                        Console.WriteLine("Enter in folder: ");
                        path = Console.ReadLine();
                        while (!Directory.Exists(path))
                        {
                            Console.WriteLine("Enter in folder: ");
                            path = Console.ReadLine();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Listing files in " + path);
                        foreach (string a in Directory.GetFiles(path))
                        {
                            FileInfo fi = new FileInfo(a);
                            Console.WriteLine(a + "\t" + fi.Length*1024*1024 + "MB");
                        }
                        break;
                    case 3:
                        Console.WriteLine("You sure you want to backup " + path + "? y/n");
                        string y = Console.ReadLine().Trim();
                        if (y == "y")
                        {
                            Console.WriteLine("Backing up folder to flash drive " + path);
                            string rar = AppDomain.CurrentDomain.BaseDirectory + "rar.exe";
                            Console.WriteLine("rar: " + rar);

                            Random r = new Random();
                            int b = r.Next();
                            StreamWriter w = new StreamWriter("temp" + b + ".txt", false, Encoding.UTF8);
                            foreach (string a in Directory.GetFiles(path))
                                w.WriteLine(a);
                            w.Close();
                            w = new StreamWriter("log.log", true);
                            w.WriteLine(rar + " a -m0 -ep1 Backups\\" + Path.GetFileName(path.TrimEnd(Path.DirectorySeparatorChar)) + ".rar" + " @temp" + b + ".txt");
                            w.Close();

                            Process p = new Process();
                            p.StartInfo.FileName = rar;
                            p.StartInfo.Arguments = "a -m0 -ep1 \"Backups\\" + Path.GetFileName(path.TrimEnd(Path.DirectorySeparatorChar)) + ".rar" + "\" @temp" + b + ".txt";
                            p.Start();
                            p.WaitForExit();

                            File.Delete("temp" + b + ".txt");
                        }
                        break;
                }
                Console.WriteLine("------------------------------");
            }
        }
    }
}

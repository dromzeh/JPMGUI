using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Collections;

namespace JPMGUI
{
    public partial class Form1 : Form
    {
        public string selectedSubFolder;
        public Form1()
        {
            InitializeComponent();
        }

        private void setPathBtn_Click(object sender, EventArgs e)
        {
            string selectedSubFolder = selectionBox.Items[selectionBox.SelectedIndex].ToString();
            setJavaPath(selectedSubFolder);
        }

        private void SelectBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog javadir = new FolderBrowserDialog();
            javadir.Description = "Default directory is C:/Program Files/Java. Make sure to NOT select the jdk/jde folder - you want to select the folder where all your java versions are stored.";

            if (javadir.ShowDialog() == DialogResult.OK)
            {
                string SelectedPathJava = javadir.SelectedPath;
                // WriteLine(SelectedPathJava);
                SelectBtn.Text = "Select 'Java' Folder (" + SelectedPathJava + ")";

                // add the selected path to the settings ...
                Properties.Settings.Default.pathLocation = SelectedPathJava;
                Properties.Settings.Default.Save();
                Console.WriteLine("added path to settings: " + Properties.Settings.Default.pathLocation);

                // Clear all dropdownbox entries first...
                selectionBox.Items.Clear();

                // Goes through all folders in java folder and appends them to the dropdown.
                string[] foldersInJava = Directory.GetDirectories(SelectedPathJava);
                foreach (string folders in foldersInJava)
                {
                    Console.WriteLine("added " + folders);
                    selectionBox.Items.Add(folders);
                }      
            }
        }
        private void selectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSubFolder = selectionBox.Items[selectionBox.SelectedIndex].ToString();
            Console.WriteLine("Java folder set to: " + selectedSubFolder);
        }

        public void setJavaPath(string selectedSubFolder)
        {
            // Console.WriteLine(selectedSubFolder);
            // Makes sure that an entry has been set in the dropdown before continuing..
            if (!string.IsNullOrEmpty(selectedSubFolder))
            {
                Console.WriteLine("setting path to " + selectedSubFolder + "...");

                // Inside Path System ENV: C..Java..Sub..Bin
                // JAVA_HOME C..Java..Sub
                string javaHomePath = selectedSubFolder;
                string systemEnvPath = selectedSubFolder + @"\bin;";

                // Modify the JAVA_HOME Variable.
                string JAVAHOMEENVVAR = Environment.GetEnvironmentVariable("JAVA_HOME", EnvironmentVariableTarget.Machine);
                Environment.SetEnvironmentVariable("JAVA_HOME", javaHomePath, EnvironmentVariableTarget.Machine);

                // Modify Java Directory Inside "Path"..
                string SYSTEMENVVARPATH = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine);
                Console.WriteLine(SYSTEMENVVARPATH);

                if (SYSTEMENVVARPATH == null)
                {
                    Console.WriteLine("Creating New Path Variable as one doesn't exist...");
                    Environment.SetEnvironmentVariable("Path", systemEnvPath, EnvironmentVariableTarget.Machine);

                }
                else
                {
                    // Check if a Java entry already exists in the "Path" variable, if it does then remove it.
                    string[] pathEntries = SYSTEMENVVARPATH.Split(';');
                    List<string> list = new List<string>(pathEntries);

                    foreach (string path in pathEntries)
                    {
                        if (path.Contains(@"\bin") && path.Contains("Java"))
                        {
                            Console.WriteLine("Found existing Java directory inside 'Path': " + path);
                            list.Remove(path);
                        }
                    }

                    var strEnvPathEdited = String.Join(";", list.ToArray());
                    Console.WriteLine("New modified path: " + strEnvPathEdited);

                    string pathNew = systemEnvPath + strEnvPathEdited;
                    Console.WriteLine(pathNew);
                    Environment.SetEnvironmentVariable("Path", pathNew, EnvironmentVariableTarget.Machine);
                }

                MessageBox.Show("Changed JAVA_HOME Path to " + javaHomePath + " and added " + systemEnvPath + " to 'Path'.");
            }
            else
            {
                MessageBox.Show("There is no selected java version in the dropdown.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Check for any saved Java folder.
            string savedPath = Properties.Settings.Default.pathLocation;
            if (!string.IsNullOrEmpty(savedPath))
            {
                Console.WriteLine("Found saved path");
                string SelectedPathJava = Properties.Settings.Default.pathLocation;
                SelectBtn.Text = "Select 'Java' Folder (" + SelectedPathJava + ")";

                selectionBox.Items.Clear();
                string[] foldersInJava = Directory.GetDirectories(SelectedPathJava);
                foreach (string folders in foldersInJava)
                {
                    Console.WriteLine("added " + folders);
                    selectionBox.Items.Add(folders);
                }
            }
            else
            {
                Console.WriteLine("There is no existing saved location to load..");
            }
        }
    }
}

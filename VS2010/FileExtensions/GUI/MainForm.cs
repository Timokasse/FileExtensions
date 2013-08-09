using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

//using dotnetCHARTING.WinForms;

using DataModel;

namespace GUI {
    public partial class MainForm : Form {

        private bool _showCount = true;
        private FolderBrowserDialog _fbd = new FolderBrowserDialog();
        /// <summary>
        /// This is the thread used to browse a directory tree into a DirectoryData.
        /// </summary>
        private Thread _readDirectoryData;
        /// <summary>
        /// This is the DirectoryData view of the directory tree currently being browsed.
        /// There is no need to refer to it when the browsing is done.
        /// </summary>
        private DirectoryData _dd;


        public MainForm(string rootPath) {
            InitializeComponent();

            // Add the directory icons
            //tvDirectories.StateImageList = new ImageList();
            //tvDirectories.StateImageList.Images.Add(SystemIcons.Question);
            //tvDirectories.StateImageList.Images.Add(SystemIcons.Exclamation);

            // Show the extension count
            chart1.DefaultElement.Transparency = 20;
            chart1.PieLabelMode = dotnetCHARTING.WinForms.PieLabelMode.Outside;
            chart1.DefaultElement.ShowValue = true;

            _fbd.ShowNewFolderButton = false;

            // Add the predefined categories to the drop down list
            tscbCategories.Items.Add(new FileCategories("--None--"));

            // The RSM standard categories
            FileCategories fc = new FileCategories("RSM");
            fc.Categories.Add(new Language("ASM", new List<string> { "asm", "cpy", "inc", "mac", "sbt" }, Color.FromArgb(255, 255, 255)));
            fc.Categories.Add(new Language("ASP", new List<string> { "asp" }, Color.FromArgb(255, 255, 255)));
            fc.Categories.Add(new Language("C#", new List<string> { "cs" }, Color.FromArgb(255, 255, 255)));
            fc.Categories.Add(new Language("C", new List<string> { "i", "c", "h", "ec" }, Color.FromArgb(156, 154, 255)));
            fc.Categories.Add(new Language("CPP", new List<string> { "cpp", "cxx", "ecpp", "hpp", "hh", "hxx", "ipp", "dla" }, Color.FromArgb(156, 48, 99)));
            fc.Categories.Add(new Language("Delphi", new List<string> { "pas" }, Color.FromArgb(156, 48, 99)));
            fc.Categories.Add(new Language("HTML", new List<string> { "htm", "html", "xhtml", "hta", "css" }, Color.FromArgb(255, 255, 255)));
            fc.Categories.Add(new Language("Java", new List<string> { "java" }, Color.FromArgb(255, 255, 206)));
            fc.Categories.Add(new Language("JavaScript", new List<string> { "js" }, Color.FromArgb(255, 255, 255)));
            fc.Categories.Add(new Language("JSP", new List<string> { "jsp", "jsi", "jspf", "jsf" }, Color.FromArgb(255, 255, 255)));
            fc.Categories.Add(new Language("Perl", new List<string> { "pl", "pm" }, Color.FromArgb(255, 255, 255)));
            fc.Categories.Add(new Language("PHP", new List<string> { "php" }, Color.FromArgb(99, 0, 99)));
            fc.Categories.Add(new Language("Python", new List<string> { "py" }, Color.FromArgb(255, 255, 255)));
            fc.Categories.Add(new Language("Script", new List<string> { "sh" }, Color.FromArgb(255, 255, 255)));
            fc.Categories.Add(new Language("SQL", new List<string> { "gxq", "sql", "tsql", "plsql" }, Color.FromArgb(255, 255, 255)));
            fc.Categories.Add(new Language("VB", new List<string> { "cls" }, Color.FromArgb(255, 255, 255)));
            fc.Categories.Add(new Language("XML", new List<string> { "xml", "xslt", "dtd", "xsd", "xsl" }, Color.FromArgb(255, 255, 255)));
            tscbCategories.Items.Add(fc);

            // The UCC standard categories
            fc = new FileCategories("UCC");
            fc.Categories.Add(new Language("Ada", new List<string> { "ada", "a", "adb", "ads" }, Color.FromArgb(255, 255, 255)));
            fc.Categories.Add(new Language("ASP", new List<string> { "asp", "aspx" }, Color.FromArgb(255, 255, 255)));
            fc.Categories.Add(new Language("Bash", new List<string> { "sh" }, Color.FromArgb(255, 255, 255)));
            fc.Categories.Add(new Language("C#", new List<string> { "cs" }, Color.FromArgb(255, 255, 255)));
            fc.Categories.Add(new Language("ColdFusion", new List<string> { "cfm", "cfml", "cfc" }, Color.FromArgb(156, 154, 255)));
            fc.Categories.Add(new Language("CSS", new List<string> { "css" }, Color.FromArgb(156, 154, 255)));
            fc.Categories.Add(new Language("C_CPP", new List<string> { "i", "c", "h", "ec", "cpp", "cxx", "ecpp", "hpp", "hh", "hxx", "ipp" }, Color.FromArgb(156, 154, 255)));
            fc.Categories.Add(new Language("Fortran", new List<string> { "f", "for", "f77", "f90", "f95", "f03", "hpf" }, Color.FromArgb(156, 48, 99)));
            fc.Categories.Add(new Language("HTML", new List<string> { "htm", "html", "shtml", "stm", "sht", "oth", "xhtml" }, Color.FromArgb(255, 255, 255)));
            fc.Categories.Add(new Language("Java", new List<string> { "java" }, Color.FromArgb(255, 255, 206)));
            fc.Categories.Add(new Language("JavaScript", new List<string> { "js" }, Color.FromArgb(255, 255, 255)));
            fc.Categories.Add(new Language("JSP", new List<string> { "jsp" }, Color.FromArgb(255, 255, 255)));
            fc.Categories.Add(new Language("Perl", new List<string> { "pl", "pm" }, Color.FromArgb(255, 255, 255)));
            fc.Categories.Add(new Language("PHP", new List<string> { "php" }, Color.FromArgb(99, 0, 99)));
            fc.Categories.Add(new Language("Python", new List<string> { "py" }, Color.FromArgb(255, 255, 255)));
            fc.Categories.Add(new Language("SQL", new List<string> { "gxq", "sql", "tsql", "plsql" }, Color.FromArgb(255, 255, 255)));
            fc.Categories.Add(new Language("Visual_Basic", new List<string> { "vb", "frm", "mod", "cls", "bas" }, Color.FromArgb(255, 255, 255)));
            fc.Categories.Add(new Language("XML", new List<string> { "xml" }, Color.FromArgb(255, 255, 255)));
            tscbCategories.Items.Add(fc);
            
            // Make a list of languages for TPF with details
            fc = new FileCategories("TPF Detail");
            fc.Categories.Add(new Language("ASM", new List<string> { "asm", "cpy" }, Color.FromArgb(255, 255, 255)));
            fc.Categories.Add(new Language("C", new List<string> { "c" }, Color.FromArgb(255, 255, 255)));
            fc.Categories.Add(new Language("CPP", new List<string> { "cpp", "dla" }, Color.FromArgb(255, 255, 255)));
            fc.Categories.Add(new Language("H", new List<string> { "h" }, Color.FromArgb(255, 255, 255)));
            fc.Categories.Add(new Language("MAC", new List<string> { "mac" }, Color.FromArgb(255, 255, 255)));
            tscbCategories.Items.Add(fc);

            // Make a liist of languages for TPF as reported
            fc = new FileCategories("TPF");
            fc.Categories.Add(new Language("ASM", new List<string> { "asm", "cpy", "mac" }, Color.FromArgb(255, 255, 255)));
            fc.Categories.Add(new Language("CPP", new List<string> { "c", "h", "cpp", "dla" }, Color.FromArgb(255, 255, 255)));
            tscbCategories.Items.Add(fc);

            // By default no category is selected
            tscbCategories.SelectedItem = tscbCategories.Items[0];

            // If a root path was provided in the command line we open it
            if (!String.IsNullOrEmpty(rootPath)) {
                ReadDirectoryData(rootPath);
            }
        }

        private void ShowCount(DirectoryData root) {
            FileCategories fc = (FileCategories)tscbCategories.SelectedItem;
            Dictionary<string, int> count = root.TotalCount(fc);

            dotnetCHARTING.WinForms.SeriesCollection sc = new dotnetCHARTING.WinForms.SeriesCollection();
            foreach (KeyValuePair<string, int> ext in count) {
                dotnetCHARTING.WinForms.Series s = new dotnetCHARTING.WinForms.Series(ext.Key);
                dotnetCHARTING.WinForms.Element el = new dotnetCHARTING.WinForms.Element();
                el.Color = Color.White;
                Console.WriteLine("{0}: {1}", s.Name, el.Color);
                el.YValue = ext.Value;
                s.Elements.Add(el);
                sc.Add(s);

                //dotnetCHARTING.WinForms.SmartPalette sp = s.GetSmartPalette(dotnetCHARTING.WinForms.Palette.One);
                //sp.SaveState("PaletteOne.xml");
            }

            sc.Sort(dotnetCHARTING.WinForms.ElementValue.YValue, "Desc");
            chart1.SeriesCollection.Clear();
            chart1.SeriesCollection.Add(sc);
            dotnetCHARTING.WinForms.SmartPalette sp = new dotnetCHARTING.WinForms.SmartPalette();
            //dotnetCHARTING.WinForms.Palette.Autumn;
            Color c = new Color();
            c = Color.FromArgb(156, 154, 255);

        }

        private void ShowSize(DirectoryData root) {
            FileCategories fc = (FileCategories)tscbCategories.SelectedItem;
            Dictionary<string, long> size = root.TotalSize(fc);
            dotnetCHARTING.WinForms.SeriesCollection sc = new dotnetCHARTING.WinForms.SeriesCollection();
            foreach (KeyValuePair<string, long> ext in size) {
                dotnetCHARTING.WinForms.Series s = new dotnetCHARTING.WinForms.Series(ext.Key);
                dotnetCHARTING.WinForms.Element el = new dotnetCHARTING.WinForms.Element();
                el.YValue = ext.Value;
                s.Elements.Add(el);
                sc.Add(s);
            }
            sc.Sort(dotnetCHARTING.WinForms.ElementValue.YValue, "Desc");
            chart1.SeriesCollection.Clear();
            chart1.SeriesCollection.Add(sc);
        }

        private void RefreshPie() {
            if (tvDirectories.SelectedNode != null) {
                DirectoryData dd = (DirectoryData)tvDirectories.SelectedNode.Tag;
                if (_showCount) {
                    ShowCount(dd);
                } else {
                    ShowSize(dd);
                }
                chart1.RefreshChart();
                if (String.IsNullOrEmpty(dd.LastFile)) {
                    tslDate.Text = "Directory empty";
                } else {
                    string lastFile = dd.LastFile.Substring(dd.LastFile.IndexOf(dd.Name) + dd.Name.Length);
                    string firstFile = dd.LastFile.Substring(dd.FirstFile.IndexOf(dd.Name) + dd.Name.Length);
                    tslDate.Text = String.Format("Directory date: [{0} ({1}) - {2} ({3})]",dd.FirstDate, firstFile, dd.LastDate, lastFile);
                }
            }

        }

        /// <summary>
        /// Start reading the directories in a separate thread
        /// </summary>
        /// <param name="rootPath"></param>
        private void ReadDirectoryData(string rootPath) {
            _dd = new DirectoryData();
            _readDirectoryData = new Thread(new ParameterizedThreadStart(_dd.ReadDirectoryData));
            _readDirectoryData.Start(rootPath);

            timer1.Enabled = true;
        }

        #region GUI Events

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (_readDirectoryData != null) {
                // Stop reading directories
                DirectoryData.Abort = true;
                // Check that the reading thread is terminated
                while (_readDirectoryData.IsAlive) {
                    Thread.Sleep(100);
                }
            }
        }

        private void tscbCategories_SelectedIndexChanged(object sender, EventArgs e) {
            RefreshPie();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            if (_readDirectoryData.IsAlive) {
                this.Text = String.Format("FileExtension ({0})", DirectoryData.NbDirectories);
            } else {
                this.Text = "FileExtension";
                timer1.Enabled = false;

                // Add the directories to the tree
                tvDirectories.Nodes.Add(_dd.GetNodes());

                // Show it in the pie
                tvDirectories.SelectedNode = tvDirectories.Nodes[tvDirectories.Nodes.Count - 1];
                RefreshPie();

                // Ready to read another directory
                tsbOpen.Enabled = true;
                tvDirectories.AllowDrop = true;

                // Flash the taskbar icon
                FlashTitle.Flash(this);
            }
        }

        private void tsbOpen_Click(object sender, EventArgs e) {
            if (_fbd.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(_fbd.SelectedPath)) {
                // Do not read another directory until this one is done
                tsbOpen.Enabled = false;
                // Start the browsing of the directory
                ReadDirectoryData(_fbd.SelectedPath);
            }
        }

        private void tsbCount_Click(object sender, EventArgs e) {
            _showCount = true;
            tsbCount.Checked = true;
            tsbSize.Checked = false;
            RefreshPie();
        }

        private void tsbSize_Click(object sender, EventArgs e) {
            _showCount = false;
            tsbSize.Checked = true;
            tsbCount.Checked = false;
            RefreshPie();
        }

        private void tvDirectories_DoubleClick(object sender, EventArgs e) {
            if (tvDirectories.SelectedNode != null) {
                DirectoryData dd = (DirectoryData)tvDirectories.SelectedNode.Tag;
                string arg = String.Format("/e,/select,{0}", dd.FullName());
                string explorer;
                string windir = Environment.GetEnvironmentVariable("windir");
                if (String.IsNullOrEmpty(windir)) {
                    explorer = "C:\\WINDOWS\\explorer.exe";
                } else {
                    explorer = Path.Combine(windir, "explorer.exe");
                }
                Process.Start(explorer, arg);
            }
        }

        private void tvDirectories_AfterSelect(object sender, TreeViewEventArgs e) {
            RefreshPie();
        }

        #endregion

        private void toolStripButton1_Click(object sender, EventArgs e) {
            AboutFileExtensions about = new AboutFileExtensions();
            about.ShowDialog();
        }

        private void tvDirectories_DragDrop(object sender, DragEventArgs e) {
            string[] dirList = null;
            if (e.Data.GetFormats().Contains(DataFormats.FileDrop)) {
                dirList = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (dirList.Length > 0) {
                    tvDirectories.AllowDrop = false;
                    tsbOpen.Enabled = false;
                    ReadDirectoryData(dirList[0]);
                }
            }
        }

        private void tvDirectories_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;
        }

        /// <summary>
        /// A simple a crude way to remove a node from the treeview: a simple right click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvDirectories_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
            if ((tvDirectories.SelectedNode != null) && (e.Button == MouseButtons.Right)) {
                if (MessageBox.Show("Do you want to remove this directory from FileExtensions? (No impact on directories)", "FileExtensions", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    tvDirectories.Nodes.Remove(tvDirectories.SelectedNode);
                }
            }
        }

    }
}

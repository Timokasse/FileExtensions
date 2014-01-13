using System;
using System.Collections.Specialized;
using System.Deployment.Application;
using System.IO;
using System.Web;
using System.Windows.Forms;

using Microsoft.Win32;

namespace GUI {

    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {

            string rootPath = "";
            if (ApplicationDeployment.IsNetworkDeployed) {
                // The application was started from the web: http://ncecsemetric/ClickOnce/FileExtensions/FileExtensions.application?rootPath=D:\MyMusic
                if (ApplicationDeployment.CurrentDeployment.ActivationUri != null) {
                    string queryString = ApplicationDeployment.CurrentDeployment.ActivationUri.Query;
                    //MessageBox.Show(String.Format("queryString: {0}", queryString));
                    NameValueCollection nameValueTable = HttpUtility.ParseQueryString(queryString);
                    //MessageBox.Show(String.Format("nameValueTable: {0}", nameValueTable));
                    if (nameValueTable.Keys.Count > 0 && nameValueTable.Keys[0] == "rootPath") {
                        rootPath = nameValueTable[0];
                    }
                }
            } else {
                // Do we have a root path on the command line
                if (args.Length > 0) {
                    rootPath = args[0];
                }
            }
            //MessageBox.Show(String.Format("rootPath: {0}", rootPath));
            
            // Check that the given rootPath is a valid directory
            if (!Directory.Exists(rootPath)) {
                rootPath = "";
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(rootPath));

            // Make sure one can start the application from th econtext menu of Windows Explorer
            //UpdateContextMenu();
        }

        /// <summary>
        /// Doesn't work; I don't know what command line could work.
        /// What works in IE: http://ncecsemetric/ClickOnce/FileExtensions/FileExtensions.application?rootPath=D:\MyMusic
        /// What works in the command line: start http://ncecsemetric/ClickOnce/FileExtensions/FileExtensions.application?rootPath=D:\MyMusic
        /// </summary>
        static private void UpdateContextMenu() {
            RegistryKey regmenu = null;
            RegistryKey regcmd = null;
            regmenu = Registry.ClassesRoot.CreateSubKey(@"Folder\shell\FileExtensions");
            if (regmenu != null)
                regmenu.SetValue("", "FileExtensions");
            regcmd = Registry.ClassesRoot.CreateSubKey(@"Folder\shell\FileExtensions\command");
            if (regcmd != null)
                regcmd.SetValue("", @"C:\Documents and Settings\pcartgrandjean\Start Menu\Programs\Amadeus\FileExtensions.appref-ms %1");
            if (regmenu != null)
                regmenu.Close();
            if (regcmd != null)
                regcmd.Close();
        }
    }
}

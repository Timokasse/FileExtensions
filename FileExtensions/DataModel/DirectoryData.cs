using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DataModel {
    public class DirectoryData {

        private static MutexCounter _directories;

        /// <summary>
        /// The private property that will record the number of directories processed
        /// </summary>
        private static MutexCounter Directories {
            get {
                if (_directories == null) {
                    _directories = new MutexCounter();
                }
                return _directories;
            }
            set { _directories = value; }
        }

        /// <summary>
        /// We have a seperate property NbDirectories for the public but read only
        /// </summary>
        public static int NbDirectories {
            get { return Directories.Value; }
        }

        private static bool _abort = false;

        public static bool Abort {
            get { return _abort; }
            set { _abort = value; }
        }

        private string _name;
        /// <summary>
        /// The name of the repository.
        /// In the case of the root directory, we include the full path.
        /// </summary>
        public string Name {
            get { return _name; }
        }

        private List<DirectoryData> _children;
        /// <summary>
        /// The list of sub-directories
        /// </summary>
        public List<DirectoryData> Children {
            get { return _children; }
        }

        private DirectoryData _parent;
        /// <summary>
        /// To know where this directory comes from.
        /// <remarks>This is usefull to get the ful path of the directory.</remarks>
        /// </summary>
        public DirectoryData Parent {
            get { return _parent; }
            set { _parent = value; }
        }

        private Dictionary<string, int> _count;
        public Dictionary<string, int> Count {
            get { return _count; }
        }

        private Dictionary<string, long> _size;
        public Dictionary<string, long> Size {
            get { return _size; }
        }

        /// <summary>
        /// Stores the date of the most recent file in the directory and sub directory
        /// </summary>
        private DateTime _lastDate;
        public DateTime LastDate {
            get { return _lastDate; }
        }

        /// <summary>
        /// Stores the date of the oldest file in the directory and subdirectory
        /// </summary>
        private DateTime _firstDate;
        public DateTime FirstDate {
            get { return _firstDate; }
        }

        /// <summary>
        /// Stores the full name of the most recent file in the directory and sub directory
        /// </summary>
        private string _lastFile;
        public string LastFile {
            get { return _lastFile; }
        }

        /// <summary>
        /// Stores the full name of the oldest file in the directory and sub directory
        /// </summary>
        private string _firstFile;
        public string FirstFile {
            get { return _firstFile; }
        }

        public Dictionary<string, int> TotalCount(FileCategories fc) {
            Dictionary<string, int> count = TotalCount();
            if (fc != null && fc.Categories.Count > 0) {
                Dictionary<string, int> countCategories = new Dictionary<string, int>();
                foreach (KeyValuePair<string, int> extension in count) {
                    string category = fc.GetLanguage(extension.Key);
                    if (countCategories.ContainsKey(category)) {
                        countCategories[category] += extension.Value;
                    } else {
                        countCategories[category] = extension.Value;
                    }
                }
                return countCategories;
            } else {
                return count;
            }
        }

        public Dictionary<string, int> TotalCount() {
            Dictionary<string, int> count = new Dictionary<string, int>();
            TotalCount(count);
            return count;
        }

        private void TotalCount(Dictionary<string, int> total) {
            // Add the count of the current directory
            foreach (KeyValuePair<string, int> extension in _count) {
                if (total.ContainsKey(extension.Key)) {
                    total[extension.Key] += extension.Value;
                } else {
                    total[extension.Key] = extension.Value;
                }
            }
            // Add subdirectories if any
            if (_children != null) {
                foreach (DirectoryData child in _children) {
                    child.TotalCount(total);
                }
            }
        }

        public Dictionary<string, long> TotalSize(FileCategories fc) {
            Dictionary<string, long> count = TotalSize();
            if (fc != null && fc.Categories.Count > 0) {
                Dictionary<string, long> countCategories = new Dictionary<string, long>();
                foreach (KeyValuePair<string, long> extension in count) {
                    string category = fc.GetLanguage(extension.Key);
                    if (countCategories.ContainsKey(category)) {
                        countCategories[category] += extension.Value;
                    } else {
                        countCategories[category] = extension.Value;
                    }
                }
                return countCategories;
            } else {
                return count;
            }
        }

        public Dictionary<string, long> TotalSize() {
            Dictionary<string, long> size = new Dictionary<string, long>();
            TotalSize(size);
            return size;
        }



        private void TotalSize(Dictionary<string, long> total) {
            // Add the size of the current directory
            foreach (KeyValuePair<string, long> extension in _size) {
                if (total.ContainsKey(extension.Key)) {
                    total[extension.Key] += extension.Value;
                } else {
                    total[extension.Key] = extension.Value;
                }
            }
            // Add subdirectories if any
            if (_children != null) {
                foreach (DirectoryData child in _children) {
                    child.TotalSize(total);
                }
            }

        }

        private string GetExtension(string fileName) {
            string[] parsedFileName = fileName.Split('.');
            if (parsedFileName.Length > 1) {
                return parsedFileName[parsedFileName.Length - 1];
            } else if (fileName[0] == '.') {
                return fileName;
            } else {
                return "";
            }
        }

        /// <summary>
        /// Empty constructor to get a reference
        /// </summary>
        public DirectoryData() {
        }

        public DirectoryData(string path)
            : this(null, new DirectoryInfo(path)) {
            // Override the root directory name with the whole path
            _name = path;
        }

        private DirectoryData(DirectoryData parent, DirectoryInfo di) {
            ReadDirectoryData(parent, di);
        }

        public void ReadDirectoryData(object parameter) {
            string path = (string)parameter;
            // Start counting the directories. This first call will also create the Mutex object
            Directories++;
            // Read the current directory and recursivelly all subdirectories
            ReadDirectoryData(null, new DirectoryInfo(path));
            // Override the root directory name with the whole path
            _name = path;
        }

        private void ReadDirectoryData(DirectoryData parent, DirectoryInfo di) {
            if (!_abort) {
                _name = di.Name;
                _parent = parent;
                // Create the counters lists
                _count = new Dictionary<string, int>();
                _size = new Dictionary<string, long>();
                _children = new List<DirectoryData>();
                _lastDate = DateTime.MinValue;
                _firstDate = DateTime.MaxValue;
                _lastFile = "";
                // Read the directory's content
                try {
                    foreach (FileInfo fi in di.GetFiles()) {
                        string ext = GetExtension(fi.Name);
                        if (_count.ContainsKey(ext)) {
                            _count[ext]++;
                        } else {
                            _count[ext] = 1;
                        }
                        if (_size.ContainsKey(ext)) {
                            _size[ext] += fi.Length;
                        } else {
                            _size[ext] = fi.Length;
                        }
                        if (fi.LastWriteTime > _lastDate) {
                            _lastDate = fi.LastWriteTime;
                            _lastFile = fi.FullName;
                        }
                        if (fi.LastWriteTime < _firstDate) {
                            _firstDate = fi.LastWriteTime;
                            _firstFile = fi.FullName;
                        }
                    }
                    // Read the sub directories
                    foreach (DirectoryInfo sdi in di.GetDirectories()) {
                        // Rule out CVS directories
                        if (!sdi.Name.Equals("CVS")) {
                            Directories++;
                            DirectoryData child = new DirectoryData(this, sdi);
                            _children.Add(child);
                            if (child._lastDate > _lastDate) {
                                _lastDate = child._lastDate;
                                _lastFile = child._lastFile;
                            }
                            if (child._firstDate < _firstDate) {
                                _firstDate = child._firstDate;
                                _firstFile = child._firstFile;
                            }
                        }
                    }
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public TreeNode GetNodes() {
            TreeNode node = new TreeNode(_name);
            node.Tag = this;
            foreach (DirectoryData child in _children) {
                node.Nodes.Add(child.GetNodes());
            }
            return node;
        }

        /// <summary>
        /// This gets the full name of a directory including its path.
        /// With this function we only need to store the path in the root directory and a link to the parent.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public string FullName() {
            if (_parent == null) {
                // The name of the root directory is its the full path
                return _name;
            } else {
                // If there is a parent we get the full name by adding the name of the current directory to the full name of its parent.
                string fullName = Path.Combine(_parent.FullName(), _name);
                return fullName;
            }
        }

    }
}

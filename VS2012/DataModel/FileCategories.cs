using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DataModel {
    public class FileCategories {

        private string _name;

        public string Name {
            get { return _name; }
        }

        private List<Language> _categories;
        public List<Language> Categories {
            get { return _categories; }
        }

        private bool _other;
        /// <summary>
        /// Indicator to group extensions not in the list of languages in "Other"
        /// </summary>
        public bool Other {
            get { return _other; }
            set { _other = value; }
        }

        public FileCategories(string name) {
            _name = name;
            _categories = new List<Language>();
            _other = true;
        }

        public string GetLanguage(string extension) {
            Language language = _categories.Find(
                delegate(Language lan) {
                    return lan.BelongsToLanguage(extension);
                }
            );
            if (language != null) {
                return language.Name;
            } else if (_other) {
                return "Other";
            } else {
                return extension;
            }
        }

        public Color GetColor(string languageName) {
            Language language = _categories.Find(
                delegate(Language lan) {
                    return lan.Name == languageName;
                }
            );
            if (language != null) {
                return language.Color;
            } else if (_other) {
                return Color.White;
            } else {
                return Color.Black;
            }
        }

        /// <summary>
        /// Override the default ToString function.
        /// This will be used by the drop down list.
        /// </summary>
        /// <returns>The name of the categories definition</returns>
        public override string ToString() {
            return _name;
        }
    }
}

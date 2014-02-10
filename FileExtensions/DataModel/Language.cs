using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DataModel {
    public class Language {
        private string _name;

        public string Name {
            get { return _name; }
            set { _name = value; }
        }
        private List<string> _extensions;

        public List<string> Extensions {
            get { return _extensions; }
            set { _extensions = value; }
        }
        private Color _color;

        public Color Color {
            get { return _color; }
            set { _color = value; }
        }

        public bool BelongsToLanguage(string extension) {
            return _extensions.Contains(extension);
        }

        public Language(string name, List<string> extensions, Color color) {
            _name = name;
            _extensions = extensions;
            _color = color;
        }
    }
}

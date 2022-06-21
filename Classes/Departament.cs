using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFModernVerticalMenu.Classes
{
    public class Departament
    {
        public Departament(string name, string fullName, string image)
        {
            Name = name;
            FullName = fullName;
            Image = image;
        }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Image { get; set; }
    }
}

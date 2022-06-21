using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFModernVerticalMenu.Classes
{
    public class Room
    {
        public Room(string name, int idDepartament, string image)
        {
            Name = name;
            IdDepartament = idDepartament;
            Image = image;
        }
        public string Name { get; set; }
        public int IdDepartament { get; set; }
        public string Image { get; set; }
    }
}

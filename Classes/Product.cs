using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFModernVerticalMenu.Classes
{
    public class Product
    {
        public Product(string name, int count, string image, DateTime date, int idRoom)
        {
            Name = name;
            Count = count;
            Image = image;
            Date = date;
            IdRoom = idRoom;

        }
        public string Name { get; set; }
        public int Count { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public int IdRoom { get; set; }
    }
}

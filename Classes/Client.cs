using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFModernVerticalMenu.Classes
{
    public class Client
    {
        public Client(string name, string login, string link, int role, string image, int departament)
        {
            Name = name;
            Login = login;
            Link = link;
            Role = role;
            Image = image;
            Departament = departament;
        }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Link { get; set; }
        public int Role { get; set; }
        public string Image { get; set; }
        public int Departament { get; set; }
    }
}

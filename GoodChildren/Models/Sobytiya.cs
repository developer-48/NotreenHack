using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodChildren.Models
{
    public class Sobytiya
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Adress { get; set; }
        public string Contact { get; set; }
        public int Mesta { get; set; }
        public int Zanyata { get; set; }
        public int Like { get; set; }
        public int Vozrast { get; set; }
        public string Spons { get; set; }
        public string Volonts { get; set; }
    }
}

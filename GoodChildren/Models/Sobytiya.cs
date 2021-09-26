using Microsoft.AspNetCore.Http;
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
        public string Opisanie { get; set; }
        public string Contact { get; set; }
        public int Mesta { get; set; }
        public int Zanyata { get; set; }
        public int Like { get; set; }
        public int Vozrast { get; set; }
        public string Spons { get; set; }
        public string Volonts { get; set; }
        public string Vladelec { get; set; }
        public int VladelecId { get; set; }
        public bool State { get; set; }
        public bool Zayavki { get; set; }
    }
    public class SobytiyaFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<IFormFile> files { get; set; }
        public string Adress { get; set; }
        public string Opisanie { get; set; }
        public string Contact { get; set; }
        public int Mesta { get; set; }
        public int Zanyata { get; set; }
        public int Like { get; set; }
        public int Vozrast { get; set; }
        public string Spons { get; set; }
        public string Volonts { get; set; }
        public string Vladelec { get; set; }
        public int VladelecId { get; set; }
        public bool State { get; set; }
        public bool Zayavki { get; set; }
    }
}

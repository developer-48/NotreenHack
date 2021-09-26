using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodChildren.Models
{
    public class User
    {
        public int Id { get; set; }   //Эт не создавать
        public string LoginEmail { get; set; } //Логин или Эмейл
        public string Password { get; set; }  //Пароль
        public string Role { get; set; }  //Ребенок или волонтёр
        public string fullName { get; set; } //ФИО
        public DateTime BirthDate { get; set; } //Дата рождения
        public string cityChillHouse { get; set; } // Детский дом или город проживания
        public string PhoneNum { get; set; } // Номер телефона
        public int Coins { get; set; }
    }
    public class Spons
    {
        public int Id { get; set; }   //Эт не создавать
        public string LoginEmail { get; set; } //Логин или Эмейл
        public string Password { get; set; }  //Пароль
        public string Role { get; set; }  //Ребенок или волонтёр
        public string fullName { get; set; } //ФИО
        public DateTime BirthDate { get; set; } //Дата рождения
        public string cityChillHouse { get; set; } // Детский дом или город проживания
        public string PhoneNum { get; set; } // Номер телефона
        public string OSebe { get; set; } // Детский дом или город проживания
    }
}

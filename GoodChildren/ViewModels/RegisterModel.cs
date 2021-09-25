using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodChildren.ViewModels
{
    public class RegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string fullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string cityChillHouse { get; set; }
        public string PhoneNum { get; set; }
    }
}

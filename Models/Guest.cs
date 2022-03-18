using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kutseAppEvtina.Models
{
    public class Guest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Sissesta nimi")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Sissesta email")]
        [RegularExpression(@".+\@.+\..+", ErrorMessage = "Vali sisestatud email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Sissesta telefoni number")]
        [RegularExpression(@"\+372.+", ErrorMessage = "Numbril alguses peal olema +372")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Sissesta oma valik")]
        public bool? WillAttend { get; set; }
    }
}
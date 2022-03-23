using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kutseAppEvtina.Models
{
    public class Holidays
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Sissesta puhkuse nimi")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Sissesta kupäev")]
        /*[DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]*/
        [RegularExpression(@"(\d{2}/\d{2}/\d{4})")]
        public string Date { get; set; }


    }
}
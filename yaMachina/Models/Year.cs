using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yaMachina.Models
{
    public class Year
    {
        [Key]
        public int ID { get; set; }
        public int YearPublished { get; set; } // рік видання


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yaMachina.Models
{
    public class FIO
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; } 
        public string SurName { get; set; } //фамілія 

        public string LastName { get; set; } // по батькові 



    }
}

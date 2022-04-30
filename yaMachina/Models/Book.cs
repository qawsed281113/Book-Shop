using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yaMachina.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }    
        public string Name{ get; set; }  // nazva
        public int pages { get; set; }// 
        public int Price { get; set; } // zhina
        public bool IsCountin { get; set; } // чи продовжує


     
        public int ID_Fio { get; set; }
        [ForeignKey("ID_Fio")]
        public FIO Fio { get; set; }

        public int ID_Genre { get; set; }

        [ForeignKey("ID_Genre")]
        public Genre Genre { get; set; }


       
        public int ID_Publisher { get; set; }
        [ForeignKey("ID_Publisher")]
        public Publisher Publisher { get; set; }

        public int ID_Year { get; set; }

        [ForeignKey("ID_Year")]
        public Year Year { get; set; }

    }
}

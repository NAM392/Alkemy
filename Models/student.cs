using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy_1.Models
{
    public class student
    {
        public int studentId { get; set; }
        public int dni { get; set; }
        public int file { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public int active { get; set; }


        public ICollection<inscription> Inscriptions { get; set; }


    }
}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy_1.Models
{
    public class inscription
    {

        public int inscriptionID { get; set; }
        public int studentId { get; set; }
        public int courseId { get; set; }
       

        public course Course { get; set; }
        public student Student { get; set; }





    }
}

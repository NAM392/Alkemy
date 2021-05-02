using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Alkemy_1.Models
{
    public class course
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int courseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int maximum_quantity_students { get; set; }
        public int professorId { get; set; }
        //public DateTime Date_ { get; set; }

        public professor Professor { get; set; }
        public ICollection<inscription> Inscriptions { get; set; }
    }
}


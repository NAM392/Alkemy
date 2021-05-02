using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alkemy_1.Models;

namespace Alkemy_1.DTO
{
    public class Professor_Course_DTO
    {
       public  List<professor> Professors { get; set; }
       public  course Course_Complete { get; set; }
    }
}

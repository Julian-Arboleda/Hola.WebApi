using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hola.Models
{
   public class LocationEdit
    {

        public int LocationId { get; set; }
       
        public string Country { get; set; }
    
        public string State { get; set; }
        
        public string City { get; set; }
    }
}

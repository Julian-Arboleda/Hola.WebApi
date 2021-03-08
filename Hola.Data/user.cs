using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hola.Data
{
    public class user
    {
        [Key]
        public int userId { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string interest { get; set; }
        [Required]
        public double income { get; set; }
        [Required]
        public Guid ownerId { get; set; }
    }
}

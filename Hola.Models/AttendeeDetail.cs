using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hola.Models
{
    public class AttendeeDetail
    {
        public int AttendeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid CreatorId { get; set; }
    }
}

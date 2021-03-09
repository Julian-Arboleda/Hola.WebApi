using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hola.Models
{
    public class MessageDetail
    {
        public int MessageId { get; set; }
        public Guid CreatorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset DateCreated { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedDateCreated { get; set; }
    }
}

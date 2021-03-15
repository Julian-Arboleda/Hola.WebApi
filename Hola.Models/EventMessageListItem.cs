using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hola.Models
{
    public class EventMessageListItem
    {
        public int EventMessageId { get; set; }
       // public int MessageId { get; set; }
        public string Content { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset DateCreated { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedDateCreated { get; set; }
    }
}

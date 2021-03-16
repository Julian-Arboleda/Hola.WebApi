using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hola.Models
{
    public class MessageListItem
    {
        public int MessageId { get; set; }
        
        public string Title { get; set; }
        
        public string Content { get; set; }

        [Display(Name = "Liked")]
        public bool IsLiked { get; set; }

        public DateTimeOffset DateCreated { get; set; }
    }
}

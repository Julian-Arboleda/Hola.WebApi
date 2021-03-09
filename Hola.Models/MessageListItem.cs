using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hola.Models
{
    public class MessageListItem
    {
        public int MessageId { get; set; }
        public string Content { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}

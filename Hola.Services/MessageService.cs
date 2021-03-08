using Hola.Data;
using Hola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hola.Services
{
   public class MessageService
    {
        private readonly Guid _userId;

        public MessageService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMessage(MessageCreate model)
        {
            var entity =
                new Message()
                {
                    // LocationId = _userId,
                    Content = model.Content,
                    DateCreated = model.DateCreated
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Messages.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

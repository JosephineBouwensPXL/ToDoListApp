using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.AppLogic;
using ToDoListApp.Domain;

namespace ToDoListApp.Infrastructure
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        private readonly ToDoListContext _context;

        public ToDoItemRepository(ToDoListContext context)
        {
            _context = context;
        }

        public int GetTotalOfItemsThatAreNotDone()
        {
            return _context.Set<ToDoItem>().Where(t => t.IsDone == false).Count();
        }

        public ToDoItem Update(Guid id, bool isDone)
        {
            var item = _context.Set<ToDoItem>().FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                 item.IsDone = isDone;
            _context.Update(item);
             _context.SaveChanges();
            return item;
            }
            return null;
          
            

        }
    }
}

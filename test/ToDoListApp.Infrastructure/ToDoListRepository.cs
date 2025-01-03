using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.AppLogic;
using ToDoListApp.Domain;

namespace ToDoListApp.Infrastructure
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly ToDoListContext _context;

        public ToDoListRepository(ToDoListContext context)
        {
            _context = context;
        }

        public void AddItemToExistingList(Guid listId, string itemDescription)
        {
            ToDoList? list = _context.ToDoLists.FirstOrDefault(list => list.Id == listId);
            if (list != null)
            {
                list.Items.Add(ToDoItem.CreateNew(itemDescription));
            }
            _context.SaveChanges();
        }

        public ToDoList AddNew(string title)
        {
            var toDoList = ToDoList.CreateNew(title);
            _context.ToDoLists.Add(toDoList);
            _context.SaveChanges();
            return toDoList;

        }

        public IList<ToDoList> Find(string? titleFilter)
        {
            IList<ToDoList> toDoLists = _context.ToDoLists.Where(list => list.Title.Contains( titleFilter)).ToList();
            return toDoLists;
        }

        public ToDoList? GetById(Guid id)
        {
            return _context.ToDoLists.FirstOrDefault(i => i.Id == id);
        }
    }
}

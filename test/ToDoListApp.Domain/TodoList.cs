using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Domain
{
    public class ToDoList
    {
        public Guid Id { get; private set; } // private set for EF (EF can set properties with a private setter)
        [MinLength(4)]
        public string Title { get; set; }

        public IList<ToDoItem> Items { get; private set; }

        private ToDoList(Guid id, string title) // EF can use constructors of which the parameter names match the property names
        {
            Id = id;
            Title = title;
            Items = new List<ToDoItem>();
        }

        public static ToDoList CreateNew(string title)
        {
            if (title == null || title == "")
            {
                throw new ArgumentException("title");
            }
            ToDoList t =  new ToDoList(Guid.NewGuid(), title);
            return t;
        }
    }
}

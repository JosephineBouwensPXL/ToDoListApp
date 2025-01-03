using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Domain
{
    public class ToDoItem
    {
        public Guid Id { get; private set; } // private set for EF (EF can set properties with a private setter)
      //  [Required("the discripion is requird")]
        public string Description { get; private set; } // private set for EF (EF can set properties with a private setter)

        public bool IsDone { get; set; }

        private ToDoItem() // private constructor for EF
        {
            Id = Guid.Empty;
            Description = string.Empty;
            IsDone = false;
        }

        public static ToDoItem CreateNew(string description)
        {
            if (description == null || description == "")
            {
                throw new ArgumentException("title");
            }
            ToDoItem item = new ToDoItem();
            item.Id = Guid.NewGuid();
            item.Description = description;
            return item;
        }
    }
}

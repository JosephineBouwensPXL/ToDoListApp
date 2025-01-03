using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoListApp.AppLogic;
using ToDoListApp.Domain;

namespace ToDoListApp.Web.Pages.ToDo
{
    public class SearchModel : PageModel
    {
        [BindProperty]
        public string TitleFilter { get; set; }
        public IList<ToDoList> ToDoLists { get; set; }
        private readonly IToDoListRepository _toDoListRepository;

        public SearchModel(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            ToDoLists = _toDoListRepository.Find(TitleFilter);
            return Page();
        }
    }
}

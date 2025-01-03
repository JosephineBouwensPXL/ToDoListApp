using Microsoft.AspNetCore.Mvc;
using ToDoListApp.AppLogic;
using ToDoListApp.Infrastructure;
using ToDoListApp.Web.Models;

namespace ToDoListApp.Web.Components
{
    public class Badge : ViewComponent
    {
        public readonly IToDoItemRepository _itemRepository;

        public Badge(IToDoItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public IViewComponentResult Invoke()
        {
            BadgeViewModel badgeView = new BadgeViewModel();
            var badge = _itemRepository.GetTotalOfItemsThatAreNotDone();
            badgeView.BadgeCount = badge;
            Console.WriteLine($"Aantal TODOs: {badge}");
            return View(badgeView);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoListApp.AppLogic;
using ToDoListApp.Domain;
using ToDoListApp.Infrastructure;
using ToDoListApp.Web.Models;

namespace ToDoListApp.Web.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly IToDoListRepository _repository;
        

        public ToDoListController(IToDoListRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Detail(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index", "Home");
            }            
            ToDoListDetailViewModel model = new ToDoListDetailViewModel(_repository.GetById(id));

            return View(model);
        }

        [HttpPost]
        public IActionResult Detail(ToDoListDetailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _repository.AddItemToExistingList(model.ListId, model.NewItemDescription);
            var list = _repository.GetById(model.ListId);
            model = new ToDoListDetailViewModel(list);
            return View(model);
        }
   
    }
}

using Microsoft.AspNetCore.Mvc;
using ToDoListApp.AppLogic;
using ToDoListApp.Domain;
using ToDoListApp.Infrastructure;
using ToDoListApp.Web.Models;

namespace ToDoListApp.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListsController : ControllerBase
    {
        private readonly IToDoListRepository _toDoListRepository;
        private readonly IToDoItemRepository _toDoItemRepository;

        public ToDoListsController(IToDoListRepository toDoListRepository, IToDoItemRepository toDoItemRepository)
        {
            _toDoListRepository = toDoListRepository;
            _toDoItemRepository = toDoItemRepository;
        }
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var toDoList = _toDoListRepository.GetById(id);
            if (toDoList == null)
            {
                return NotFound();
            }
            return Ok(toDoList);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddNewToDoListModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            ToDoList l = _toDoListRepository.AddNew(model.Title);
            return CreatedAtAction(nameof(Create), new { id = l.Id }, l);

        }
        [HttpPut("{listId}/items/{itemId}")]
        public IActionResult Update(Guid listId, Guid itemId, [FromBody] UpdateToDoItemModel updateModel)
        {
            if (updateModel == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid data provided.");
            }
            var list = _toDoListRepository.GetById(listId);
            if (list == null)
            {
                return NotFound($"ToDoList with ID {listId} not found.");
            }
            if (list.Title.Length < 4)
            {
                return BadRequest("Invalid title");
            }
            var updatedItem = _toDoItemRepository.Update(itemId, updateModel.IsDone);
            if (updatedItem == null)
            {
                return NotFound($"ToDoItem with ID {itemId} not found.");
            }

            return Ok(updatedItem);

        }


    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnetMvc.Models;
using dotnetMvc.Data;


namespace dotnetMvc.Controllers
{
  [Route("todos")]
  public class ToDoController : Controller
  {
    private readonly DataContext _dataContext;

    public ToDoController(DataContext dataContext)
    {
      _dataContext = dataContext;
    }

    [HttpGet("")]
    public IActionResult GetToDos()
    {
      List<ToDo> todos = new List<ToDo>();
      todos = _dataContext.ToDoList.ToList();
      return View("Index", todos);
    }

    [HttpPost("")]
    public async Task<IActionResult> AddTodo(ToDo todo)
    {
      await _dataContext.ToDoList.AddAsync(todo);
      await _dataContext.SaveChangesAsync();

      return RedirectToAction("GetToDos");
    }

    [HttpGet("remove")]
    public IActionResult RemoveTodo(ToDo todo)
    {
      _dataContext.ToDoList.Remove(todo);
      _dataContext.SaveChanges();

      return RedirectToAction("GetTodos");
    }


    [HttpGet("edit")]
    public IActionResult EditTodo(int id)
    {
      ToDo todo = _dataContext.ToDoList.First(c => c.Id == id);
      return View("edit", todo);
    }

    [HttpPost("edit")]
    public IActionResult UpdateTodo(int id, string task, bool status)
    {
      ToDo todo = _dataContext.ToDoList.First(c => c.Id == id);
      todo.Task = task;
      todo.status = status;
      _dataContext.SaveChanges();

      return RedirectToAction("GetTodos");
    }

    [HttpPost("clear")]
    public IActionResult ClearAllTasks(){
      var all = from c in _dataContext.ToDoList select c;
      _dataContext.ToDoList.RemoveRange(all);
      _dataContext.SaveChanges();

      return RedirectToAction("GetTodos");
    }

  }
}
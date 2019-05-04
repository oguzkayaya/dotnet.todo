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



  }
}
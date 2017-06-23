using Microsoft.AspNetCore.Mvc;
using TarefaWeb.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TarefaWeb.Controllers
{
    public class TarefaController : Controller
    {
        private TarefaContext _context;

        public TarefaController(TarefaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var lista = _context.Tarefas.ToList();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tarefa e)
        {
            _context.Tarefas.Add(e);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Tarefa t = _context.Tarefas.Find(id);
            _context.Tarefas.Remove(t);
            _context.SaveChanges();
             return RedirectToAction("index");
        }

        public IActionResult Update(int id)
        {
            return View( _context.Tarefas.Find(id));
        }

        [HttpPost]
        public IActionResult Update(Tarefa e)
        {
            _context.Entry<Tarefa>(e).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
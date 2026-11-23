using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Biblioteca.Controllers;
public class EstudiantesController(BibliotecaContext db) : Controller
{
    public async Task<IActionResult> Index() => View(await db.Estudiantes.ToListAsync());
    public IActionResult Create() => View();
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Estudiante item)
    {
        if (!ModelState.IsValid) return View(item);
        db.Estudiantes.Add(item); await db.SaveChangesAsync(); return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Edit(int id)
    {
        var item = await db.Estudiantes.FindAsync(id);
        return item == null ? NotFound() : View(item);
    }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Estudiante item)
    {
        if (id != item.EstudianteId) return BadRequest();
        if (!ModelState.IsValid) return View(item);
        db.Estudiantes.Update(item); await db.SaveChangesAsync(); return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Details(int id)
    {
        var item = await db.Estudiantes.FindAsync(id);
        return item == null ? NotFound() : View(item);
    }
    public async Task<IActionResult> Delete(int id)
    {
        var item = await db.Estudiantes.FindAsync(id);
        return item == null ? NotFound() : View(item);
    }
    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var item = await db.Estudiantes.FindAsync(id);
        if (item == null) return NotFound();
        try { db.Estudiantes.Remove(item); await db.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
        catch (DbUpdateException) { ViewBag.Error = "No se puede eliminar porque tiene registros relacionados."; return View("Delete", item); }
    }
}

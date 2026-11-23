using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Biblioteca.Controllers;
public class AutoresController(BibliotecaContext db) : Controller
{
    public async Task<IActionResult> Index() => View(await db.Autores.ToListAsync());
    public IActionResult Create() => View();
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Autor item)
    {
        if (!ModelState.IsValid) return View(item);
        db.Autores.Add(item); await db.SaveChangesAsync(); return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Edit(int id)
    {
        var item = await db.Autores.FindAsync(id);
        return item == null ? NotFound() : View(item);
    }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Autor item)
    {
        if (id != item.AutorId) return BadRequest();
        if (!ModelState.IsValid) return View(item);
        db.Autores.Update(item); await db.SaveChangesAsync(); return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Details(int id)
    {
        var item = await db.Autores.FindAsync(id);
        return item == null ? NotFound() : View(item);
    }
    public async Task<IActionResult> Delete(int id)
    {
        var item = await db.Autores.FindAsync(id);
        return item == null ? NotFound() : View(item);
    }
    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var item = await db.Autores.FindAsync(id);
        if (item == null) return NotFound();
        try { db.Autores.Remove(item); await db.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
        catch (DbUpdateException) { ViewBag.Error = "No se puede eliminar porque tiene registros relacionados."; return View("Delete", item); }
    }
}

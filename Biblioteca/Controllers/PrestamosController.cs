using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Biblioteca.Controllers;
public class PrestamosController(BibliotecaContext db) : Controller
{
    public async Task<IActionResult> Index() => View(await db.Prestamos.ToListAsync());
    public IActionResult Create() => View();
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Prestamo item)
    {
        if (!ModelState.IsValid) return View(item);
        db.Prestamos.Add(item); await db.SaveChangesAsync(); return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Edit(int id)
    {
        var item = await db.Prestamos.FindAsync(id);
        return item == null ? NotFound() : View(item);
    }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Prestamo item)
    {
        if (id != item.PrestamoId) return BadRequest();
        if (!ModelState.IsValid) return View(item);
        db.Prestamos.Update(item); await db.SaveChangesAsync(); return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Details(int id)
    {
        var item = await db.Prestamos.FindAsync(id);
        return item == null ? NotFound() : View(item);
    }
    public async Task<IActionResult> Delete(int id)
    {
        var item = await db.Prestamos.FindAsync(id);
        return item == null ? NotFound() : View(item);
    }
    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var item = await db.Prestamos.FindAsync(id);
        if (item == null) return NotFound();
        try { db.Prestamos.Remove(item); await db.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
        catch (DbUpdateException) { ViewBag.Error = "No se puede eliminar porque tiene registros relacionados."; return View("Delete", item); }
    }
}

using Microsoft.AspNetCore.Mvc;
using TurnosPeluqueria_EJ06.Models;

namespace TurnosPeluqueria_EJ06.Controllers;

public class TurnosController : Controller
{
    public IActionResult Index()
    {
        ViewBag.turnos = BD.ObtenerTurnos();

        return View();
    }

    [HttpGet]
    public IActionResult Nuevo()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Nuevo(Turno turno)
    {
        // Estado inicial fijo
        if (string.IsNullOrWhiteSpace(turno.Estado))
            turno.Estado = "Pendiente";

        BD.AgregarTurno(turno);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Atender(int id)
    {
        BD.CambiarEstado(id, "Atendido");
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Cancelar(int id)
    {
        BD.CambiarEstado(id, "Cancelado");
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Modificar(int id)
    {
        ViewBag.Id = id;
        return View("Modificar", "Turnos");
    }

    public IActionResult CambiarFecha(int id, DateTime nuevaFecha){
        BD.CambiarFecha(id, nuevaFecha);
        return RedirectToAction("Index");
    }
}
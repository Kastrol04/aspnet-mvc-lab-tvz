using Microsoft.AspNetCore.Mvc;
using VozniRedVlakova.Data;
using VozniRedVlakova.Models;

namespace VozniRedVlakova.Controllers;

public class PregledController : Controller
{
    private readonly IMockRepository _repository;

    public PregledController(IMockRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult Index(string entity, string? state = null)
    {
        if (string.IsNullOrWhiteSpace(entity))
        {
            return RedirectToAction("Index", "Home");
        }

        var items = _repository.GetByEntity(entity).ToList();
        var model = new EntityIndexViewModel
        {
            EntityKey = entity,
            EntityTitle = _repository.GetEntityTitle(entity),
            Items = items
        };

        return View(model);
    }

    [HttpGet]
    public IActionResult Details(string entity, int id, string? state = null)
    {
        if (string.IsNullOrWhiteSpace(entity))
        {
            return RedirectToAction("Index", "Home");
        }

        var item = _repository.GetByEntityAndId(entity, id);
        var model = new EntityDetailsViewModel
        {
            EntityKey = entity,
            EntityTitle = _repository.GetEntityTitle(entity),
            Item = item
        };

        return View(model);
    }
}

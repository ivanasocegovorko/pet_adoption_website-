using midterm_project.Repositories;
using midterm_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace midterm_project.Controllers;

public class DogController : Controller
{
    private readonly ILogger<DogController> _logger;
    private readonly IDogRepository _dogRepository;

    public DogController(ILogger<DogController> logger, IDogRepository repository)
    {
        _logger = logger;
        _dogRepository = repository;
    }

    public IActionResult List()
    {
        return View(_dogRepository.GetAllDogs());
    }

    public IActionResult Detail(int id) 
    {
        return View(_dogRepository.GetDogById(id));
    }

    public IActionResult Edit(int id) 
    {
        var dog = _dogRepository.GetDogById(id);

        if (dog == null) {
            return RedirectToAction("List");
        }

        return View(dog);
    }

    [HttpPost]
    public IActionResult Edit(Dog dog) 
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        
        _dogRepository.UpdateDog(dog);
        
        return RedirectToAction("List");
    }

    [HttpGet]
    public IActionResult Add() 
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Dog dog) 
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        
        _dogRepository.CreateDog(dog);

        return RedirectToAction("Detail", new {id = dog.DogId});
    }

    public IActionResult Delete(int id) 
    {
        _dogRepository.DeleteDogById(id);
        
        return RedirectToAction("List");
    }
}
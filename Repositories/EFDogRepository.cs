using midterm_project.Migrations;
using midterm_project.Models;

namespace midterm_project.Repositories;

public class EFDogRepository : IDogRepository
{
    private readonly DogDbContext _context;

    public EFDogRepository(DogDbContext context)
    {
        _context = context;
    }

    public Dog CreateDog(Dog newDog)
    {
        _context.Dog.Add(newDog);
        _context.SaveChanges();
        return newDog;
    }

    public void DeleteDogById(int dogId)
    {
        var dog = _context.Dog.Find(dogId); 
        if (dog != null) {
            _context.Dog.Remove(dog); 
            _context.SaveChanges(); 
        }
    }

    public IEnumerable<Dog> GetAllDogs()
    {
        return _context.Dog.ToList();
    }

    public Dog? GetDogById(int dogId)
    {
        return _context.Dog.SingleOrDefault(c => c.DogId == dogId);
    }

    public Dog? UpdateDog(Dog newDog)
    {
        var originalDog = _context.Dog.Find(newDog.DogId);
        if (originalDog != null) {
            originalDog.Name = newDog.Name;
            originalDog.Breed = newDog.Breed;
            originalDog.Gendre = newDog.Gendre;
            originalDog.Description = newDog.Description;
            _context.SaveChanges();
        }
        return originalDog;
    }
}
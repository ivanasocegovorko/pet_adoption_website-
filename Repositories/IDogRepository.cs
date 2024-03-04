using midterm_project.Models;

namespace midterm_project.Repositories;
public interface IDogRepository {
    IEnumerable<Dog> GetAllDogs();
    Dog? GetDogById(int dogId);
    Dog CreateDog(Dog dog);
    Dog? UpdateDog(Dog dog);
    void DeleteDogById(int dogId);
}
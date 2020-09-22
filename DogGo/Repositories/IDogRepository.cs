using DogGo.Models;
using System.Collections.Generic;

namespace DogGo.Repositories
{
    public interface IDogRepository
    {
        List<Dog> GetAllDogs();
        Dog GetDogsById(int id);
        List<Dog> GetDogsByOwnerId(int ownerId);


    }
}
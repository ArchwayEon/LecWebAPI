using LecWebAPI.Models.Entities;

namespace LecWebAPI.Services;

public interface IPetRepository
{
    IEnumerable<Pet> ReadAll();
    Pet? Read(int id);
    Pet Create(Pet pet);
    void Update(int oldId, Pet updatedPet);
    void Delete(int id);
}



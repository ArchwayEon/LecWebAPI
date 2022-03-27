using LecWebAPI.Models.Entities;

namespace LecWebAPI.Services;

public class IMPetRepository : IPetRepository
{
    // Assume this is the database
    private static ICollection<Pet> _pets = new List<Pet>
   {
      new Pet {Id=1, Name="Betsy", Weight=250.0f },
      new Pet {Id=2, Name="Polly", Weight=2.5f },
      new Pet {Id=3, Name="Rex", Weight=43.0f }
   };

    public IEnumerable<Pet> ReadAll()
    {
        return _pets.ToList();
    }

    public Pet? Read(int id)
    {
        return _pets.FirstOrDefault(p => p.Id == id);
    }

    public Pet Create(Pet pet)
    {
        _pets.Add(pet);
        return pet;
    }

    public void Update(int oldId, Pet updatedPet)
    {
        var petToUpdate = Read(oldId);
        if(petToUpdate != null)
        {
            petToUpdate.Name = updatedPet.Name;
            petToUpdate.Weight = updatedPet.Weight;
            // Since we are using in-memory data, there is no
            // need to commit
        }
    }

    public void Delete(int id)
    {
        var petToDelete = Read(id);
        if(petToDelete != null)
        {
            _pets.Remove(petToDelete);
            // Since we are using in-memory data, there is no
            // need to commit
        }
    }

}



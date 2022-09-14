using LecWebAPI.Models.Entities;

namespace LecWebAPI.Services;

public class DbPetRepository : IPetRepository
{
    private ApplicationDbContext _db;

    public DbPetRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public Pet Create(Pet pet)
    {
        _db.Pets.Add(pet);
        _db.SaveChanges();
        return pet;
    }

    public void Delete(int id)
    {
        var petToDelete = Read(id);
        if (petToDelete != null)
        {
            _db.Pets.Remove(petToDelete);
            _db.SaveChanges();
        }

    }

    public Pet? Read(int id)
    {
        return _db.Pets.Find(id);
    }

    public IEnumerable<Pet> ReadAll()
    {
        return _db.Pets.ToList();
    }

    public void Update(int oldId, Pet updatedPet)
    {
        var petToUpdate = Read(oldId);
        if (petToUpdate != null)
        {
            petToUpdate.Name = updatedPet.Name;
            petToUpdate.Weight = updatedPet.Weight;
            _db.SaveChanges();
        }
    }
}

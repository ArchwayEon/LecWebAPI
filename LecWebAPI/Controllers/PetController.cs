using LecWebAPI.Models.Entities;
using LecWebAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LecWebAPI.Controllers;

[EnableCors]
[Route("api/[controller]")]
[ApiController]
public class PetController : ControllerBase
{
    private readonly IPetRepository _petRepo;

    public PetController(IPetRepository petRepo)
    {
        _petRepo = petRepo;
    }

    [HttpGet("all")]
    public IActionResult Get()
    {
        return Ok(_petRepo.ReadAll());
    }

    [HttpGet("one/{id}")]
    public IActionResult Get(int id)
    {
        var pet = _petRepo.Read(id);
        if (pet == null)
        {
            return NotFound();
        }
        return Ok(pet);
    }

    [HttpPost("create")]
    public IActionResult Post([FromForm] Pet pet)
    {
        _petRepo.Create(pet);
        return CreatedAtAction("Get", new { id = pet.Id }, pet);
    }

    [HttpPut("update")]
    public IActionResult Put([FromForm] Pet pet)
    {
        _petRepo.Update(pet.Id, pet);
        return NoContent(); // 204 as per HTTP specification
    }

    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        _petRepo.Delete(id);
        return NoContent(); // 204 as per HTTP specification
    }


}


using EntityFrameworkClase3.Models;
using EntityFrameworkClase3.Services;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkClase3.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepository _repository;

    public UsuarioController(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var student = _repository.GetById(id);

        if (student == null)
            return NotFound();

        return Ok(student);
    }

    [HttpPost]
    public IActionResult Create(Usuario student)
    {
        _repository.Add(student);
        _repository.Save();

        return CreatedAtAction(
            nameof(GetById),
            new { id = student.Id },
            student
        );
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var eliminado = _repository.Delete(id);

        if (!eliminado)
            return NotFound();

        return NoContent();
    }
}
using AlunoGestao.Models;
using AlunoGestao.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlunoGestao.Controllers;

[ApiController]
[Route("[controller]")]
public class AlunoGestao : ControllerBase
{
    public AlunoGestao()
    {
    }

    [HttpGet]
    public ActionResult<List<Aluno>> GetAll() =>
    AlunoService.GetAll();

   [HttpGet("{id}")]
   public ActionResult<Aluno> Get(int id)
   {
    var aluno = AlunoService.Get(id);

    if(aluno == null)
        return NotFound();

    return aluno;
}

   [HttpPost]
   public IActionResult Create(Aluno aluno)
{            
    AlunoService.Add(aluno);
    return CreatedAtAction(nameof(Create), new { id = aluno.Id }, aluno);
}

    [HttpPut("{id}")]
    public IActionResult Update(int id, Aluno aluno)
{
    if (id != aluno.Id)
        return BadRequest();
           
    var existingAluno= AlunoService.Get(id);
    if(existingAluno is null)
        return NotFound();
   
    AlunoService.Update(aluno);           
   
    return NoContent();
}

   [HttpDelete("{id}")]
   public IActionResult Delete(int id)
{
    var aluno = AlunoService.Get(id);
   
    if (aluno is null)
        return NotFound();
       
    AlunoService.Delete(id);
   
    return NoContent();
}
}
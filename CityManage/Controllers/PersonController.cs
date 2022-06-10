using CityManage.DAL;
using CityManage.Exceptions;
using CityManage.Interfaces;
using CityManage.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityManage.Controllers;

[ApiController]
[Route("person")]
public class PersonController :  ControllerBase
{
    private readonly IRepository<Person> _repository;

    public PersonController(CityDbContext context)
    {
        _repository = new Repository<Person>(context);
    }

    [HttpGet]
    public async Task<ActionResult<Person>> Get()
    {
        try {
            var result = await _repository.GetAsync();
            return Ok(result);
        }
        catch (NotFoundException) {
            return NotFound();
        }
    }
    
    [HttpPut]
    public async Task<ActionResult<Guid>> Create([FromBody]Person person)
    {
        var result = await _repository.CreateAsync(person);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<Guid>> Update([FromBody]Person person)
    {
        try {
            var result = await _repository.UpdateAsync(person);
            return Ok(result);
        }
        catch (NotFoundException) {
            return NotFound();
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<Guid>> Delete([FromRoute]Guid id)
    {
        var result = await _repository.DeleteAsync(id);
        return Ok(result);
    }
}
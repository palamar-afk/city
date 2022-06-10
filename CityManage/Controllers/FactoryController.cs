using CityManage.DAL;
using CityManage.Exceptions;
using CityManage.Interfaces;
using CityManage.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityManage.Controllers;

[ApiController]
[Route("factory")]
public class FactoryController :  ControllerBase
{
    private readonly IRepository<Factory> _repository;

    public FactoryController(CityDbContext context)
    {
        _repository = new Repository<Factory>(context);
    }

    [HttpGet]
    public async Task<ActionResult<Country>> Get()
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
    public async Task<ActionResult<Guid>> Create([FromBody]Factory factory)
    {
        var result = await _repository.CreateAsync(factory);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<Guid>> Update([FromBody]Factory factory)
    {
        try {
            var result = await _repository.UpdateAsync(factory);
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
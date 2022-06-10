using CityManage.DAL;
using CityManage.Exceptions;
using CityManage.Interfaces;
using CityManage.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityManage.Controllers;

[ApiController]
[Route("street")]
public class StreetController :  ControllerBase
{
    private readonly IRepository<Street> _repository;

    public StreetController(CityDbContext context)
    {
        _repository = new Repository<Street>(context);
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
    public async Task<ActionResult<Guid>> Create([FromBody]Street street)
    {
        var result = await _repository.CreateAsync(street);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<Guid>> Update([FromBody]Street street)
    {
        try {
            var result = await _repository.UpdateAsync(street);
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
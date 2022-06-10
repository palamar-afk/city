using CityManage.DAL;
using CityManage.Exceptions;
using CityManage.Interfaces;
using CityManage.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityManage.Controllers;

[ApiController]
[Route("city")]
public class CityController :  ControllerBase
{
    private readonly IRepository<City> _repository;

    public CityController(CityDbContext context)
    {
        _repository = new Repository<City>(context);
    }

    [HttpGet]
    public async Task<ActionResult<City>> Get()
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
    public async Task<ActionResult<Guid>> Create([FromBody]City city)
    {
        var result = await _repository.CreateAsync(city);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<Guid>> Update([FromBody]City city)
    {
        try {
            var result = await _repository.UpdateAsync(city);
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
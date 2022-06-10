using CityManage.DAL;
using CityManage.Exceptions;
using CityManage.Interfaces;
using CityManage.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityManage.Controllers;

[ApiController]
[Route("district")]
public class DistrictController :  ControllerBase
{
    private readonly IRepository<District> _repository;

    public DistrictController(CityDbContext context)
    {
        _repository = new Repository<District>(context);
    }

    [HttpGet]
    public async Task<ActionResult<District>> Get()
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
    public async Task<ActionResult<Guid>> Create([FromBody]District district)
    {
        var result = await _repository.CreateAsync(district);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<Guid>> Update([FromBody]District district)
    {
        try {
            var result = await _repository.UpdateAsync(district);
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
namespace WebApi.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PfProj.Models.CharacterClasses;
using PfProj.Services;

[ApiController]
[Route("[controller]")]
public class CharacterClassesController : ControllerBase
{
    private ISharedService _ModelService;
    private IMapper _mapper;

    public CharacterClassesController(
        ISharedService ModelService,
        IMapper mapper)
    {
        _ModelService = ModelService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var models = _ModelService.GetAll();
        return Ok(models);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var models = _ModelService.GetById(id);
        return Ok(models);
    }

    [HttpPost]
    public IActionResult Create(CreateRequest model)
    {
        if (_ModelService.Create(model))
            return Ok(new { message = "Created Model" });
        else 
            return Ok(new { message = "Client-side Error" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateRequest model)
    {
        if (_ModelService.Update(id, model))
            return Ok(new { message = "Updated" });
        else 
            return Ok(new { message = "Client-side Error" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _ModelService.Delete(id);
        return Ok(new { message = "Deleted" });
    }
}
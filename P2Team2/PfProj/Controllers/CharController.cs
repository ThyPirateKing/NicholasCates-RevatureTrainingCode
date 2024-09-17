namespace WebApi.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PfProj.Models.Characters;
using PfProj.Services;

[ApiController]
[Route("[controller]")]
public class CharactersController : ControllerBase
{
    private ISharedService _ModelService;
    private IMapper _mapper;

    public CharactersController(
        ISharedService ModelService,
        IMapper mapper)
    {
        _ModelService = ModelService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var models = _ModelService.GetAllChar();
        return Ok(models);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var models = _ModelService.GetByIdChar(id);
        return Ok(models);
    }

    [HttpPost]
    public IActionResult Create(CreateRequestChar model)
    {
        if (_ModelService.CreateChar(model))
            return Ok(new { message = "Created Model" });
        else 
            return Ok(new { message = "Client-side Error" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateRequestChar model)
    {
        if (_ModelService.UpdateChar(id, model))
            return Ok(new { message = "Updated" });
        else 
            return Ok(new { message = "Client-side Error" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _ModelService.DeleteChar(id);
        return Ok(new { message = "Deleted" });
    }
}
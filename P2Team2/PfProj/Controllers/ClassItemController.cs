namespace WebApi.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PfProj.Models.CharacterClassItems;
using PfProj.Services;

[ApiController]
[Route("[controller]")]
public class CharacterClassItemsController : ControllerBase
{
    private ISharedService _ModelService;
    private IMapper _mapper;

    public CharacterClassItemsController(
        ISharedService ModelService,
        IMapper mapper)
    {
        _ModelService = ModelService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAllClassItem()
    {
        var models = _ModelService.GetAllClassItem();
        return Ok(models);
    }

    [HttpGet("{id}")]
    public IActionResult GetByIdClassItem(int id)
    {
        var models = _ModelService.GetByIdClassItem(id);
        return Ok(models);
    }

    [HttpPost]
    public IActionResult CreateClassItem(CreateRequestClassItem model)
    {
        if (_ModelService.CreateClassItem(model))
            return Ok(new { message = "Created Model" });
        else 
            return Ok(new { message = "Client-side Error" });
    }

    [HttpPut("{id}")]
    public IActionResult UpdateClassItem(int id, UpdateRequestClassItem model)
    {
        if (_ModelService.UpdateClassItem(id, model))
            return Ok(new { message = "Updated" });
        else 
            return Ok(new { message = "Client-side Error" });
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteClassItem(int id)
    {
        _ModelService.DeleteClassItem(id);
        return Ok(new { message = "Deleted" });
    }
}
namespace WebApi.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PfProj.Models.Items;
using PfProj.Services;
//using PfProj.Entities;

[ApiController]
[Route("[controller]")]
public class ItemsController : ControllerBase
{
    private ISharedService _ModelService;
    private IMapper _mapper;

    public ItemsController(
        ISharedService ModelService,
        IMapper mapper)
    {
        _ModelService = ModelService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAllItem()
    {
        var models = _ModelService.GetAllItem();
        return Ok(models);
    }

    [HttpGet("{id}")]
    public IActionResult GetByIdItem(int id)
    {
        var models = _ModelService.GetByIdItem(id);
        return Ok(models);
    }

    [HttpPost]
    public IActionResult CreateItem(CreateRequestItem model)
    {
        if (_ModelService.CreateItem(model))
            return Ok(new { message = "Created Model" });
        else 
            return Ok(new { message = "Client-side Error" });
    }

    [HttpPut("{id}")]
    public IActionResult UpdateItem(int id, UpdateRequestItem model)
    {
        if (_ModelService.UpdateItem(id, model))
            return Ok(new { message = "Updated" });
        else 
            return Ok(new { message = "Client-side Error" });
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteItem(int id)
    {
        _ModelService.DeleteItem(id);
        return Ok(new { message = "Deleted" });
    }

    public IActionResult EquipItem(EquipRequestItem model)
    {
        if (_ModelService.EquipItem(model))
            return Ok(new { message = "Updated" });
        else 
            return Ok(new { message = "Client-side Error" });
    }
}
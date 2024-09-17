namespace PfProj.Services;

using AutoMapper;
using PfProj.Entities;
using PfProj.Helpers;
using PfProj.Models.CharacterClasses;
using PfProj.Models.Characters;
using PfProj.Models.CharacterClassItems;
using PfProj.Models.Items;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

public interface ISharedService
{
    // Character Classes
    IEnumerable<CharacterClass> GetAll();
    CharacterClass GetById(int id);
    bool Create(CreateRequest model);
    bool Update(int id, UpdateRequest model);
    void Delete(int id);

    // Characters
    IEnumerable<Character> GetAllChar();
    Character GetByIdChar(int id);
    bool CreateChar(CreateRequestChar model);
    bool UpdateChar(int id, UpdateRequestChar model);
    void DeleteChar(int id);

    // Class Items
    IEnumerable<CharacterClassItem> GetAllClassItem();
    CharacterClassItem GetByIdClassItem(int id);
    bool CreateClassItem(CreateRequestClassItem model);
    bool UpdateClassItem(int id, UpdateRequestClassItem model);
    void DeleteClassItem(int id);

    // Items
    IEnumerable<Item> GetAllItem();
    Item GetByIdItem(int id);
    bool CreateItem(CreateRequestItem model);
    bool UpdateItem(int id, UpdateRequestItem model);
    void DeleteItem(int id);
    bool EquipItem(EquipRequestItem model);
}

public class ModelService : ISharedService
{
    private DataContext _context;
    private readonly IMapper _mapper;
    private intermediateServices interService = new();

    public ModelService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    // ***** CHAR CLASS *****
    public IEnumerable<CharacterClass> GetAll()
    {
        return _context.CharacterClasses;
    }

    public CharacterClass GetById(int id)
    {
        return getModel(id);
    }

    public bool Create(CreateRequest model)
    {
        // map model to new object
        var target = _mapper.Map<CharacterClass>(model); // target is now an entity

        // manipulate data here
        // get entity attributes through target.X

        // save to datacontext
        _context.CharacterClasses.Add(target);
        _context.SaveChanges();
        return true;
    }
    public bool Update(int id, UpdateRequest model)
    {
        var targetId = getModel(id);
        var target = _mapper.Map(model, targetId); // target is now an entity

        // manipulate data here
        // get entity attributes through target.X

        // update
        _context.CharacterClasses.Update(targetId);
        _context.SaveChanges();
        return true;
    }

    public void Delete(int id)
    {
        var target = getModel(id);
        _context.CharacterClasses.Remove(target);
        _context.SaveChanges();
    }

    // helper methods

    private CharacterClass getModel(int id)
    {
        var target = _context.CharacterClasses.Find(id);
        if (target == null) throw new KeyNotFoundException("ID not found");
            return target;
    }

    // ***** CHAR *****

    public IEnumerable<Character> GetAllChar()
    {
        return _context.Characters;
    }

    public Character GetByIdChar(int id)
    {
        return getModelChar(id);
    }

    public bool CreateChar(CreateRequestChar model)
    {
        // map model to new object
        var target = _mapper.Map<Character>(model); // target is now an entity

        // manipulate data here
        try {
        target = interService.UpdateAttributes(target);
        target = interService.UpdateStats(target);
        } catch (Exception e) {
            Console.WriteLine("Inermediate Services Exception: " + e);
        }
        // get entity attributes through target.X

        // save to datacontext
        _context.Characters.Add(target);
        _context.SaveChanges();
        return true;
    }

    public bool UpdateChar(int id, UpdateRequestChar model)
    {
        var targetId = getModelChar(id);
        var target = _mapper.Map(model, targetId); // target is now an entity

        // manipulate data here
        try {
        target = interService.UpdateAttributes(target);
        target = interService.UpdateStats(target);
        } catch (Exception e) {
            Console.WriteLine("Inermediate Services Exception: " + e);
        }
        // get entity attributes through target.X

        // update
        _context.Characters.Update(targetId);
        _context.SaveChanges();
        return true;
    }

    public void DeleteChar(int id)
    {
        var target = getModelChar(id);
        _context.Characters.Remove(target);
        _context.SaveChanges();
    }

    // helper methods

    private Character getModelChar(int id)
    {
        var target = _context.Characters.Find(id);
        if (target == null) throw new KeyNotFoundException("ID not found");
            return target;
    }

    // ***** CHAR ITEM CLASS *****

    public IEnumerable<CharacterClassItem> GetAllClassItem()
    {
        return _context.CharacterClassItems;
    }

    public CharacterClassItem GetByIdClassItem(int id)
    {
        return getModelClassItem(id);
    }

    public bool CreateClassItem(CreateRequestClassItem model)
    {
        // map model to new object
        var target = _mapper.Map<CharacterClassItem>(model); // target is now an entity

        // manipulate data here
        // get entity attributes through target.X

        // save to datacontext
        _context.CharacterClassItems.Add(target);
        _context.SaveChanges();
        return true;
    }
    public bool UpdateClassItem(int id, UpdateRequestClassItem model)
    {
        var targetId = getModelClassItem(id);
        var target = _mapper.Map(model, targetId); // target is now an entity

        // manipulate data here
        // get entity attributes through target.X

        // update
        _context.CharacterClassItems.Update(targetId);
        _context.SaveChanges();
        return true;
    }

    public void DeleteClassItem(int id)
    {
        var target = getModelClassItem(id);
        _context.CharacterClassItems.Remove(target);
        _context.SaveChanges();
    }

    // helper methods

    private CharacterClassItem getModelClassItem(int id)
    {
        var target = _context.CharacterClassItems.Find(id);
        if (target == null) throw new KeyNotFoundException("ID not found");
            return target;
    }

    // ***** ITEM CLASS *****

    public IEnumerable<Item> GetAllItem()
    {
        return _context.Items;
    }

    public Item GetByIdItem(int id)
    {
        return getModelItem(id);
    }

    public bool CreateItem(CreateRequestItem model)
    {
        // map model to new object
        var target = _mapper.Map<Item>(model); // target is now an entity

        // manipulate data here
        // get entity attributes through target.X

        // save to datacontext
        _context.Items.Add(target);
        _context.SaveChanges();
        return true;
    }
    public bool UpdateItem(int id, UpdateRequestItem model)
    {
        var targetId = getModelItem(id);
        var target = _mapper.Map(model, targetId); // target is now an entity

        // manipulate data here
        // get entity attributes through target.X

        // update
        _context.Items.Update(targetId);
        _context.SaveChanges();
        return true;
    }
    [HttpDelete]
    public void DeleteItem(int id)
    {
        var target = getModelItem(id);
        _context.Items.Remove(target);
        _context.SaveChanges();
    }

    // helper methods

    private Item getModelItem(int id)
    {
        var target = _context.Items.Find(id);
        if (target == null) throw new KeyNotFoundException("ID not found");
            return target;
    }
    // EQ & UnEQ
    public bool EquipItem(EquipRequestItem model){
        var target = _mapper.Map<Item>(model);
        int characterID = target.characterID.GetValueOrDefault(-1);
        if (target.characterID != -1){
            Character character = GetByIdChar(characterID);
            target = interService.EquipItem(target, character);
            // here we would update DB, but we can't put/patch without ID
            return target.isEquipped.GetValueOrDefault(false);
        }
        return false;
    }
}

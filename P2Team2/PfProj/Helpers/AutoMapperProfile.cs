namespace PfProj.Helpers;

using AutoMapper;
using PfProj.Entities;
using PfProj.Models.CharacterClasses;
using PfProj.Models.Characters;
using PfProj.Models.CharacterClassItems;
using PfProj.Models.Items;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // CreateRequest -> Model
        CreateMap<CreateRequest, CharacterClass>(); // char class
        CreateMap<CreateRequestChar, Character>();
        CreateMap<CreateRequestClassItem, CharacterClassItem>();
        CreateMap<CreateRequestItem, Item>();

        // UpdateRequest -> Model
        CreateMap<UpdateRequest, CharacterClass>(); // char class
        CreateMap<UpdateRequestChar, Character>();
        CreateMap<UpdateRequestClassItem, CharacterClassItem>();
        CreateMap<UpdateRequestItem, Item>();

        // Special Requests
        CreateMap<EquipRequestItem, Item>();
    }
}
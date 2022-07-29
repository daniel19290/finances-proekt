using AutoMapper;
using TransactionAPI.Commands;
using TransactionAPI.Database.Entities;
using TransactionAPI.Models;

namespace TransactionAPI.Mappings
{
    public class AutoMapper: Profile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TransactionEntity, Models.Transaction>()
                .ForMember(d => d.TransactionId, opts => opts.MapFrom(s => s.Id));

            CreateMap<PagedSortedList<TransactionEntity>, PagedSortedList<Models.Transaction>>();
            
            CreateMap<CreateTransactionCommand, TransactionEntity>()
                .ForMember(d => d.Id, opts => opts.MapFrom(s => s.TransactionId));
                
            CreateMap<CategoryEntity, Models.Category>()
                .ForMember(d => d.Code, opts => opts.MapFrom(s => s.Ccode));

            CreateMap<PagedSortedList<CategoryEntity>, PagedSortedList<Models.Category>>();
            
            CreateMap<CreateCategoryCommand, CategoryEntity>()
                .ForMember(d => d.Ccode, opts => opts.MapFrom(s => s.Code));
        }
    }
}
}
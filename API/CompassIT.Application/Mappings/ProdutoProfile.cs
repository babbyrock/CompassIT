using AutoMapper;
using CompassIT.Application.DTOs;
using CompassIT.Domain.Entities;

namespace CompassIT.Application.Mappings
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {

            CreateMap<Produto, ProdutoDTO>();
        }
    }
}

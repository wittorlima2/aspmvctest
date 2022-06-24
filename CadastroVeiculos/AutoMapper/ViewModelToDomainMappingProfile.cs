using AutoMapper;
using CadastroVeiculos.Domain.Entities;
using CadastroVeiculos.Models;

namespace CadastroVeiculos.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<VeiculoViewModel, Veiculo>().ReverseMap();
            CreateMap<MarcaViewModel, Marca>().ReverseMap();
            CreateMap<ProprietarioViewModel, Proprietario>().ReverseMap();
        }
    }
}

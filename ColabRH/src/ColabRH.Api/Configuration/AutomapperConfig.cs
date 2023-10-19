using AutoMapper;

namespace ColabRH.Api.Configuration;

public class AutomapperConfig : Profile
{
    public AutomapperConfig()
    {
        //CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
        //CreateMap<GrupoEconomico, EnderecoViewModel>().ReverseMap();
        
        //CreateMap<ProdutoImagemViewModel, Produto>().ReverseMap();
        //CreateMap<Produto, ProdutoViewModel>()
        //    .ForMember(dest => dest.NomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.Nome));
    }
}
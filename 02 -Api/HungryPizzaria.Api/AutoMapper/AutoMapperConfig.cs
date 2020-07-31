using System;

using AutoMapper;


namespace HungryPizzaria.Api.AutoMapper
{
    public partial class AutoMapperConfig : Profile
    {

        public AutoMapperConfig()
        {


            #region Projeto

            CreateMap<Domain.Operation.Commands.Projeto.SaveCliente, Domain.Operation.Entities.Projeto.Cliente>()
                .ForMember(x => x.DTINCLUSAO, opt => opt.Ignore())
                .ForMember(x => x.DTALTERACAO, opt => opt.Ignore());

            CreateMap<Domain.Operation.Commands.Projeto.SavePedidos, Domain.Operation.Entities.Projeto.Pedidos>()
                .ForMember(x => x.DTINCLUSAO, opt => opt.Ignore());

            CreateMap<Domain.Operation.Commands.Projeto.SaveItensPedido, Domain.Operation.Entities.Projeto.ItensPedido>()
               .ForMember(x => x.DTINCLUSAO, opt => opt.Ignore());

            CreateMap<Domain.Operation.Commands.Projeto.SavePizzaSabores, Domain.Operation.Entities.Projeto.PizzaSabores>()
               .ForMember(x => x.DTINCLUSAO, opt => opt.Ignore())
                .ForMember(x => x.DTALTERACAO, opt => opt.Ignore());

            #endregion


        }

    }
}

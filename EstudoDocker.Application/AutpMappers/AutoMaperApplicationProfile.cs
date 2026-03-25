
using AutoMapper;
using EstudoDocker.Application.Request;
using EstudoDocker.Application.Response;
using EstudoDocker.Domain.Dto;
using EstudoDocker.Domain.Kafka;


namespace EstudoDocker.Application.AutpMappers
{
    public class AutoMaperApplicationProfile:Profile
    {
        public AutoMaperApplicationProfile()
        {
            CreateMap<PessoaRequest, PesssoaMensagem>()
                .ForMember(dest => dest.TipoOperacao, opt => opt.Ignore());
            CreateMap<PesssoaDto, PessoaResponse>();
        }
    }
}

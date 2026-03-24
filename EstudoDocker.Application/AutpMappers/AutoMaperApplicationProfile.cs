
using AutoMapper;
using EstudoDocker.Application.Request;
using EstudoDocker.Application.Response;
using EstudoDocker.Domain.Dto;


namespace EstudoDocker.Application.AutpMappers
{
    public class AutoMaperApplicationProfile:Profile
    {
        public AutoMaperApplicationProfile()
        {
            CreateMap<PessoaRequest, PesssoaDto>();
            CreateMap<PesssoaDto, PessoaResponse>();
        }
    }
}

using AutoMapper;
using EstudoDocker.Domain.Dto;
using EstudoDocker.Domain.Model;

namespace EstudoDocker.DataBase.AutoMappers
{
    public class AutoMaperDataProfile: Profile
    {
        public AutoMaperDataProfile()
        {
            CreateMap<Pesssoa, PesssoaDto>().ReverseMap();
        }
    }
}

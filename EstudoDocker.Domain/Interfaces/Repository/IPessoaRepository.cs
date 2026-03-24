using EstudoDocker.Domain.Dto;
using EstudoDocker.Domain.Model;

namespace EstudoDocker.Domain.Interfaces.Repository
{
    public interface IPessoaRepository
    {
        Task<IEnumerable<PesssoaDto>> GetAllAsync();
        Task<PesssoaDto> GetByIdAsync(Guid id);
        Task AddAsync(PesssoaDto pesssoa);
        Task UpdateAsync(PesssoaDto pesssoa);
        Task DeleteAsync(PesssoaDto pesssoa);
        Task DeleteAsync(Guid id);
    }
}

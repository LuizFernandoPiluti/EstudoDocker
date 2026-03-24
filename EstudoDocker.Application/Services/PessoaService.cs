
using AutoMapper;
using EstudoDocker.Application.Interfaces;
using EstudoDocker.Application.Request;
using EstudoDocker.Application.Response;
using EstudoDocker.Domain.Dto;
using EstudoDocker.Domain.Interfaces.Repository;

namespace EstudoDocker.Application.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;
        public PessoaService(IPessoaRepository pessoaRepository,IMapper mapper)
        {
            _pessoaRepository = pessoaRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(PessoaRequest pesssoa)
        {
            try
            {
                var pessoa = _mapper.Map<PesssoaDto>(pesssoa);
               await _pessoaRepository.AddAsync(pessoa).ConfigureAwait(false);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _pessoaRepository.DeleteAsync(id).ConfigureAwait(false);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<PessoaResponse>> GetAllAsync()
        {
            try
            {
                var pessoas = await _pessoaRepository.GetAllAsync().ConfigureAwait(false);
                return _mapper.Map<List<PessoaResponse>>(pessoas);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PessoaResponse> GetByIdAsync(Guid id)
        {
            try
            {
                var pessoa =  await _pessoaRepository.GetByIdAsync(id).ConfigureAwait(false);
                return _mapper.Map<PessoaResponse>(pessoa);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(PessoaRequest pesssoa)
        {
            var pessoa = _mapper.Map<PesssoaDto>(pesssoa);
            await _pessoaRepository.AddAsync(pessoa).ConfigureAwait(false);
        }
    }
}

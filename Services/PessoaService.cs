using AutoMapper;
using Domain.CommandHandlers;
using Domain.Core;
using Domain.Interfaces.Generics;
using Services.Interfaces;
using Services.ViewModels;

namespace Services.Services
{
    public class PessoaService : IPessoasService
    {
        private readonly IMapper _mapper;
        private readonly IPessoaRepository _repository;
        private readonly IMediatorHandler Bus;

        public PessoaService(IMapper mapper,
                                  IPessoaRepository repository,
                                  IMediatorHandler bus)
        {
            _mapper = mapper;
            _repository = repository;
            Bus = bus;
        }
        public async Task<IList<PessoasViewModel>> GetAllAsync()
        {
            return _mapper.Map<IList<PessoasViewModel>>(_repository.GetAll());
        }

        public async Task<PessoasViewModel> GetByIdAsync(int id)
        {
            return _mapper.Map<PessoasViewModel>(_repository.GetById(id));
        }

        public async Task RegisterAsync(PessoasViewModel record)
        {
            var registerCommand = _mapper.Map<NewPessoaCommand>(record);
            await Bus.SendCommand(registerCommand);
        }

        public async Task UpdateAsync(PessoasViewModel record)
        {
            var updateCommand = _mapper.Map<UpdatePessoaCommand>(record);
            await Bus.SendCommand(updateCommand);
        }

        public async Task RemoveAsync(int id)
        {
            var removeCommand = new RemovePessoaCommand(id);
            await Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

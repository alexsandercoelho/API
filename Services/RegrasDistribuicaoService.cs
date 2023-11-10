using AutoMapper;
using Domain.CommandHandlers;
using Domain.Core;
using Domain.Interfaces.Generics;
using Services.Interfaces;
using Services.ViewModels;

namespace Services.Services
{
    public class RegrasDistribuicaoService : IRegrasDistribuicaoService
    {
        private readonly IMapper _mapper;
        private readonly IRegrasDistribuicaoRepository _repository;
        private readonly IMediatorHandler Bus;

        public RegrasDistribuicaoService(IMapper mapper,
                                  IRegrasDistribuicaoRepository repository,
                                  IMediatorHandler bus)
        {
            _mapper = mapper;
            _repository = repository;
            Bus = bus;
        }
        public async Task<IList<RegrasDistribuicaoViewModel>> GetAllAsync()
        {
            return _mapper.Map<IList<RegrasDistribuicaoViewModel>>(_repository.GetAll());
        }

        public async Task<RegrasDistribuicaoViewModel> GetByIdAsync(int id)
        {
            return _mapper.Map<RegrasDistribuicaoViewModel>(_repository.GetById(id));
        }

        public async Task RegisterAsync(RegrasDistribuicaoViewModel record)
        {
            var registerCommand = _mapper.Map<NewRegrasDistribuicaoCommand>(record);
            await Bus.SendCommand(registerCommand);
        }

        public async Task UpdateAsync(RegrasDistribuicaoViewModel record)
        {
            var updateCommand = _mapper.Map<UpdateRegrasDistribuicaoCommand>(record);
            await Bus.SendCommand(updateCommand);
        }

        public async Task RemoveAsync(int id)
        {
            var removeCommand = new RemoveRegrasDistribuicaoCommand(id);
            await Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

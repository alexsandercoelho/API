using AutoMapper;
using Domain.CommandHandlers;
using Domain.Core;
using Domain.Interfaces.Generics;
using Services.Interfaces;
using Services.ViewModels;

namespace Services.Services
{
    public class GrupoDistribuicaoService : IGrupoDistribuicaoService
    {
        private readonly IMapper _mapper;
        private readonly IGrupoDistribuicaoRepository _repository;
        private readonly IMediatorHandler Bus;

        public GrupoDistribuicaoService(IMapper mapper,
                                  IGrupoDistribuicaoRepository repository,
                                  IMediatorHandler bus)
        {
            _mapper = mapper;
            _repository = repository;
            Bus = bus;
        }
        public async Task<IList<GrupoDistribuicaoViewModel>> GetAllAsync()
        {
            return _mapper.Map<IList<GrupoDistribuicaoViewModel>>(_repository.GetAll());
        }

        public async Task<GrupoDistribuicaoViewModel> GetByIdAsync(int id)
        {
            return _mapper.Map<GrupoDistribuicaoViewModel>(_repository.GetById(id));
        }

        public async Task RegisterAsync(GrupoDistribuicaoViewModel record)
        {
            var registerCommand = _mapper.Map<NewGrupoDistribuicaoCommand>(record);
            await Bus.SendCommand(registerCommand);
        }

        public async Task UpdateAsync(GrupoDistribuicaoViewModel record)
        {
            var updateCommand = _mapper.Map<UpdateGrupoDistribuicaoCommand>(record);
            await Bus.SendCommand(updateCommand);
        }

        public async Task RemoveAsync(int id)
        {
            var removeCommand = new RemoveGrupoDistribuicaoCommand(id);
            await Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

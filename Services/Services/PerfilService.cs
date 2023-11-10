using AutoMapper;
using Domain.CommandHandlers;
using Domain.Core;
using Domain.Interfaces.Generics;
using Services.Interfaces;
using Services.ViewModels;

namespace Services.Services
{
    public class PerfilService : IPerfilService
    {
        private readonly IMapper _mapper;
        private readonly IPerfilRepository _repository;
        private readonly IMediatorHandler Bus;

        public PerfilService(IMapper mapper,
                                  IPerfilRepository repository,
                                  IMediatorHandler bus)
        {
            _mapper = mapper;
            _repository = repository;
            Bus = bus;
        }
        public async Task<IList<PerfilViewModel>> GetAllAsync()
        {
            return _mapper.Map<IList<PerfilViewModel>>(_repository.GetAll());
        }

        public async Task<PerfilViewModel> GetByIdAsync(int id)
        {
            return _mapper.Map<PerfilViewModel>(_repository.GetById(id));
        }

        public async Task RegisterAsync(PerfilViewModel record)
        {
            var registerCommand = _mapper.Map<NewPerfilCommand>(record);
            await Bus.SendCommand(registerCommand);
        }

        public async Task UpdateAsync(PerfilViewModel record)
        {
            var updateCommand = _mapper.Map<UpdatePerfilCommand>(record);
            await Bus.SendCommand(updateCommand);
        }

        public async Task RemoveAsync(int id)
        {
            var removeCommand = new RemovePerfilCommand(id);
            await Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Task<FuncionalidadeViewModel> GetFuncionalidadesAsync()
        {
            throw new NotImplementedException();
        }
    }
}

using AutoMapper;
using Domain.CommandHandlers;
using Domain.Core;
using Domain.Interfaces.Generics;
using Services.Interfaces;
using Services.ViewModels;

namespace Services.Services
{
    public class FuncionalidadeService : IFuncionalidadeService
    {
        private readonly IMapper _mapper;
        private readonly IFuncionalidadeRepository _repository;
        private readonly IMediatorHandler Bus;

        public FuncionalidadeService(IMapper mapper,
                                  IFuncionalidadeRepository repository,
                                  IMediatorHandler bus)
        {
            _mapper = mapper;
            _repository = repository;
            Bus = bus;
        }
        public async Task<IList<FuncionalidadeViewModel>> GetAllAsync()
        {
            return _mapper.Map<IList<FuncionalidadeViewModel>>(_repository.GetAll());
        }

        public async Task<FuncionalidadeViewModel> GetByIdAsync(int id)
        {
            return _mapper.Map<FuncionalidadeViewModel>(_repository.GetById(id));
        }

        public async Task RegisterAsync(FuncionalidadeViewModel record)
        {
            var registerCommand = _mapper.Map<NewFuncionalidadeCommand>(record);
            await Bus.SendCommand(registerCommand);
        }

        public async Task UpdateAsync(FuncionalidadeViewModel record)
        {
            var updateCommand = _mapper.Map<UpdateFuncionalidadeCommand>(record);
            await Bus.SendCommand(updateCommand);
        }

        public async Task RemoveAsync(int id)
        {
            var removeCommand = new RemoveFuncionalidadeCommand(id);
            await Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

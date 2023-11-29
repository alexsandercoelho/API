using AutoMapper;
using Domain;
using Domain.Common;
using Domain.DTOs;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Services;

namespace Services;

public class FuncionalityService : IFuncionalityService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FuncionalityService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<FuncionalityDto> Add(FuncionalityDto dto)
    {
        var entity = _mapper.Map<Funcionality>(dto);
        entity.Profile = await _unitOfWork.ProfilesRepository.GetByIdAsync(entity.Profile.Id);

        await _unitOfWork.FuncionalityRepository.AddAsync(entity);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<FuncionalityDto>(entity);
    }

    public async Task Update(FuncionalityDto dto)
    {
        var exists = await _unitOfWork.FuncionalityRepository.ExistAsync(x => x.Id == dto.Id);
        if (!exists)
            throw new ConflictException("The record doesn't exist");

        var secondEntity = await _unitOfWork.ProfilesRepository.ExistAsync(x => x.Id == dto.IdProfile);

        if (!secondEntity)
            throw new ConflictException("The relation doesn't exist.");

        var entity = _mapper.Map<Funcionality>(dto);
        await _unitOfWork.FuncionalityRepository.UpdateAsync(entity);
        await _unitOfWork.SaveAsync();
    }

    public async Task Delete(Guid id)
    {
        var exists = await _unitOfWork.FuncionalityRepository.ExistAsync(x => x.Id == id);
        if (!exists)
            throw new NotFoundException("The record doesn't exist.");

        var entity = await _unitOfWork.FuncionalityRepository.GetByIdAsync(id);
        await _unitOfWork.FuncionalityRepository.DeleteAsync(entity);
        await _unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<FuncionalityDto>> GetAll()
    {
        var entity = await _unitOfWork.FuncionalityRepository.GetAllAsync(entitiesToInclude: new List<string> { "Profile" });
        var dto = _mapper.Map<IEnumerable<FuncionalityDto>>(entity);

        return dto;
    }

    public async Task<IEnumerable<FuncionalityDto>> GetAll(Pagination pagination)
    {
        var entity = await _unitOfWork.FuncionalityRepository.GetAllAsync(pagination.Skip, pagination.Limit, entitiesToInclude: new List<string> { "Profile" });
        var dto = _mapper.Map<IEnumerable<FuncionalityDto>>(entity);

        return dto;
    }

    public async Task<FuncionalityDto> GetById(Guid id)
    {
        var exists = await _unitOfWork.FuncionalityRepository.ExistAsync(x => x.Id == id);
        if (!exists)
            throw new NotFoundException("The record doesn't exist.");

        var entity = await _unitOfWork.FuncionalityRepository.GetByIdAsync(id, new List<string> { "Profile" });
        var dto = _mapper.Map<FuncionalityDto>(entity);

        return dto;
    }

}

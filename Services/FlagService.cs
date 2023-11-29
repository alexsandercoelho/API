using AutoMapper;
using Domain;
using Domain.Common;
using Domain.DTOs;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Services;

namespace Services;

public class FlagService : IFlagService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FlagService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<FlagDto> Add(FlagDto dto)
    {
        var entity = _mapper.Map<Flag>(dto);
        entity.Changes = await _unitOfWork.ChangesRepository.GetAllByIdFlagAsync(entity.Id);
        entity.EarlyBirds = await _unitOfWork.EarlyBirdRepository.GetAllByIdFlagAsync(entity.Id);

        await _unitOfWork.FlagRepository.AddAsync(entity);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<FlagDto>(entity);
    }

    public async Task Update(FlagDto dto)
    {
        var exists = await _unitOfWork.FlagRepository.ExistAsync(x => x.Id == dto.Id);
        if (!exists)
            throw new ConflictException("The record doesn't exist");

        var secondEntity = await _unitOfWork.ChangesRepository.ExistAsync(x => x.IdFlag == dto.Id);

        if (!secondEntity)
            throw new ConflictException("The changes record doesn't exist.");

        var thirdEntity = await _unitOfWork.EarlyBirdRepository.ExistAsync(x => x.IdFlag == dto.Id);

        if (!thirdEntity)
            throw new ConflictException("The Early Bird record doesn't exist.");

        var entity = _mapper.Map<Flag>(dto);
        await _unitOfWork.FlagRepository.UpdateAsync(entity);
        await _unitOfWork.SaveAsync();
    }

    public async Task Delete(Guid id)
    {
        var exists = await _unitOfWork.FlagRepository.ExistAsync(x => x.Id == id);
        if (!exists)
            throw new NotFoundException("The record doesn't exist.");

        var entity = await _unitOfWork.FlagRepository.GetByIdAsync(id);
        await _unitOfWork.FlagRepository.DeleteAsync(entity);
        await _unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<FlagDto>> GetAll()
    {
        var entity = await _unitOfWork.FlagRepository.GetAllAsync(entitiesToInclude: new List<string> { "EarlyBird", "Changes" });
        var dto = _mapper.Map<IEnumerable<FlagDto>>(entity);

        return dto;
    }

    public async Task<IEnumerable<FlagDto>> GetAll(Pagination pagination)
    {
        var entity = await _unitOfWork.FlagRepository.GetAllAsync(pagination.Skip, pagination.Limit, entitiesToInclude: new List<string> { "EarlyBird", "Changes" });
        var dto = _mapper.Map<IEnumerable<FlagDto>>(entity);

        return dto;
    }

    public async Task<FlagDto> GetById(Guid id)
    {
        var exists = await _unitOfWork.FlagRepository.ExistAsync(x => x.Id == id);
        if (!exists)
            throw new NotFoundException("The record doesn't exist.");

        var entity = await _unitOfWork.FlagRepository.GetByIdAsync(id, new List<string> { "EarlyBird", "Changes" });
        var dto = _mapper.Map<FlagDto>(entity);

        return dto;
    }

}

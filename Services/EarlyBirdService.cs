using AutoMapper;
using Domain;
using Domain.Common;
using Domain.DTOs;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Services;

namespace Services;

public class EarlyBirdService : IEarlyBirdService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EarlyBirdService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<EarlyBirdDto> Add(EarlyBirdDto dto)
    {
        var entity = _mapper.Map<EarlyBird>(dto);
        entity.Flag = await _unitOfWork.FlagRepository.GetByIdAsync(entity.Flag.Id);

        await _unitOfWork.EarlyBirdRepository.AddAsync(entity);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<EarlyBirdDto>(entity);
    }

    public async Task Update(EarlyBirdDto dto)
    {
        var exists = await _unitOfWork.EarlyBirdRepository.ExistAsync(x => x.Id == dto.Id);
        if (!exists)
            throw new ConflictException("The record doesn't exist");

        var secondEntity = await _unitOfWork.FlagRepository.ExistAsync(x => x.Id == dto.IdFlag);

        if (!secondEntity)
            throw new ConflictException("The Flag doesn't exist.");

        var entity = _mapper.Map<EarlyBird>(dto);
        await _unitOfWork.EarlyBirdRepository.UpdateAsync(entity);
        await _unitOfWork.SaveAsync();
    }

    public async Task Delete(Guid id)
    {
        var exists = await _unitOfWork.EarlyBirdRepository.ExistAsync(x => x.Id == id);
        if (!exists)
            throw new NotFoundException("The record doesn't exist.");

        var entity = await _unitOfWork.EarlyBirdRepository.GetByIdAsync(id);
        await _unitOfWork.EarlyBirdRepository.DeleteAsync(entity);
        await _unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<EarlyBirdDto>> GetAll()
    {
        var entity = await _unitOfWork.EarlyBirdRepository.GetAllAsync(entitiesToInclude: new List<string> { "Flag" });
        var dto = _mapper.Map<IEnumerable<EarlyBirdDto>>(entity);

        return dto;
    }

    public async Task<IEnumerable<EarlyBirdDto>> GetAll(Pagination pagination)
    {
        var entity = await _unitOfWork.EarlyBirdRepository.GetAllAsync(pagination.Skip, pagination.Limit, entitiesToInclude: new List<string> { "Flag" });
        var dto = _mapper.Map<IEnumerable<EarlyBirdDto>>(entity);

        return dto;
    }

    public async Task<EarlyBirdDto> GetById(Guid id)
    {
        var exists = await _unitOfWork.EarlyBirdRepository.ExistAsync(x => x.Id == id);
        if (!exists)
            throw new NotFoundException("The record doesn't exist.");

        var entity = await _unitOfWork.EarlyBirdRepository.GetByIdAsync(id, new List<string> { "Flag" });
        var dto = _mapper.Map<EarlyBirdDto>(entity);

        return dto;
    }

}

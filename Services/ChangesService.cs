using AutoMapper;
using Domain;
using Domain.Common;
using Domain.DTOs;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Services;

namespace Services;

public class ChangesService : IChangesService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ChangesService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ChangesDto> Add(ChangesDto dto)
    {
        var entity = _mapper.Map<Changes>(dto);
        entity.Flag = await _unitOfWork.FlagRepository.GetByIdAsync(entity.Flag.Id);

        await _unitOfWork.ChangesRepository.AddAsync(entity);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<ChangesDto>(entity);
    }

    public async Task Update(ChangesDto dto)
    {
        var exists = await _unitOfWork.ChangesRepository.ExistAsync(x => x.Id == dto.Id);
        if (!exists)
            throw new ConflictException("The record doesn't exist");

        var secondEntity = await _unitOfWork.FlagRepository.ExistAsync(x => x.Id == dto.IdFlag);

        if (!secondEntity)
            throw new ConflictException("The Flag doesn't exist.");

        var entity = _mapper.Map<Changes>(dto);
        await _unitOfWork.ChangesRepository.UpdateAsync(entity);
        await _unitOfWork.SaveAsync();
    }

    public async Task Delete(Guid id)
    {
        var exists = await _unitOfWork.ChangesRepository.ExistAsync(x => x.Id == id);
        if (!exists)
            throw new NotFoundException("The record doesn't exist.");

        var entity = await _unitOfWork.ChangesRepository.GetByIdAsync(id);
        await _unitOfWork.ChangesRepository.DeleteAsync(entity);
        await _unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<ChangesDto>> GetAll()
    {
        var entity = await _unitOfWork.ChangesRepository.GetAllAsync(entitiesToInclude: new List<string> { "Flag" });
        var dto = _mapper.Map<IEnumerable<ChangesDto>>(entity);

        return dto;
    }

    public async Task<IEnumerable<ChangesDto>> GetAll(Pagination pagination)
    {
        var entity = await _unitOfWork.ChangesRepository.GetAllAsync(pagination.Skip, pagination.Limit, entitiesToInclude: new List<string> { "Flag" });
        var dto = _mapper.Map<IEnumerable<ChangesDto>>(entity);

        return dto;
    }

    public async Task<ChangesDto> GetById(Guid id)
    {
        var exists = await _unitOfWork.ChangesRepository.ExistAsync(x => x.Id == id);
        if (!exists)
            throw new NotFoundException("The record doesn't exist.");

        var entity = await _unitOfWork.ChangesRepository.GetByIdAsync(id, new List<string> { "Flag" });
        var permissionDto = _mapper.Map<ChangesDto>(entity);

        return permissionDto;
    }

}

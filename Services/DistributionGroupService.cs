using AutoMapper;
using Domain;
using Domain.Common;
using Domain.DTOs;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Services;

namespace Services;

public class DistributionGroupService : IDistributionGroupService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DistributionGroupService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<DistributionGroupDto> Add(DistributionGroupDto dto)
    {
        var entity = _mapper.Map<DistributionGroup>(dto);

        await _unitOfWork.DistributionGroupRepository.AddAsync(entity);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<DistributionGroupDto>(entity);
    }

    public async Task Update(DistributionGroupDto dto)
    {
        var exists = await _unitOfWork.DistributionGroupRepository.ExistAsync(x => x.Id == dto.Id);
        if (!exists)
            throw new ConflictException("The record doesn't exist");

        var secondEntity = await _unitOfWork.DistributionRulesRepository.ExistAsync(x => x.Id == dto.IdDistributionRules);

        if (!secondEntity)
            throw new ConflictException("The Distribution Rules doesn't exist.");

        var entity = _mapper.Map<DistributionGroup>(dto);
        await _unitOfWork.DistributionGroupRepository.UpdateAsync(entity);
        await _unitOfWork.SaveAsync();
    }

    public async Task Delete(Guid id)
    {
        var exists = await _unitOfWork.DistributionGroupRepository.ExistAsync(x => x.Id == id);
        if (!exists)
            throw new NotFoundException("The record doesn't exist.");

        var entity = await _unitOfWork.DistributionGroupRepository.GetByIdAsync(id);
        await _unitOfWork.DistributionGroupRepository.DeleteAsync(entity);
        await _unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<DistributionGroupDto>> GetAll()
    {
        var entity = await _unitOfWork.DistributionGroupRepository.GetAllAsync(entitiesToInclude: new List<string> { "DistributionRules" });
        var dto = _mapper.Map<IEnumerable<DistributionGroupDto>>(entity);

        return dto;
    }

    public async Task<IEnumerable<DistributionGroupDto>> GetAll(Pagination pagination)
    {
        var entity = await _unitOfWork.DistributionGroupRepository.GetAllAsync(pagination.Skip, pagination.Limit, entitiesToInclude: new List<string> { "DistributionRules" });
        var dto = _mapper.Map<IEnumerable<DistributionGroupDto>>(entity);

        return dto;
    }

    public async Task<DistributionGroupDto> GetById(Guid id)
    {
        var exists = await _unitOfWork.DistributionGroupRepository.ExistAsync(x => x.Id == id);
        if (!exists)
            throw new NotFoundException("The record doesn't exist.");

        var entity = await _unitOfWork.DistributionGroupRepository.GetByIdAsync(id, new List<string> { "DistributionRules" });
        var dto = _mapper.Map<DistributionGroupDto>(entity);

        return dto;
    }

}

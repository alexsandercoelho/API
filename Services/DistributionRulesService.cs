using AutoMapper;
using Domain;
using Domain.Common;
using Domain.DTOs;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Services;

namespace Services;

public class DistributionRulesService : IDistributionRulesService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DistributionRulesService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<DistributionRulesDto> Add(DistributionRulesDto dto)
    {
        var entity = _mapper.Map<DistributionRules>(dto);
        entity.DistributionGroups = await _unitOfWork.DistributionGroupRepository.GetAllByIdRulesAsync(entity.Id);

        await _unitOfWork.DistributionRulesRepository.AddAsync(entity);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<DistributionRulesDto>(entity);
    }

    public async Task Update(DistributionRulesDto dto)
    {
        var exists = await _unitOfWork.DistributionRulesRepository.ExistAsync(x => x.Id == dto.Id);
        if (!exists)
            throw new ConflictException("The record doesn't exist");

        var secondEntity = await _unitOfWork.DistributionGroupRepository.ExistAsync(x => x.IdDistributionRules == dto.Id);

        if (!secondEntity)
            throw new ConflictException("The Distribution Group record doesn't exist.");

        var entity = _mapper.Map<DistributionRules>(dto);
        await _unitOfWork.DistributionRulesRepository.UpdateAsync(entity);
        await _unitOfWork.SaveAsync();
    }

    public async Task Delete(Guid id)
    {
        var exists = await _unitOfWork.DistributionRulesRepository.ExistAsync(x => x.Id == id);
        if (!exists)
            throw new NotFoundException("The record doesn't exist.");

        var entity = await _unitOfWork.DistributionRulesRepository.GetByIdAsync(id);
        await _unitOfWork.DistributionRulesRepository.DeleteAsync(entity);
        await _unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<DistributionRulesDto>> GetAll()
    {
        var entity = await _unitOfWork.DistributionRulesRepository.GetAllAsync(entitiesToInclude: new List<string> { "DistributionGroup" });
        var dto = _mapper.Map<IEnumerable<DistributionRulesDto>>(entity);

        return dto;
    }

    public async Task<IEnumerable<DistributionRulesDto>> GetAll(Pagination pagination)
    {
        var entity = await _unitOfWork.DistributionRulesRepository.GetAllAsync(pagination.Skip, pagination.Limit, entitiesToInclude: new List<string> { "DistributionGroup" });
        var dto = _mapper.Map<IEnumerable<DistributionRulesDto>>(entity);

        return dto;
    }

    public async Task<DistributionRulesDto> GetById(Guid id)
    {
        var exists = await _unitOfWork.DistributionRulesRepository.ExistAsync(x => x.Id == id);
        if (!exists)
            throw new NotFoundException("The record doesn't exist.");

        var entity = await _unitOfWork.DistributionRulesRepository.GetByIdAsync(id, new List<string> { "DistributionGroup" });
        var dto = _mapper.Map<DistributionRulesDto>(entity);

        return dto;
    }

}

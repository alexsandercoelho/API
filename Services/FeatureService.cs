using AutoMapper;
using Domain;
using Domain.Common;
using Domain.DTOs;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Services;

namespace Services;

public class FeatureService : IFeatureService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FeatureService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<FeatureDto> Add(FeatureDto dto)
    {
        var entity = _mapper.Map<Feature>(dto);
        entity.Profile = await _unitOfWork.ProfilesRepository.GetByIdAsync(entity.Profile.Id);

        await _unitOfWork.FeatureRepository.AddAsync(entity);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<FeatureDto>(entity);
    }

    public async Task Update(FeatureDto dto)
    {
        var exists = await _unitOfWork.FeatureRepository.ExistAsync(x => x.Id == dto.Id);
        if (!exists)
            throw new ConflictException("The record doesn't exist");

        var secondEntity = await _unitOfWork.ProfilesRepository.ExistAsync(x => x.Id == dto.IdProfile);

        if (!secondEntity)
            throw new ConflictException("The relation doesn't exist.");

        var entity = _mapper.Map<Feature>(dto);
        await _unitOfWork.FeatureRepository.UpdateAsync(entity);
        await _unitOfWork.SaveAsync();
    }

    public async Task Delete(Guid id)
    {
        var exists = await _unitOfWork.FeatureRepository.ExistAsync(x => x.Id == id);
        if (!exists)
            throw new NotFoundException("The record doesn't exist.");

        var entity = await _unitOfWork.FeatureRepository.GetByIdAsync(id);
        await _unitOfWork.FeatureRepository.DeleteAsync(entity);
        await _unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<FeatureDto>> GetAll()
    {
        var entity = await _unitOfWork.FeatureRepository.GetAllAsync(entitiesToInclude: new List<string> { "Profile" });
        var dto = _mapper.Map<IEnumerable<FeatureDto>>(entity);

        return dto;
    }

    public async Task<IEnumerable<FeatureDto>> GetAll(Pagination pagination)
    {
        var entity = await _unitOfWork.FeatureRepository.GetAllAsync(pagination.Skip, pagination.Limit, entitiesToInclude: new List<string> { "Profile" });
        var dto = _mapper.Map<IEnumerable<FeatureDto>>(entity);

        return dto;
    }

    public async Task<FeatureDto> GetById(Guid id)
    {
        var exists = await _unitOfWork.FeatureRepository.ExistAsync(x => x.Id == id);
        if (!exists)
            throw new NotFoundException("The record doesn't exist.");

        var entity = await _unitOfWork.FeatureRepository.GetByIdAsync(id, new List<string> { "Profile" });
        var dto = _mapper.Map<FeatureDto>(entity);

        return dto;
    }

}

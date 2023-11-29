using AutoMapper;
using Domain;
using Domain.Common;
using Domain.DTOs;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Services;

namespace Services;

public class ProfilesService : IProfilesService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProfilesService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ProfilesDto> Add(ProfilesDto dto)
    {
        var entity = _mapper.Map<Profiles>(dto);
        entity.Persons = await _unitOfWork.PersonRepository.GetAllByIdProfileAsync(entity.Id);
        entity.Features = await _unitOfWork.FeatureRepository.GetAllByIdProfileAsync(entity.Id);

        await _unitOfWork.ProfilesRepository.AddAsync(entity);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<ProfilesDto>(entity);
    }

    public async Task Update(ProfilesDto dto)
    {
        var exists = await _unitOfWork.ProfilesRepository.ExistAsync(x => x.Id == dto.Id);
        if (!exists)
            throw new ConflictException("The record doesn't exist");

        var secondEntity = await _unitOfWork.PersonRepository.ExistAsync(x => x.IdProfile == dto.Id);

        if (!secondEntity)
            throw new ConflictException("The person record doesn't exist.");

        var thirdEntity = await _unitOfWork.FeatureRepository.ExistAsync(x => x.IdProfile == dto.Id);

        if (!thirdEntity)
            throw new ConflictException("The Feature record doesn't exist.");

        var entity = _mapper.Map<Profiles>(dto);
        await _unitOfWork.ProfilesRepository.UpdateAsync(entity);
        await _unitOfWork.SaveAsync();
    }

    public async Task Delete(Guid id)
    {
        var exists = await _unitOfWork.ProfilesRepository.ExistAsync(x => x.Id == id);
        if (!exists)
            throw new NotFoundException("The record doesn't exist.");

        var entity = await _unitOfWork.ProfilesRepository.GetByIdAsync(id);
        await _unitOfWork.ProfilesRepository.DeleteAsync(entity);
        await _unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<ProfilesDto>> GetAll()
    {
        var entity = await _unitOfWork.ProfilesRepository.GetAllAsync(entitiesToInclude: new List<string> { "Person", "Feature" });
        var dto = _mapper.Map<IEnumerable<ProfilesDto>>(entity);

        return dto;
    }

    public async Task<IEnumerable<ProfilesDto>> GetAll(Pagination pagination)
    {
        var entity = await _unitOfWork.ProfilesRepository.GetAllAsync(pagination.Skip, pagination.Limit, entitiesToInclude: new List<string> { "Person", "Feature" });
        var dto = _mapper.Map<IEnumerable<ProfilesDto>>(entity);

        return dto;
    }

    public async Task<ProfilesDto> GetById(Guid id)
    {
        var exists = await _unitOfWork.ProfilesRepository.ExistAsync(x => x.Id == id);
        if (!exists)
            throw new NotFoundException("The record doesn't exist.");

        var entity = await _unitOfWork.ProfilesRepository.GetByIdAsync(id, new List<string> { "Person", "Feature" });
        var dto = _mapper.Map<ProfilesDto>(entity);

        return dto;
    }
}
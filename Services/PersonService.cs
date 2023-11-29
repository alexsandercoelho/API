using AutoMapper;
using Domain;
using Domain.Common;
using Domain.DTOs;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Services;
using System.Security;

namespace Services;

public class PersonService : IPersonService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PersonService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<PersonDto> Add(PersonDto dto)
    {
        var entity = _mapper.Map<Person>(dto);
        entity.Profile = await _unitOfWork.ProfilesRepository.GetByIdAsync(entity.Profile.Id);

        await _unitOfWork.PersonRepository.AddAsync(entity);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<PersonDto>(entity);
    }

    public async Task Update(PersonDto dto)
    {
        var exists = await _unitOfWork.PersonRepository.ExistAsync(x => x.Id == dto.Id);
        if (!exists)
            throw new ConflictException("The record doesn't exist");

        var secondEntity = await _unitOfWork.ProfilesRepository.ExistAsync(x => x.Id == dto.IdProfile);

        if (!secondEntity)
            throw new ConflictException("The relation doesn't exist.");

        var entity = _mapper.Map<Person>(dto);
        await _unitOfWork.PersonRepository.UpdateAsync(entity);
        await _unitOfWork.SaveAsync();
    }

    public async Task Delete(Guid id)
    {
        var exists = await _unitOfWork.PersonRepository.ExistAsync(x => x.Id == id);
        if (!exists)
            throw new NotFoundException("The record doesn't exist.");

        var entity = await _unitOfWork.PersonRepository.GetByIdAsync(id);
        await _unitOfWork.PersonRepository.DeleteAsync(entity);
        await _unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<PersonDto>> GetAll()
    {
        var entity = await _unitOfWork.PersonRepository.GetAllAsync(entitiesToInclude: new List<string> { "Profile" });
        var dto = _mapper.Map<IEnumerable<PersonDto>>(entity);

        return dto;
    }

    public async Task<IEnumerable<PersonDto>> GetAll(Pagination pagination)
    {
        var entity = await _unitOfWork.PersonRepository.GetAllAsync(pagination.Skip, pagination.Limit, entitiesToInclude: new List<string> { "Profile" });
        var dto = _mapper.Map<IEnumerable<PersonDto>>(entity);

        return dto;
    }

    public async Task<PersonDto> GetById(Guid id)
    {
        var exists = await _unitOfWork.PersonRepository.ExistAsync(x => x.Id == id);
        if (!exists)
            throw new NotFoundException("The record doesn't exist.");

        var entity = await _unitOfWork.PersonRepository.GetByIdAsync(id, new List<string> { "Profile" });
        var dto = _mapper.Map<PersonDto>(entity);

        return dto;
    }

}

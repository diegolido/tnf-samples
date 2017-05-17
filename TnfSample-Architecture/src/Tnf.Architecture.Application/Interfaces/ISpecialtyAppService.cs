﻿using Tnf.Application.Services;
using Tnf.Architecture.Dto;
using Tnf.Architecture.Dto.Registration;
using Tnf.Dto;

namespace Tnf.Architecture.Application.Interfaces
{
    public interface ISpecialtyAppService : IApplicationService
    {
        PagingResponseDto<SpecialtyDto> GetAllSpecialties(GetAllSpecialtiesDto request);
        SpecialtyDto GetSpecialty(int id);
        DtoResponseBase DeleteSpecialty(int id);
        DtoResponseBase<SpecialtyDto> CreateSpecialty(SpecialtyDto dto);
        DtoResponseBase<SpecialtyDto> UpdateSpecialty(SpecialtyDto dto);
    }
}
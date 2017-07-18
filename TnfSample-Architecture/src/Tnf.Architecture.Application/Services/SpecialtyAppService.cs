﻿using Tnf.App.Application.Services;
using Tnf.App.Bus.Notifications;
using Tnf.App.Dto.Request;
using Tnf.App.Dto.Response;
using Tnf.Architecture.Application.Interfaces;
using Tnf.Architecture.Domain.Interfaces.Services;
using Tnf.Architecture.Dto;
using Tnf.Architecture.Dto.Enumerables;
using Tnf.Architecture.Dto.Registration;

namespace Tnf.Architecture.Application.Services
{
    public class SpecialtyAppService : AppApplicationService, ISpecialtyAppService
    {
        private readonly ISpecialtyService _service;

        public SpecialtyAppService(ISpecialtyService service)
        {
            _service = service;
        }

        public ListDto<SpecialtyDto, int> GetAllSpecialties(GetAllSpecialtiesDto request)
            => _service.GetAllSpecialties(request);

        public SpecialtyDto GetSpecialty(RequestDto id)
        {
            if (id.GetId() <= 0)
                RaiseNotification(nameof(id));

            return Notification.HasNotification() ? new SpecialtyDto() : _service.GetSpecialty(id);
        }

        public SpecialtyDto CreateSpecialty(SpecialtyDto specialty)
        {
            if (specialty == null)
                RaiseNotification(nameof(specialty));

            return Notification.HasNotification() ? new SpecialtyDto() : _service.CreateSpecialty(specialty);
        }

        public SpecialtyDto UpdateSpecialty(int id, SpecialtyDto specialty)
        {
            if (id <= 0)
                RaiseNotification(nameof(id));

            if (specialty == null)
                RaiseNotification(nameof(specialty));

            if (Notification.HasNotification())
                return new SpecialtyDto();

            specialty.Id = id;
            return _service.UpdateSpecialty(specialty);
        }

        public void DeleteSpecialty(int id)
        {
            if (id <= 0)
                RaiseNotification(nameof(id));

            if (!Notification.HasNotification())
                _service.DeleteSpecialty(id);
        }

        private void RaiseNotification(params object[] parameter)
        {
            Notification.Raise(NotificationEvent.DefaultBuilder
                                                .WithMessage(AppConsts.LocalizationSourceName, Error.InvalidParameter)
                                                .WithDetailedMessage(AppConsts.LocalizationSourceName, Error.InvalidParameter)
                                                .WithMessageFormat(parameter)
                                                .Build());
        }
    }
}

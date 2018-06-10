using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using noshadow.api.Model.Entity;
using noshadow.api.Model.Payload;
using noshadow.api.Model.Proxy;
using noshadow.api.Repository;

namespace noshadow.api.Business
{
    public class GeolocationBusiness : BaseBusiness<LogEntity>
    {
        private readonly GeolocationRepository _logRepository;
        private readonly DeviceRepository _deviceRepository;

        public GeolocationBusiness(GeolocationRepository logRepository, DeviceRepository deviceRepository)
        {
            _logRepository = logRepository;
            _deviceRepository = deviceRepository;
        }

        public async Task CreateAsync(GeoloacationPayload payload)
        {
            var device = await _deviceRepository.FirstOrDefaultAsync(f => f.DeviceId == payload.DeviceId);

            if (device == null)
            {
                device = new DeviceEntity()
                {
                    Id = Guid.NewGuid(),
                    DeviceId = payload.DeviceId
                };
                
                await _deviceRepository.AddAndSaveAsync(device);
            }

            var log = new LogEntity()
            {
                Id = Guid.NewGuid(),
                DeviceId = device.Id,
                Height = Convert.ToDouble(payload.Height),
                Speed = Convert.ToDouble(payload.Speed),
                //TODO: Converter do formato
                Latitude = Convert.ToDouble(payload.Latitude),
                Longitude = Convert.ToDouble(payload.Longitude),
                LogDate = payload.LogDate
            };

            await _logRepository.AddAndSaveAsync(log);
        }

        public async Task<List<GeolocationProxy>> Get(FilterPayload filter)
        {
            var logsEntity = _logRepository.GetAll().Include(i => i.Device).OrderBy(o => o.LogDate).Where(w => w.DeviceId == filter.DeviceId);
            
            
            

            if (filter.Start.HasValue)
            {
                logsEntity = logsEntity.Where(w => w.LogDate > filter.Start.Value);
            }
            
            if (filter.End.HasValue)
            {
                logsEntity = logsEntity.Where(w => w.LogDate < filter.End.Value);
            }

            var logs = new List<LogEntity>();
            foreach (var entity in logsEntity)
            {  
                if (!logs.Any(f => f.Latitude == entity.Latitude && f.Longitude == entity.Longitude))
                {
                    logs.Add(entity);
                }
            }

            return logs.Select(s => new GeolocationProxy()
            {
                LogDate = s.LogDate,
                Latitude = s.Latitude,
                Longitude = s.Longitude,
                Speed = s.Speed.ToString(),
                Height = s.Height.ToString(),
                
                DeviceId = s.Device.DeviceId
            }).ToList();
        }
    }
}
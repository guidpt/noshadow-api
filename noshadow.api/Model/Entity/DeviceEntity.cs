using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace noshadow.api.Model.Entity
{
    public class DeviceEntity
    {
        public Guid Id { get; set; }
        
        public string DeviceId { get; set; }
    }
}
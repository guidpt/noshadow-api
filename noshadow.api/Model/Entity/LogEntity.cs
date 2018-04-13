using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace noshadow.api.Model.Entity
{
    public class LogEntity
    {
        public Guid Id { get; set; }
        
        public double Latitude { get; set; }
        
        public double Longitude { get; set; }
        
        public double Speed { get; set; }
        
        public double Height { get; set; }

        public DateTime LogDate { get; set; }
        
        public Guid DeviceId { get; set; }
        
        [ForeignKey("DeviceId")]
        public DeviceEntity Device { get; set; }
    }
}
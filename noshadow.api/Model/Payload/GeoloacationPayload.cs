using System;

namespace noshadow.api.Model.Payload
{
    public class GeoloacationPayload
    {
        public DateTime LogDate { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        
        public string Speed { get; set; }
        public string Height { get; set; }
        
        
        public string DeviceId { get; set; }
    }
}
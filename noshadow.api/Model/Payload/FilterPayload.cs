using System;

namespace noshadow.api.Model.Payload
{
    public class FilterPayload
    {
        public DateTime? Start { get; set; }
        
        public DateTime? End { get; set; }
        
        public Guid DeviceId { get; set; }
    }
}
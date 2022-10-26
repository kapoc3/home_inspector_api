using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace HomeInspector.Entities
{
    [Table("Devices")]
    public class Device: AuditedAggregateRoot<Guid>
    {
        public Device(Guid id) : base(id) 
        {
        }
        public string Name { get; set; }
        public string PublicIp { get; set; }
        public string PrivateIp { get; set; }
        public string DefaultGateway { get; set; }
        [Required]
        public string Mac { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Region { get; set; }
    }
}

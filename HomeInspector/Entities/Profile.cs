using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace HomeInspector.Entities
{
    [Table("Profiles")]
    public class Profile : AuditedAggregateRoot<Guid>
    {
        public int ProfileId { get; set; }
        public DateTime ReadDateTime { get; set; }
        /// <summary>
        /// Data in megabites
        /// </summary>
        public float UploadSpeed { get; set; }
        /// <summary>
        /// Data in mgabytes
        /// </summary>
        public float Download { get; set; }
        public float Ping { get; set; }
        public virtual Device Device { get; set; }

    }
}

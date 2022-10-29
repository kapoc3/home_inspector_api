using System.ComponentModel.DataAnnotations.Schema;

namespace HomeInspector.Services.Dtos.Profile
{
    public class CreateUpdateProfileOwnDto
    {
        public Guid Id { get; set; }
        public CreateUpdateProfileOwnDto() 
        {
            this.Id = Guid.NewGuid();
        }
        public int ProfileId { get; set; }
        public DateTime ReadDateTime { get; set; }
        public float UploadSpeed { get; set; }
        public float Download { get; set; }
        public float Ping { get; set; }
        public Guid DeviceId { get; set; }
    }
}

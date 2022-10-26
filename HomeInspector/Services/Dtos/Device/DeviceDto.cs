namespace HomeInspector.Services.Dtos.Device
{
    public class DeviceDto
    {
        public string Name { get; set; }
        public string PublicIp { get; set; }
        public string PrivateIp { get; set; }
        public string DefaultGateway { get; set; }
        public string Mac { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Region { get; set; }
        public Guid UserId { get; set; }
    }
}

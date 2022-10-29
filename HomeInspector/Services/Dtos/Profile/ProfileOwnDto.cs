﻿namespace HomeInspector.Services.Dtos.Profile
{
    public class ProfileOwnDto
    {
        public int ProfileId { get; set; }
        public DateTime ReadDateTime { get; set; }
        public float UploadSpeed { get; set; }
        public float DownloadSpeed { get; set; }
        public float Ping { get; set; }
        public Guid DeviceId { get; set; }
    }
}

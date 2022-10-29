namespace HomeInspector.Services.Dtos.Profile
{
    public class BulkCreateUpdateProfileDto
    {
        public ICollection<CreateUpdateProfileOwnDto> Profiles { get; set; }
    }
}

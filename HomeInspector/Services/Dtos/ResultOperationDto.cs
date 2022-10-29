using System.Net;

namespace HomeInspector.Services.Dtos
{
    public class ResultOperationDto<T>
    {
        public HttpStatusCode Code { get; set; }
        public T Data { get; set; }
    }
}

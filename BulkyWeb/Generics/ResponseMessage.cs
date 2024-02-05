namespace BulkyWeb.Generics
{
    public class ResponseMessage
    {
        public string? Status { get; set; }
        public string? Message { get; set; }
        public ResponseMessage(string status, string message)
        {
            Status = status;
            Message = message;
        }

    }
}


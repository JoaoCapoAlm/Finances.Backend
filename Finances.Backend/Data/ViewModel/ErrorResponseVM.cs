namespace Finances.Backend.Data.ViewModel
{
    public class ErrorResponseVM
    {
        public string TraceId { get; set; }
        public List<ErrorDetailVM> Errors { get; set; }
        public ErrorResponseVM(string logref, string message)
        {
            TraceId = Guid.NewGuid().ToString();
            Errors = new List<ErrorDetailVM>()
            {
                new ErrorDetailVM(logref, message)
            };
        }

        public class ErrorDetailVM
        {
            public string LogRef { get; set; }
            public string Message { get; set; }
            public ErrorDetailVM(string logRef, string message)
            {
                LogRef = logRef;
                Message = message;
            }
        }
    }
}

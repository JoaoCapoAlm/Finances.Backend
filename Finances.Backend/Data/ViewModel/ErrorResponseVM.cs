namespace Finances.Backend.Data.ViewModel
{
    public class ErrorResponseVM
    {
        protected string TraceId { get; set; }
        protected List<ErrorDetailVM> Errors { get; set; }
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
            protected string LogRef { get; set; }
            protected string Message { get; set; }
            public ErrorDetailVM(string logRef, string message)
            {
                LogRef = logRef;
                Message = message;
            }
        }
    }
}

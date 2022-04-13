namespace TimeLog.API.Utils
{
    public abstract class ErrorLog
    {
        public int ErrorCode { get; set; }
        public string ErrorString { get; set; }
    }
}
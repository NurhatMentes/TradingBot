namespace Core.CrossCuttingConcerns.Logging;

public class LogDetail
{
    public string MethodName { get; set; }
    public string User { get; set; }
    public List<LogParameter> Parameters { get; set; }
    public DateTime LogDate { get; set; }
    public string LogLevel { get; set; }
}
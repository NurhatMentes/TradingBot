namespace Core.CrossCuttingConcerns.Logging;

public interface ILogManager
{
    void Log(LogDetail logDetail);
    void LogInfo(string message);
    void LogWarning(string message);
    void LogError(string message, Exception exception = null);
}
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace Core.CrossCuttingConcerns.Logging;

public class LogManager : ILogManager
{
    private readonly ILogger<LogManager> _logger;

    public LogManager(ILogger<LogManager> logger)
    {
        _logger = logger;
    }

    public void Log(LogDetail logDetail)
    {
        var logMessage = JsonSerializer.Serialize(logDetail);
        _logger.LogInformation(logMessage);
    }

    public void LogInfo(string message)
    {
        _logger.LogInformation(message);
    }

    public void LogWarning(string message)
    {
        _logger.LogWarning(message);
    }

    public void LogError(string message, Exception exception = null)
    {
        if (exception != null)
            _logger.LogError(exception, message);
        else
            _logger.LogError(message);
    }
}
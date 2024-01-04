namespace BookStoreCore.Services.Logger;

public class LoggerManager : ILoggerManager
{
    private readonly ILogger _logger;

    public LoggerManager(ILogger logger)
    {
        this._logger = logger;
    }

    public void LogInfo(string message)
    {
        _logger.LogInformation(message);
    }
    public void LogWarn(string message)
    {
        _logger.LogInformation(message);
    }
    public void LogDebug(string message)
    {
        _logger.LogInformation(message);
    }
    public void LogError(string message)
    {
        _logger.LogInformation(message);
    }
}


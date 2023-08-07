using NLog;
using System;
using System.ComponentModel;

namespace NLogWinForm
{
    public sealed class Log : ILog
    {
        private readonly ILogger _logger;

        public Log(ILogger logger)
        {
            this._logger = logger;
        }

        public void Info([Localizable(false)] string message)
        {
            this._logger.Info(message);
        }

        public void Error(Exception exception)
        {
            this._logger.Error(exception);
        }

        public void Error(Exception exception, [Localizable(false)] string message)
        {
            this._logger.Error(exception, message);
        }

        public void Error([Localizable(false)] string message)
        {
            this._logger.Error(message);
        }

        public void Error(Exception exception, [Localizable(false)] string message, params object[] args)
        {
            this._logger.Error(exception, message, args);
        }

        public void Error([Localizable(false)] string message, params object[] args)
        {
            this._logger.Error(message, args);
        }

        public void Debug([Localizable(false)] string message, params object[] args)
        {
            this._logger.Debug(message, args);
        }

        public void Trace([Localizable(false)] string message)
        {
            this._logger.Trace(message);
        }
    }
}

using System;
using System.ComponentModel;

namespace NLogWinForm
{
    public interface ILog
    {
        void Info([Localizable(false)] string message);
        void Error(Exception exception);
        void Error(Exception exception, [Localizable(false)] string message);
        void Error([Localizable(false)] string message);
        void Error(Exception exception, [Localizable(false)] string message, params object[] args);
        void Error([Localizable(false)] string message, params object[] args);
        void Debug([Localizable(false)] string message, params object[] args);
        void Trace([Localizable(false)] string message);
    }
}

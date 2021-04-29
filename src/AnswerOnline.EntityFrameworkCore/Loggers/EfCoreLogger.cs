using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AnswerOnline.EntityFrameworkCore.Loggers
{
    public class EfCoreLogger : ILogger
    {
        private readonly string _categoryName;

        public EfCoreLogger(string categoryName)
        {
            _categoryName = categoryName;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (_categoryName != DbLoggerCategory.Database.Command.Name || logLevel != LogLevel.Information)
            {
                return;
            }

            var logContent = formatter(state, exception);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(logContent);
            Console.ResetColor();
            //_logger.LogDebug("SqlLog", "【SQL语句】:" + logContent);
        }

        public bool IsEnabled(LogLevel logLevel) => true;

        public IDisposable BeginScope<TState>(TState state) => null;
    }
}
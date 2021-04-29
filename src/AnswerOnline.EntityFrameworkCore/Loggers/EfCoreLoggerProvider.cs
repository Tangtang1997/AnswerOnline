using Microsoft.Extensions.Logging;

namespace AnswerOnline.EntityFrameworkCore.Loggers
{
    public class EfCoreLoggerProvider : ILoggerProvider
    {
        public void Dispose()
        {

        }

        public ILogger CreateLogger(string categoryName)
        {
            return new EfCoreLogger(categoryName);
        }
    }
}
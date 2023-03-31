using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXP.QA.Vile.UTest.Core
{
    public interface ITimeProvider
    {
        DateTime UtcNow { get; }
    }

    public class TimeProvider : ITimeProvider, IDisposable
    {
        private static ThreadLocal<ITimeProvider> _instance = new ThreadLocal<ITimeProvider>(CreateDefault);
        public static ITimeProvider Instance => _instance.Value;

        public static TimeProvider UseTime(DateTime value)
        {
            var staticTimeProvider = new TimeProvider(() => value);
            _instance = new ThreadLocal<ITimeProvider>(() => staticTimeProvider);
            return staticTimeProvider;
        }

        private static TimeProvider CreateDefault()
        {
            return new TimeProvider(() => DateTime.UtcNow);
        }

        private readonly Func<DateTime> _getTimeFunc;

        public TimeProvider(Func<DateTime> getTimeFunc)
        {
            _getTimeFunc = getTimeFunc;
        }

        public DateTime UtcNow => _getTimeFunc();

        public void Dispose()
        {
            _instance = new ThreadLocal<ITimeProvider>(CreateDefault);
        }
    }
}

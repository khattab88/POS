using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infrastructure.Timing
{
    public interface IDateTimeService
    {
        DateTime Now { get; }
        DateTime UtcNow { get; }
    }

    public class DateTimeService : IDateTimeService
    {
        public DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }

        public DateTime UtcNow
        {
            get
            {
                return DateTime.UtcNow; 
            }
        }
    }
}

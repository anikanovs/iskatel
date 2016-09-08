using System;

namespace Iskatel.Model
{
    public struct Date
    {
        public DateTime DateTime { get; set; }
        public bool IsExactly { get; set; }
        public bool IsBeforeChristmas { get; set; }

        public Date(DateTime dateTime, bool isExactly, bool isBeforeChristmas)
        {
            DateTime = dateTime;
            IsExactly = isExactly;
            IsBeforeChristmas = isBeforeChristmas;
        }

        public Date(DateTime dateTime, bool isBeforeChristmas) : this(dateTime, true, isBeforeChristmas) { }

        public Date(DateTime dateTime) : this(dateTime, false) { }
    }
}

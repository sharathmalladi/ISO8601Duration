using System.Text.RegularExpressions;

namespace ISO8601DurationClassLib
{
    public class ISO8601Duration
    {
        // Refer to https://regex101.com/library/LKY0hh for an explanation
        static Regex iso8601DurationRegex = new Regex("^(P((?<numYears>[1-9]+[0-9]*)Y)?((?<numMonths>[1-9]+[0-9]*)M)?((?<numDays>[1-9]+[0-9]*)D)?(T((?<numHours>[1-9]+[0-9]*)H)?((?<numMinutes>[1-9]+[0-9]*)M)?((?<numSeconds>[1-9]+[0-9]*)S)?)?|P(?<numWeeks>[1-9]+[0-9]*)W)$", RegexOptions.Compiled);
        public int Years { get; }
        public int Months { get; }
        public int Weeks { get; }
        public int Days { get; }
        public int Hours { get; }
        public int Minutes { get; }
        public int Seconds { get; }

        public ISO8601Duration(string duration)
        {
            var match = iso8601DurationRegex.Match(duration);
            if (!match.Success)
            {
                throw new ArgumentException(duration, nameof(duration));
            }

            Func<string, int> extractValue = (propertyName) => match.Groups[propertyName].Success ? int.Parse(match.Groups[propertyName].Value) : 0;
            Years = extractValue("numYears");
            Months = extractValue("numMonths");
            Weeks = extractValue("numWeeks");
            Days = extractValue("numDays");
            Hours = extractValue("numHours");
            Minutes = extractValue("numMinutes");
            Seconds = extractValue("numSeconds");
        }
    }

    public static class DateTimeExtensions
    {
        public static DateTime Add(this DateTime dateTime, ISO8601Duration duration)
        {
            dateTime = dateTime.AddYears(duration.Years);
            dateTime = dateTime.AddMonths(duration.Months);
            dateTime = dateTime.AddDays(7 * duration.Weeks + duration.Days);
            dateTime = dateTime.AddHours(duration.Hours);
            dateTime = dateTime.AddMinutes(duration.Minutes);
            dateTime = dateTime.AddSeconds(duration.Seconds);
            return dateTime;
        }
    }
}

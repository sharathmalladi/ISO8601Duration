# ISO8601Duration
C# Implementation for the [ ISO 8601 format](https://en.wikipedia.org/wiki/ISO_8601) for duration. It has the ability to denote duration in months which the [C# TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan) struct does not have.

# Why
The TimeSpan struct in .NET works in general to designate a time duration but falls short of expectations in that it cannot be used to express jobs that run once a month. Why? Because the closest match is TimeSpan.FromDays(30) which means the job will run on Jan1st, Jan31st, Mar 1st/2nd depending on the year … instead of Jan1st, Feb 1st, Mar 1st … and so on. So I went about designing my own implementation that can be useful.

# Approach
The ISO-8601 standard for duration is a good convention to follow which has this format: P[n]Y[n]M[n]DT[n]H[n]M[n]S or P[n]W.
Here is a regular expression for that: regex101: [ISO 8601 Duration Regex](https://regex101.com/library/LKY0hh)


using Equality.Domain.Primitives;

namespace Equality.Domain.ValueObjects
{
    public sealed class DateTimeRange : ValueObject<DateTimeRange>
    {
        public DateTime DateTimeFrom { get; }
        public DateTime DateTimeTo { get; }

        public DateTimeRange(DateTime from, DateTime to)
        {
            DateTimeFrom = from;
            DateTimeTo = to;
        }

        public override string ToString()
            => $"DateTimeRange - From: {DateTimeFrom} | To: {DateTimeTo}";

        public TimeSpan GetDuration()
            => this.DateTimeTo - this.DateTimeFrom;

        public bool HasOverlapWith(DateTimeRange other)
            => this.DateTimeFrom < other.DateTimeTo
                && this.DateTimeTo > other.DateTimeFrom;

        public DateTimeRange? GetOverlapWith(DateTimeRange other)
        {
            if (!HasOverlapWith(other))
            {
                return null;
            }

            DateTime overlapStart = (this.DateTimeFrom >= other.DateTimeFrom)
                ? this.DateTimeFrom 
                : other.DateTimeFrom;

            DateTime overlapEnd = (this.DateTimeTo >= other.DateTimeTo)
                ? other.DateTimeTo
                : this.DateTimeTo;

            return new DateTimeRange(overlapStart, overlapEnd);
        }

        public TimeSpan GetOverlapDuration(DateTimeRange other)
        {
            DateTimeRange overlap = GetOverlapWith(other) 
                ?? new DateTimeRange(DateTime.MinValue, DateTime.MinValue);

            return overlap.GetDuration();
        }

        //TODO: Able to find a better name for this?
        public bool HasInRange(DateTime dateTime)
            => dateTime >= this.DateTimeFrom 
                && dateTime <= this.DateTimeTo;
    }
}

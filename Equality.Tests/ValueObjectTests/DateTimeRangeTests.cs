using Equality.Domain.ValueObjects;

namespace Equality.Tests.ValueObjectTests
{
    public class DateTimeRangeTests
    {
        private static readonly DateTime _dateTimeA = new(2024, 1, 1, 0, 0, 0);
        private static readonly DateTime _dateTimeB = new(2025, 2, 1, 12, 55, 23);

        [Fact]
        public void EqualityCheck_Should_Return_True_IfEqual()
        {
            DateTimeRange rangeA = new(_dateTimeA, _dateTimeA);
            DateTimeRange rangeB = new(_dateTimeA, _dateTimeA);

            Assert.True(rangeA.Equals(rangeB));
        }

        [Fact]
        public void EqualityCheck_Should_Return_False_IfNotEqual()
        {
            DateTimeRange rangeA = new(_dateTimeA, _dateTimeA);
            DateTimeRange rangeB = new(_dateTimeA, _dateTimeB);

            Assert.False(rangeA.Equals(rangeB));
        }

        [Fact]
        public void NoOverlap_Should_Return_NoOverlap()
        {
            DateTimeRange rangeA = new(_dateTimeA, _dateTimeB);

            DateTime bFrom = new(1993, 1, 1, 0, 0, 0);
            DateTime bTo = new(2021, 12, 31, 23, 59, 59);
            DateTimeRange rangeB = new(bFrom, bTo);

            DateTimeRange expectedOverlap = new(DateTime.MinValue, DateTime.MinValue);
            TimeSpan expectedDuration = TimeSpan.Zero;

            Assert.Null(rangeA.GetOverlapWith(rangeB));
            Assert.Equal(expectedDuration, expectedOverlap.GetDuration());
            Assert.Equal(expectedOverlap.GetDuration(), rangeA.GetOverlapDuration(rangeB));
        }

        /*
         *  Scenario 1:
         *  
         *  RangeA:      |------------------------|
         *  RangeB:  |-------------|
         */
        [Fact]
        public void Scenario1_Should_Return_CorrectOverlap()
        {
            DateTimeRange rangeA = new(_dateTimeA, _dateTimeB);

            DateTime bFrom = new(2023, 1, 1, 0, 0, 0);
            DateTime bTo = new(2024, 12, 31, 23, 59, 59);
            DateTimeRange rangeB = new(bFrom, bTo);

            DateTimeRange expectedOverlap = new(_dateTimeA, bTo);

            Assert.StrictEqual(expectedOverlap, rangeA.GetOverlapWith(rangeB));
            Assert.Equal(expectedOverlap.GetDuration(), rangeA.GetOverlapDuration(rangeB));
        }

        /*
         *  Scenario 2:
         *  
         *  RangeA:      |------------------------|
         *  RangeB:  |-----------------------------------|
         */
        [Fact]
        public void Scenario2_Should_Return_CorrectOverlap()
        {
            DateTimeRange rangeA = new(_dateTimeA, _dateTimeB);

            DateTime bFrom = new(2023, 1, 1, 0, 0, 0);
            DateTime bTo = new(2029, 12, 31, 23, 59, 59);
            DateTimeRange rangeB = new(bFrom, bTo);

            DateTimeRange expectedOverlap = new(_dateTimeA, _dateTimeB);

            Assert.StrictEqual(expectedOverlap, rangeA.GetOverlapWith(rangeB));
            Assert.Equal(expectedOverlap.GetDuration(), rangeA.GetOverlapDuration(rangeB));

        }

        /*
         *  Scenario 3:
         *  
         *  RangeA:      |------------------------|
         *  RangeB:          |-------------|
         */
        [Fact]
        public void Scenario3_Should_Return_CorrectOverlap()
        {
            DateTimeRange rangeA = new(_dateTimeA, _dateTimeB);

            DateTime bFrom = new(2024, 7, 1, 0, 0, 0);
            DateTime bTo = new(2024, 12, 31, 23, 59, 59);
            DateTimeRange rangeB = new(bFrom, bTo);

            DateTimeRange expectedOverlap = new(bFrom, bTo);

            Assert.StrictEqual(expectedOverlap, rangeA.GetOverlapWith(rangeB));
            Assert.Equal(expectedOverlap.GetDuration(), rangeA.GetOverlapDuration(rangeB));
        }

        /*
         *  Scenario 4:
         *  
         *  RangeA:      |------------------------|
         *  RangeB:                      |-------------|
         */
        [Fact]
        public void Scenario4_Should_Return_CorrectOverlap()
        {
            DateTimeRange rangeA = new(_dateTimeA, _dateTimeB);

            DateTime bFrom = new(2024, 7, 1, 0, 0, 0);
            DateTime bTo = new(2029, 12, 31, 23, 59, 59);
            DateTimeRange rangeB = new(bFrom, bTo);

            DateTimeRange expectedOverlap = new(bFrom, _dateTimeB);

            Assert.StrictEqual(expectedOverlap, rangeA.GetOverlapWith(rangeB));
            Assert.Equal(expectedOverlap.GetDuration(), rangeA.GetOverlapDuration(rangeB));

        }
    }
}

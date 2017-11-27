﻿using System;
using BasicInfrastructureExtensions.Extensions;
using Xunit;
using Xunit2.Should;

namespace BasicInfrastructurePersistence.Tests.Extensions
{

    public class DateTimeExtensionsTests
    {
        [Theory]
        [InlineData("2017-01-01T01:00:00", "2017-01-01T02:00:00")]
        [InlineData("2017-01-01", "2017-01-02")]
        [InlineData("2017-01-01", "2017-03-01")]
        public void MustBeBefore(string aDate, string otherDate)
        {
            var firstDate = DateTime.Parse(aDate);
            var secondDate = DateTime.Parse(otherDate);
            
            firstDate.IsBefore(secondDate).ShouldBeTrue();
        }
        [Theory]
        [InlineData("2017-01-01T01:00:00", "2017-01-01T00:00:00")]
        [InlineData("2017-01-01", "2016-12-31")]
        [InlineData("2017-01-01", "2016-03-01")]
        [InlineData("2017-01-01", "2017-01-01")]
        public void MustNotBeBefore(string aDate, string otherDate)
        {
            var firstDate = DateTime.Parse(aDate);
            var secondDate = DateTime.Parse(otherDate);
            
            firstDate.IsBefore(secondDate).ShouldBeFalse();
        }
        [Theory]
        [InlineData("2017-01-01T01:00:00", "2017-01-01T00:00:00")]
        [InlineData("2017-01-01", "2016-12-31")]
        [InlineData("2017-01-01", "2016-03-01")]
        public void MustBeAfter(string aDate, string otherDate)
        {
            var firstDate = DateTime.Parse(aDate);
            var secondDate = DateTime.Parse(otherDate);
            
            firstDate.IsAfter(secondDate).ShouldBeTrue();
        }
        [Theory]
        [InlineData("2017-01-01T01:00:00", "2017-01-01T02:00:00")]
        [InlineData("2017-01-01", "2017-01-02")]
        [InlineData("2017-01-01", "2017-03-01")]
        [InlineData("2017-01-01", "2017-01-01")]
        public void MustNotBeAfter(string aDate, string otherDate)
        {
            var firstDate = DateTime.Parse(aDate);
            var secondDate = DateTime.Parse(otherDate);
            
            firstDate.IsAfter(secondDate).ShouldBeFalse();
        }

        [Theory]
        [InlineData("2017-01-01T01:00:00", "2017-01-01T00:00:00")]
        [InlineData("2017-01-21", "2017-01-01")]
        [InlineData("2017-03-12T12:33:21", "2017-03-01")]
        [InlineData("2017-02-01", "2017-02-01")]
        public void MustReturnFirstDayOfMonth(string value, string expected)
        {
            var dateValue = DateTime.Parse(value);
            var dateExpected = DateTime.Parse(expected);
            
            dateValue.FirstDayOfMonth().ShouldBe(dateExpected);
        }

        [Theory]
        [InlineData("2017-01-02T01:50:00", "2017-01-31T00:00:00")]
        [InlineData("2017-01-21", "2017-01-31")]
        [InlineData("2017-03-12T12:33:21", "2017-03-31")]
        [InlineData("2017-02-01", "2017-02-28")]
        public void MustReturnLastDayOfMonth(string value, string expected)
        {
            var dateValue = DateTime.Parse(value);
            var dateExpected = DateTime.Parse(expected);

            dateValue.LastDayOfMonth().ShouldBe(dateExpected);
        }

        [Theory]
        [InlineData("2017-01-02T01:50:00", "2017-02-01T00:00:00")]
        [InlineData("2017-01-21", "2017-02-01")]
        [InlineData("2017-03-12T12:33:21", "2017-04-01")]
        [InlineData("2017-02-01", "2017-03-01")]
        public void MustReturnFirstDayOfNextMonth(string value, string expected)
        {
            var dateValue = DateTime.Parse(value);
            var dateExpected = DateTime.Parse(expected);

            dateValue.FirstDayOfNextMonth().ShouldBe(dateExpected);
        }

        [Theory]
        [InlineData("2017-01-01T01:00:00", "2017-01-01T00:00:00")]
        [InlineData("2017-01-21", "2017-01-15")]
        [InlineData("2017-03-02T12:33:21", "2017-02-26")]
        [InlineData("2017-02-01", "2017-01-29")]
        public void MustReturnFirstDayOfWeek(string value, string expected)
        {
            var dateValue = DateTime.Parse(value);
            var dateExpected = DateTime.Parse(expected);

            dateValue.FirstDayOfWeek().ShouldBe(dateExpected);
        }

        [Theory]
        [InlineData("2017-01-01T01:00:00", "2017-01-07T00:00:00")]
        [InlineData("2017-01-15", "2017-01-21")]
        [InlineData("2017-03-02T12:33:21", "2017-03-04")]
        [InlineData("2017-02-28", "2017-03-04")]
        public void MustReturnLastDayOfWeek(string value, string expected)
        {
            var dateValue = DateTime.Parse(value);
            var dateExpected = DateTime.Parse(expected);

            dateValue.LastDayOfWeek().ShouldBe(dateExpected);
        }

        [Theory]
        [InlineData("2017-01-01T01:00:00", "2017-01-08T00:00:00")]
        [InlineData("2017-01-15", "2017-01-22")]
        [InlineData("2017-03-02T12:33:21", "2017-03-05")]
        [InlineData("2017-02-28", "2017-03-05")]
        public void MustReturnFirstDayOfNextWeek(string value, string expected)
        {
            var dateValue = DateTime.Parse(value);
            var dateExpected = DateTime.Parse(expected);

            dateValue.FirstDayOfNextWeek().ShouldBe(dateExpected);
        }
    }
}

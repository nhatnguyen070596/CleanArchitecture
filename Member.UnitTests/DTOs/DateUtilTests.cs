using System;
using Xunit;
using Member.Domain.DTOs;
using Member.Domain.Mappings;
using Member.Domain.Utils;
using Member.Domain.Entities;

namespace Member.UnitTests.DTOs
{
	public class DateUtilTests
	{
        [Fact]
        public void GetCurrentDate_ReturnsCorrectDate()
        {
            var currentDate = DateUtil.GetCurrentDate();

            Assert.True(currentDate.Year >= 2021);
        }
    }
}


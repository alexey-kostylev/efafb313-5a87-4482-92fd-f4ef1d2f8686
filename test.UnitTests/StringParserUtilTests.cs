// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using test.api.Logic;

namespace test.UnitTests
{
    public class StringParserUtilTests : TestBase
    {
        [Theory]
        [InlineData("", "")]
        [InlineData(null, "")]
        [InlineData("a b", "")]
        [InlineData("1 a 2", "1 2")]
        public void ShouldProcessEdgeConditions(string input, string expected)
        {
            var actual = StringParserUtil.ExtractLongestSubSequence(input);

            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData("1\t2", "1 2")]
        [InlineData("1\n2", "1 2")]
        [InlineData("1 2", "1 2")]
        public void ShouldProcessWhiteSpaces(string input, string expected)
        {
            var actual = StringParserUtil.ExtractLongestSubSequence(input);

            actual.Should().Be(expected);
        }

        [Theory]
        [ClassData(typeof(StringParserTestData))]
        public void ShouldPassTestData(string input, string expectedOutput)
        {
            var actual = StringParserUtil.ExtractLongestSubSequence(input);
            actual.Should().Be(expectedOutput);
        }
    }
}

//
//  StringExtensionTests.cs
//
//  Author:
//       Jarl Gullberg <jarl.gullberg@gmail.com>
//
//  Copyright (c) 2017 Jarl Gullberg
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//

using Remora.Discord.Commands.Extensions;
using Xunit;

// ReSharper disable ParameterOnlyUsedForPreconditionCheck.Local
namespace Remora.Discord.Commands.Tests.Extensions
{
    /// <summary>
    /// Tests the <see cref="CommandTreeExtensions"/> class.
    /// </summary>
    public class StringExtensionTests
    {
        /// <summary>
        /// Tests the <see cref="StringExtensions.Unmention(string)"/> method.
        /// </summary>
        public class Unmention
        {
            /// <summary>
            /// Tests various successful cases.
            /// </summary>
            public class Successes
            {
                /// <summary>
                /// Tests whether the method responds appropriately to a successful case.
                /// </summary>
                /// <param name="value">String value that is being stripped of a mention.</param>
                [Theory]
                [InlineData("")]
                [InlineData("123")]
                [InlineData("abc")]
                [InlineData("123abc")]
                [InlineData("123.456")]
                [InlineData("<123>")]
                [InlineData("@abc")]
                [InlineData("<@abc>")]
                public void ReturnsInputValueForValueWithoutMention(string value)
                {
                    var actual = value.Unmention();

                    Assert.Equal(value, actual);
                }

                /// <summary>
                /// Tests whether the method responds appropriately to a successful case.
                /// </summary>
                /// <param name="value">String value that is being stripped of a mention.</param>
                /// <param name="expected">Expected return value with the mention removed.</param>
                [Theory]
                [InlineData("<@123>", "123")]
                [InlineData("<@!123>", "123")]
                [InlineData("<#123>", "123")]
                [InlineData("<@&123>", "123")]
                public void ReturnsUnmentionedValueForValueWithMention(string value, string expected)
                {
                    var actual = value.Unmention();

                    Assert.Equal(expected, actual);
                }
            }
        }
    }
}

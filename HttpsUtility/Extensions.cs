/*
 * Copyright (c) Troy Garner 2019 - Present
 *
 * Permission is hereby granted, free of charge, to any person obtaining a
 * copy of this software and associated documentation files (the "Software"),
 * to deal in the Software without restriction, including without limitation
 * the rights to use, copy, modify, merge, publish, distribute, sublicense,
 * and/or sell copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
 * OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
 * THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
 * IN THE SOFTWARE.
 *
*/

using System;

namespace HttpsUtility
{
    /// <summary>
    /// Class for generic extension methods
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        /// Returns a null string if input is an empty string.
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>Null if empty, otherwise the input itself</returns>
        public static string NullIfEmpty(this string input)
        {
            return input == string.Empty ? null : input;
        }
        
        /// <summary>
        /// Returns an empty string if input is a null string.
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>Empty string if null, otherwise the input itself</returns>
        public static string EmptyIfNull(this string input)
        {
            return input ?? string.Empty;
        }

        /// <summary>
        /// Check to see if a flags enumeration has a specific flag set.
        /// </summary>
        /// <param name="variable">Flags enumeration to check</param>
        /// <param name="value">Flag to check for</param>
        /// <returns></returns>
        public static bool HasFlag(this Enum variable, Enum value)
        {
            if (variable == null)
                return false;

            if (value == null)
                throw new ArgumentNullException("value");

            // Not as good as the .NET 4 version of this function, but should be good enough
            if (!Enum.IsDefined(variable.GetType(), value))
            {
                throw new ArgumentException(string.Format(
                    "Enumeration type mismatch.  The flag is of type '{0}', was expecting '{1}'.",
                    value.GetType(), variable.GetType()));
            }

            ulong num = Convert.ToUInt64(value);
            return (Convert.ToUInt64(variable) & num) == num;
        }
    }
}
#region Foreign-License
// .Net40 Kludge
#endregion
#if !CLR4
namespace System.Web
{
    /// <summary>
    /// HttpEncoderUtility
    /// </summary>
    internal static class HttpEncoderUtility
    {
        // Methods
        /// <summary>
        /// Hexes to int.
        /// </summary>
        /// <param name="h">The h.</param>
        /// <returns></returns>
        public static int HexToInt(char h)
        {
            if (h >= '0' && h <= '9')
                return (h - '0');
            if (h >= 'a' && h <= 'f')
                return ((h - 'a') + 10);
            if (h >= 'A' && h <= 'F')
                return ((h - 'A') + 10);
            return -1;
        }

        /// <summary>
        /// Ints to hex.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        public static char IntToHex(int n)
        {
            if (n <= 9)
                return (char)(n + 0x30);
            return (char)((n - 10) + 0x61);
        }

        /// <summary>
        /// Determines whether [is URL safe char] [the specified ch].
        /// </summary>
        /// <param name="ch">The ch.</param>
        /// <returns>
        ///   <c>true</c> if [is URL safe char] [the specified ch]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsUrlSafeChar(char ch)
        {
            if (((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z')) || (ch >= '0' && ch <= '9'))
                return true;
            switch (ch)
            {
                case '(':
                case ')':
                case '*':
                case '-':
                case '.':
                case '_':
                case '!':
                    return true;
            }
            return false;
        }

        internal static string UrlEncodeSpaces(string str)
        {
            if ((str != null) && (str.IndexOf(' ') >= 0))
                str = str.Replace(" ", "%20");
            return str;
        }
    }
}
#endif
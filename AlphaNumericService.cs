using System;

namespace Alphadex
{
    public class AlphaNumericService
    {
        static char[] _characters;
        static int _count;

        public AlphaNumericService() : this("ABCDEFGHIJKLMNOPQRSTUVWXYZ") { }

        public AlphaNumericService(string characterString)
        {
            _characters = characterString.ToCharArray();
            _count = _characters.Length;
        }

        /// <summary>
        /// Gets the Value at the specified index
        /// </summary>
        /// <param name="index">Zero based index</param>
        /// <returns></returns>
        public string GetString(int index)
        {
            if (index > _characters.Length - 1)
            {
                var mod = index % _count;

                var prefixIndex = Math.Floor(Convert.ToDouble(index / _count)) - 1;
                var prefix = GetString(Convert.ToInt32(prefixIndex));
                return string.Concat(prefix, GetString(mod));
            }
            return _characters.GetValue(index).ToString();
        }
    }
}

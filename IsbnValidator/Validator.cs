namespace IsbnValidator
{
    public static class Validator
    {
        /// <summary>
        /// Returns true if the specified <paramref name="isbn"/> is valid; returns false otherwise.
        /// </summary>
        /// <param name="isbn">The string representation of 10-digit ISBN.</param>
        /// <returns>true if the specified <paramref name="isbn"/> is valid; false otherwise.</returns>
        /// <exception cref="ArgumentException"><paramref name="isbn"/> is empty or has only white-space characters.</exception>
        public static bool IsIsbnValid(string isbn)
        {
            if (string.IsNullOrEmpty(isbn) || isbn == "    ")
            {
                throw new ArgumentException(isbn);
            }

            string new_isbn = string.Empty;
            for (int i = 0; i < isbn.Length; i++)
            {
                if (isbn[i] != '-')
                {
                    new_isbn += isbn[i];
                }
                else
                {
                    if (i != 1 && i != 5 && i != 11)
                    {
                        return false;
                    }
                }
            }

            int n = new_isbn.Length;
            if (n != 10)
            {
                return false;
            }

            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                int digit = new_isbn[i] - '0';
                if (digit < 0 || digit > 9)
                {
                    return false;
                }

                sum += digit * (10 - i);
            }

            char last = new_isbn[9];
            if (last != 'X' && (last < '0' || last > '9'))
            {
                return false;
            }

            sum += (last == 'X') ? 10 : (last - '0');
            return sum % 11 == 0;
        }
    }
}

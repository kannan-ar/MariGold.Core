namespace MariGold
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Represent an extended instant of System.DateTime which is capable to convert directly from string and vice versa.
    /// </summary>
    [StructLayout(LayoutKind.Auto)]
    public struct Date
    {
        private DateTime? value;

        /// <summary>
        /// Returns true if the value is null.
        /// </summary>
        public bool HasValue
        {
            get
            {
                return value != null;
            }
        }

        /// <summary>
        /// Return the DateTime value. Throws null reference exception if the value is null.
        /// </summary>
        /// <returns></returns>
        public DateTime ToDateTime()
        {
            if (!HasValue)
            {
                throw new NullReferenceException("value");
            }
            
            return value.Value;
        }

        /// <summary>
        /// Try to convert date value as DateTime.  If the conversion done successfully, assigns the internal value and return true.
        /// </summary>
        /// <param name="date">String formatted DateTime value</param>
        /// <param name="format">Format specifier</param>
        /// <param name="provider">Culture-specific formatting info</param>
        /// <param name="style">System.Globalization.DateTimeStyles value</param>
        /// <returns></returns>
        public bool SetDate(
           string date,
           string format,
           IFormatProvider provider = null,
           System.Globalization.DateTimeStyles style = System.Globalization.DateTimeStyles.None)
        {
            DateTime dt;
            bool success = DateTime.TryParseExact(date, format, provider, style, out dt);

            if (success)
            {
                value = dt;
            }

            return success;
        }

        /// <summary>
        /// Create a Date instant from string formatted DateTime Value.
        /// </summary>
        /// <param name="date">String formatted DateTime value</param>
        /// <returns>Date instant</returns>
        public static implicit operator Date(string date)
        {
            DateTime dt;

            if (DateTime.TryParse(date, out dt))
            {
                return new Date() { value = dt };
            }
            else
            {
                return new Date();
            }
        }

        /// <summary>
        /// Creates a new Date instance from given DateTime instance.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static implicit operator Date(DateTime date)
        {
            return new Date() { value = date };
        }

        /// <summary>
        /// Converts the Date instance to Datetime instance. Throws NullReferenceException if the value is null
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static implicit operator DateTime(Date d)
        {
            return d.ToDateTime();
        }

        /// <summary>
        /// Compare two Date instances with internal DateTime value.
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public static bool operator ==(Date d1, Date d2)
        {
            if (d1.value == null || d2.value == null)
            {
                return false;
            }

            return d1.value == d2.value;
        }

        public static bool operator !=(Date d1, Date d2)
        {
            if (d1.value == null || d2.value == null)
            {
                return true;
            }

            return d1.value != d2.value;
        }

        public static bool operator >(Date d1, Date d2)
        {
            if (d1.value == null || d2.value == null)
            {
                throw new ArgumentNullException();
            }

            return d1.value > d2.value;
        }

        public static bool operator <(Date d1, Date d2)
        {
            if (d1.value == null || d2.value == null)
            {
                throw new ArgumentNullException();
            }

            return d1.value < d2.value;
        }

        public static bool operator >=(Date d1, Date d2)
        {
            if (d1.value == null || d2.value == null)
            {
                throw new ArgumentNullException();
            }

            return d1.value >= d2.value;
        }

        public static bool operator <=(Date d1, Date d2)
        {
            if (d1.value == null || d2.value == null)
            {
                throw new ArgumentNullException();
            }

            return d1.value <= d2.value;
        }

        /// <summary>
        /// If the internal DateTime value is null, returns empty string. Otherwise ToString the internal DateTime value.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (value == null)
            {
                return string.Empty;
            }

            return value.ToString();
        }

        //Need more research to check whether the Equals method implemented correctly.
        public override bool Equals(object obj)
        {
            //If value is null, should I use base.Equals method?
            if (value == null)
            {
                return false;
            }

            if(obj is Date)
            {
                Date d = (Date)obj;

                return d.value == value.Value;
            }
            else if(obj is DateTime)
            {
                DateTime d = (DateTime)obj;

                return d == value.Value;
            }

            return false;
        }

        /// <summary>
        /// If the value is null, execute base.GetHashCode(). Otherwise value.GetHashCode()
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return value == null ? base.GetHashCode() : value.Value.GetHashCode();
        }
    }

}

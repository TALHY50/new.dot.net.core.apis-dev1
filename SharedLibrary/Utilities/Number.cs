namespace SharedLibrary.Utilities
{
    public class Number
    {
        public static decimal ToDecimal(decimal? value, int decimals = 4)
        {
            if (value == null)
            {
                return 0;
            }
            return Math.Round((decimal)value, decimals);
        }
        
        
        public static decimal ToDecimal(double? value, int decimals = 4)
        {
            return ToDecimal(Convert.ToDecimal(value), decimals);
        }
        
        
        public static decimal ToDecimal(int ? value, int decimals = 4)
        {
            return ToDecimal(Convert.ToDecimal(value), decimals);
        }


        public static double ToDouble(decimal value, int decimals = 4)
        {
            return Math.Round((double)value, decimals);
        }
        
        
        
        public static double ToDouble(double value, int decimals = 4)
        {
            return Math.Round(value, decimals);
        }

        public static double ToDouble(double? value, int decimals = 4)
        {
            if (value == null)
            {
                return 0;
            }
            
            return Math.Round((double) value, decimals);
        }
        
        
        public static int ToInt(uint? value)
        {
            return Convert.ToInt32(value);
        }
        
        
        public static int ToInt(string value)
        {
            return Convert.ToInt32(value);
        }
        
        public static int ToInt(int? value)
        {
            return Convert.ToInt32(value);
        }
        
        public static uint ToUInt(int? value)
        {
            return Convert.ToUInt32(value);
        }
        
        public static sbyte ToSbyte(int? value)
        {
            return Convert.ToSByte(value);
        }
        
        public static sbyte ToSbyte(bool? value)
        {
            return Convert.ToSByte(value);
        }


        public static string? ToString(int? value)
        {
            return value.ToString();
        }
        
        public static string? ToString(decimal? value)
        {
            return value.ToString();
        }
        
        public static string? ToString(uint? value)
        {
            return value.ToString();
        }


        public static string? ToString(double? value, int decimals = 4)
        {
            return value.ToString();
        }
        
        
        public static uint ToUInt(uint? value)
        {
            return (uint)value;
        }


        public static decimal ToDecimal(string descriptionTotalAmount)
        {
            return Convert.ToDecimal(descriptionTotalAmount);
        }
    }
}

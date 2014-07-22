using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BioPM.ClassEngines
{
    //last 2013,
    //Perform Indonesian Date Format.

    public class DateFormatFactory
    {
        public static String GetDay(string date)
        {
            return (Convert.ToDateTime(date).Day.ToString());
        }

        public static String GetMonth(string date)
        {
            return (Convert.ToDateTime(date).Month.ToString());
        }

        public static String GetYear(string date)
        {
            return (Convert.ToDateTime(date).Year.ToString());
        }

        public static String GetMonthFromEnum(string month)
        {
            switch (month.ToLower())
            {
                case "januari":
                    {
                        return "01";
                    }
                case "februari":
                    {
                        return "02";
                    }
                case "maret":
                    {
                        return "03";
                    }
                case "april":
                    {
                        return "04";
                    }
                case "mei":
                    {
                        return "05";
                    }
                case "juni":
                    {
                        return "06";
                    }
                case "juli":
                    {
                        return "07";
                    }
                case "agustus":
                    {
                        return "08";
                    }
                case "september":
                    {
                        return "09";
                    }
                case "oktober":
                    {
                        return "10";
                    }
                case "november":
                    {
                        return "11";
                    }
                case "desember":
                    {
                        return "12";
                    }
                default : { return "01"; }
            }
        }

        enum bulan : int
        {
            Januari = 1, Februari, Maret, April, Mei, Juni, Juli, Agustus, September, Oktober, November, Desember
        }

        private static T1 NumToEnum<T1>(int number)
        {
            return (T1)Enum.ToObject(typeof(T1), number);
        }

        public static String GetDateFormat(string date)
        {
            return GetDay(date) + " " + NumToEnum<bulan>(Convert.ToInt16(GetMonth(date))) + " " + GetYear(date);
        }

        public static String enumToString(string month)
        {
            switch (month.ToLower())
            {
                case "01":
                    {
                        return "Januari";
                    }
                case "02":
                    {
                        return "Februari";
                    }
                case "03":
                    {
                        return "Maret";
                    }
                case "04":
                    {
                        return "April";
                    }
                case "05":
                    {
                        return "Mei";
                    }
                case "06":
                    {
                        return "Juni";
                    }
                case "07":
                    {
                        return "Juli";
                    }
                case "08":
                    {
                        return "Agustus";
                    }
                case "09":
                    {
                        return "September";
                    }
                case "10":
                    {
                        return "Oktober";
                    }
                case "11":
                    {
                        return "November";
                    }
                case "12":
                    {
                        return "Desember";
                    }
                default: { return "01"; }
            }
        }
    }
}
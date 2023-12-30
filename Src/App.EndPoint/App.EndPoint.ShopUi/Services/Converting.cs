﻿using MD.PersianDateTime.Core;
using System.Globalization;
using System.Reflection;


namespace App.EndPoint.ShopUi.Services
{
    public  class Converting:IConverting
    {
        public DateTime ConvertShamsiToMiladi(string Date)
        {

            PersianDateTime persianDateTime = PersianDateTime.Parse(Date);
                return persianDateTime.ToDateTime();

        }

        public string ConvertMiladiToShamsi(DateTime Date, string Format)
        {
            PersianDateTime persianDateTime = new PersianDateTime(Date);
            return persianDateTime.ToString(Format);
        }
    }
}

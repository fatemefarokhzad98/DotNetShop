using System.Globalization;
using System.Reflection;

namespace App.EndPoint.ShopUi.Services
{
    public static class Converting
    {
        public static  DateTime PersianDateStringToDateTime(this string persianDate)
        {
            PersianCalendar pc = new PersianCalendar();

            var persianDateSplitedParts = persianDate.Split('/');
            DateTime dateTime = new DateTime(int.Parse(persianDateSplitedParts[0]), int.Parse(persianDateSplitedParts[1]), int.Parse(persianDateSplitedParts[2]), pc);
            return DateTime.Parse(dateTime.ToString(CultureInfo.CreateSpecificCulture("en-US")));
        }

        public static T Casting<T>(this Object source)
        {
            Type sourceType = source.GetType();
            Type targetType = typeof(T);
            var target = Activator.CreateInstance(targetType, false);
            var sourceMembers = sourceType.GetMembers()
                .Where(x => x.MemberType == MemberTypes.Property)
                .ToList();
            var targetMembers = targetType.GetMembers()
                .Where(x => x.MemberType == MemberTypes.Property)
                .ToList();
            var members = targetMembers
                .Where(x => sourceMembers
                    .Select(y => y.Name)
                        .Contains(x.Name));
            PropertyInfo propertyInfo;
            object value;
            foreach (var memberInfo in members)
            {
                propertyInfo = typeof(T).GetProperty(memberInfo.Name);
                value = source.GetType().GetProperty(memberInfo.Name).GetValue(source, null);
                propertyInfo.SetValue(target, value, null);
            }
            return (T)target;
        }
    }
}

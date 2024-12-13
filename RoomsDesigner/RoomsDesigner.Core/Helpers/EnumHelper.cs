using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace RoomsDesigner.Core.Helpers
{
	public static class EnumHelper
	{
		public static string GetDescription(Enum value)
		{
			if (value == null)
			{
				return string.Empty;
			}

			var data = value.ToString();

			var field = value.GetType().GetField(data);
			var attribute = (DescriptionAttribute)field.GetCustomAttribute(typeof(DescriptionAttribute), false);

			return attribute != null ? attribute.Description : string.Empty;
		}

		public static List<TEnum> ToList<TEnum>() where TEnum : struct
		{
			var enumType = typeof(TEnum);

			if (enumType.BaseType != typeof(Enum))
			{
				throw new ArgumentException("TEnum should be of type System.Enum");
			}

			var enumValueArray = Enum.GetValues(enumType);
			var enumValueList = new List<TEnum>(enumValueArray.Length);

			foreach (int value in enumValueArray)
			{
				enumValueList.Add((TEnum)Enum.Parse(enumType, value.ToString()));
			}

			return enumValueList;
		}
	}
}

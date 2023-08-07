using System;
using System.Collections.Generic;

namespace DevFormDemo
{

    public static class EnumHelper
    {
        /// <summary>
        /// 根据传入枚举类型，返回枚举的
        /// </summary>
        /// <typeparam name="TEnum">指定的枚举类型</typeparam>
        /// <returns></returns>
        public static List<TEnum> Create<TEnum>() where TEnum : Enum
        {
            var itemSource = new List<TEnum>();
            foreach (var item in Enum.GetNames(typeof(TEnum)))
            {
                itemSource.Add((TEnum)Enum.Parse(typeof(TEnum), item));
            };

            return itemSource;
        }
    }
}

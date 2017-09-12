using System;
using System.Reflection;

namespace WebApplication2.Extensions
{
    public static class GenericExtensions
    {
        public static void Update<TItem>(this TItem item, TItem newItem)
        {
            Type itemType = typeof(TItem);

            if (itemType.IsPrimitive) return;

            foreach (PropertyInfo oldItemPropertyInfo in itemType.GetProperties())
            {
                PropertyInfo newItemPropertyInfo = newItem.GetType().GetProperty(oldItemPropertyInfo.Name);

                if (newItemPropertyInfo?.SetMethod != null)
                {
                    oldItemPropertyInfo.SetValue(item, newItemPropertyInfo.GetValue(newItem));
                }
            }
        }
        
        public static void Update<TItem>(this TItem item, TItem newItem, object ignoredProperties)
        {
            Type itemType = typeof(TItem);

            if (itemType.IsPrimitive) return;

            foreach (PropertyInfo oldItemPropertyInfo in itemType.GetProperties())
            {
                PropertyInfo newItemPropertyInfo = newItem.GetType().GetProperty(oldItemPropertyInfo.Name);

                PropertyInfo ignoredProperty = ignoredProperties.GetType().GetProperty(oldItemPropertyInfo.Name);

                if (ignoredProperty == null && newItemPropertyInfo?.SetMethod != null)
                {
                    oldItemPropertyInfo.SetValue(item, newItemPropertyInfo.GetValue(newItem));
                }
            }
        }
    }
}
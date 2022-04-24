using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace HyperCasualDeveloperKit.EditorSetup
{
    public static class AttributeUtility
    {
        //
        // T で指定したプロパティを1つだけ取得
        //

        // 型を指定して Public プロパティの属性を取得する
        public static T GetPropertyAttribute<T>(Type type, string name) where T : Attribute
        {
            var prop = type.GetProperty(name);
            if (prop == null)
            {
                Trace.WriteLine($"Property is not found. {name}");
                return default; // 指定したプロパティが見つからない
            }
            var att = prop.GetCustomAttribute<T>();
            if (att == null)
            {
                Trace.WriteLine($"Attribute is not found. {name}");
                return default; // 指定した属性が付与されていない
            }
            return att;
        }

        //
        // プロパティについている属性を全部取得
        //

        // インスタンスを指定して Public プロパティの属性を取得します。
        public static T GetPropertyAttribute<T>(object instance, string name) where T : Attribute
        {
            return GetPropertyAttribute<T>(instance.GetType(), name);
        }

        // 型を指定して Public プロパティに付与されているすべてのプロパティを取得する
        public static IEnumerable<Attribute> GetPropertyAttributes(Type type, string name)
        {
            var prop = type.GetProperty(name);
            if (prop == null)
            {
                Trace.WriteLine($"Property is not found. {name}");
                return default;
            }

            return prop.GetCustomAttributes<Attribute>();
        }

        // インスタンスを指定して Public プロパティに付与されているすべてのプロパティを取得する
        public static IEnumerable<Attribute> GetPropertyAttributes(object instance, string name)
        {
            return GetPropertyAttributes(instance.GetType(), name);
        }
    }
}
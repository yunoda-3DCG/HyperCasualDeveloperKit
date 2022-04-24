using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace HyperCasualDeveloperKit.EditorSetup
{
	public class EditorStartup
	{
		private static readonly string _TmpFilePath = "Temp/VketCloudStartup";

		[InitializeOnLoadMethod]
		private static void Initialized()
		{
			if (!File.Exists(_TmpFilePath))
			{
				File.Create(_TmpFilePath);

				var editorAssembliesType = typeof(Editor).Assembly.GetType("UnityEditor.EditorAssemblies");
				var getAllMethodsWithAttributeMethod = editorAssembliesType.GetMethod("Internal_GetAllMethodsWithAttribute", BindingFlags.NonPublic | BindingFlags.Static);
				var methods = (object[])getAllMethodsWithAttributeMethod.Invoke(null, new object[] { typeof(EditorStartupAttribute), BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic });

				foreach (var method in methods.Cast<MethodInfo>())
				{
					try
					{
						method.Invoke(null, new object[] { });
					}
					catch (TargetInvocationException e)
					{
						Debug.LogError(e.InnerException);
					}
				}
			}
		}
	}
}
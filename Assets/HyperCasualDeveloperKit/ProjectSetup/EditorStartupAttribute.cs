using System;

namespace HyperCasualDeveloperKit.EditorSetup
{
	/// <summary>
	/// Editorが起動した時のみ実行されるイベントを設定する為の属性。
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	public class EditorStartupAttribute : Attribute { }
}
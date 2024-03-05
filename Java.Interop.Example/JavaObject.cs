using System.Diagnostics.CodeAnalysis;

namespace Java.Interop;

[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)]
public class JavaObject
{
	/// <summary>
	/// Imagine this value comes from JNI
	/// </summary>
	public IntPtr Handle { get; private set; }
}

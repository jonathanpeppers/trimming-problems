namespace Java.Interop;

public class JavaObject
{
	/// <summary>
	/// Imagine this value comes from JNI
	/// </summary>
	public IntPtr Handle { get; private set; }
}

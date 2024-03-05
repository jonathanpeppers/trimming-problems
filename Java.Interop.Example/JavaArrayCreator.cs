using System.Diagnostics.CodeAnalysis;

namespace Java.Interop;

public static class JavaArrayCreator
{
	[UnconditionalSuppressMessage("AOT", "IL3050", Justification = "TODO this is probably broken")]
	static Array CreateArray(Type type, int length) =>
		Array.CreateInstance(type, length);

	[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)]
	static Type GetElementType(Type type) =>
		type.GetElementType() ??
		throw new InvalidOperationException($"Type '{type}' does not have an element type!");

	/// <summary>
	/// Creates an Array of the specified type and length, and initializes each element with a new instance of the type.
	/// </summary>
	public static T[] Create<
			[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)]
			T
	>(int length)
	{
		var array = (T[])CreateArray(typeof(T), length);
		for (int i = 0; i < length; i++)
		{
			array[i] = Activator.CreateInstance<T>();
		}
		return array;
	}

	/// <summary>
	/// Creates an Array of the specified type and length, and initializes each element with a new instance of the type.
	/// </summary>
	/// <param name="type">Usage: typeof(Foo[])</param>
	public static Array Create(
			[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)]
			Type type,
			int length)
	{
		// If we generated this code, it would work
		// if (type == typeof(JavaObject[]))
		// {
		// 	return Create<JavaObject>(length);
		// }

		if (type.IsArray)
		{
			type = GetElementType(type);
		}
		if (type.IsEnum)
		{
			type = Enum.GetUnderlyingType(type);
		}
		var array = CreateArray(type, length);
		for (int i = 0; i < length; i++)
		{
			array.SetValue(Activator.CreateInstance(type), i);
		}
		return array;
	}

	public static void Fill(Array array)
	{
		var type = GetElementType(array.GetType());
		for (int i = 0; i < array.Length; i++)
		{
			array.SetValue(Activator.CreateInstance(type), i);
		}
	}
}

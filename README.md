# trimming-problems

"Mo' trimming, mo' problems"

This repo is for investigating usage of System.Reflection and how it
currently works in regards to trimming and/or NativeAOT.

So far, just testing APIs like:

```csharp
using Java.Interop;

const int length = 3;

var array1 = JavaArrayCreator.Create<JavaObject>(length);
Console.WriteLine(array1.Length);
foreach (var item in array1)
{
    Console.WriteLine(item is null);
}

var array2 = JavaArrayCreator.Create(typeof(JavaObject[]), length);
Console.WriteLine(array2.Length);
foreach (var item in array2)
{
    Console.WriteLine(item is null);
}
```

If you use the second API, `JavaObject`'s ctor can get trimmed away:
```csharp
Unhandled exception. System.MissingMethodException: Cannot dynamically create an instance of type 'Java.Interop.JavaObject'. Reason: No parameterless constructor defined.
   at System.RuntimeType.ActivatorCache..ctor(RuntimeType)
   at System.RuntimeType.CreateInstanceDefaultCtor(Boolean, Boolean)
   at System.Activator.CreateInstance(Type, Boolean, Boolean)
   at System.Activator.CreateInstance(Type , Boolean)
   at System.Activator.CreateInstance(Type )
   at Java.Interop.JavaArrayCreator.Create(Type , Int32) in D:\src\trimming-problems\Java.Interop.Example\JavaArrayCreator.cs:line 54
   at Program.<Main>$(String[]) in D:\src\trimming-problems\trimming-problems\Program.cs:line 13
```


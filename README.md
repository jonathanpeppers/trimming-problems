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

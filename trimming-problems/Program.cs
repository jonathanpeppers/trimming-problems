using Java.Interop;

const int length = 3;

// Uncomment will fix expression below
// var array1 = JavaArrayCreator.Create<JavaObject>(length);
// Console.WriteLine(array1.Length);
// foreach (var item in array1)
// {
// 	Console.WriteLine(item is null);
// }

var array2 = JavaArrayCreator.Create(typeof(JavaObject[]), length);
Console.WriteLine(array2.Length);
foreach (var item in array2)
{
	Console.WriteLine(item is null);
}

// Another example:
// var empty = new JavaObject[length];
// JavaArrayCreator.Fill(empty);
// Console.WriteLine(empty.Length);
// foreach (var item in empty)
// {
// 	Console.WriteLine(item is null);
// }

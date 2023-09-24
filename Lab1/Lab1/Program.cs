
using Lab1;

CustomQueue<int> cqueue = new CustomQueue<int>(new List<int>(){1, 2, 3, 4});
int[] arr = new int[] {11, 12, 13, 14, 15, 16, 17};
cqueue.CopyTo(arr, 1);
foreach (var el in arr)
    Console.WriteLine(el);










/*cqueue.Enqueue(5);
foreach(var element in cqueue)
    Console.WriteLine(element);*/
    
/*var poped_element = cqueue.Dequeue();
Console.WriteLine($"Dequeued element is: {poped_element}");
Console.WriteLine("Collection elements are:");
foreach(var element in cqueue)
    Console.WriteLine(element);*/   
    
/*cqueue.Clear();
foreach(var element in cqueue)
    Console.WriteLine(element);*/
    
/*var hasThree = cqueue.Contains(3);
var hasTen = cqueue.Contains(10);
Console.WriteLine($"has 3: {hasThree}, has 10: {hasTen}");*/

/*int[] arr = cqueue.ToArray();
foreach (var el in arr)
    Console.WriteLine(el);*/

/*cqueue = cqueue.Reverse();
foreach (var el in cqueue)
    Console.WriteLine(el);*/
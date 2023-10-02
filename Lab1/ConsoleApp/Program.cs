
using System.Numerics;
using MyLibrary;

void EnqueueHandler (object? sender, EventArgs e) => Console.WriteLine("Enquque operation completed");
void DequeueHandler (object? sender, EventArgs e) => Console.WriteLine("Dequque operation completed");
void ClearHandler (object? sender, EventArgs e) => Console.WriteLine("Clear operation completed");
void CopiedToHandler (object? sender, EventArgs e) => Console.WriteLine("Copy operation completed");
void ReversedHandler (object? sender, EventArgs e) => Console.WriteLine("Reverse operation completed");

void EnqueueTest<T>(T enqueueElement, IEnumerable<T>? list) where T : IComparable
{
    CustomQueue<T> cqueue = new CustomQueue<T>(list);
    cqueue.OnEnqueued += EnqueueHandler;
    cqueue.Enqueue(enqueueElement);
    
    Console.WriteLine("Enqueued elements:");
    foreach(var element in cqueue)
        Console.WriteLine(element);
}
EnqueueTest(12, new int[]{});

void DequeueTest<T>(IEnumerable<T>? list) where T : IComparable
{
    CustomQueue<T> cqueue = new CustomQueue<T>(list);
    cqueue.OnDequeued += DequeueHandler;
    var poped_element = cqueue.Dequeue();
    
    Console.WriteLine($"Dequeued element is: {poped_element}");
    Console.WriteLine("Collection elements are:");
    foreach(var element in cqueue)
        Console.WriteLine(element);
} 
DequeueTest(new List<int>(){1, 12, 54, 190});
 
void ClearTest<T>(IEnumerable<T>? list) where T : IComparable
{
    CustomQueue<T> cqueue = new CustomQueue<T>(list);
    cqueue.OnCleared += ClearHandler;
    cqueue.Clear();
    
    Console.WriteLine("Collection elements are:");
    foreach(var element in cqueue)
        Console.WriteLine(element);
}  
ClearTest(new List<string>(){"a", "b", "c"});

void ContainsTest<T>(T checkedElement, IEnumerable<T>? list) where T : IComparable
{
    CustomQueue<T> cqueue = new CustomQueue<T>(list);
    var hasElement = cqueue.Contains(checkedElement);
    Console.WriteLine($"has {checkedElement}: {hasElement}");
}
ContainsTest(5, new []{3, 5, 11});

void ToArrayTest<T>(IEnumerable<T>? list) where T : IComparable
{
    CustomQueue<T> cqueue = new CustomQueue<T>(list);
    T[] arr = cqueue.ToArray();
    
    Console.WriteLine("Array elements are:");
    foreach (var el in arr)
        Console.WriteLine(el);
}
ToArrayTest(new bool[]{true, false, false, true});

void ReverseTest<T>(IEnumerable<T>? list) where T : IComparable
{
    CustomQueue<T> cqueue = new CustomQueue<T>(list);
    cqueue.OnReversed += ReversedHandler;
    cqueue = cqueue.Reverse();
    
    Console.WriteLine("Collection elements are:");
    foreach (var el in cqueue)
        Console.WriteLine(el);
}
ReverseTest(new int[]{11, 13, 15, 17});

void CopyToTest<T>(T[] insertArray, int startIndex, IEnumerable<T>? list) where T : IComparable
{
    CustomQueue<T> cqueue = new CustomQueue<T>(list);
    cqueue.OnCopiedTo += CopiedToHandler;
    cqueue.CopyTo(insertArray, startIndex);
    
    Console.WriteLine("Array elements are:");
    foreach (var el in insertArray)
        Console.WriteLine(el);
}    

CopyToTest(new int[]{10, 11, 12, 13, 14, 15, 16}, 2, new List<int>(){100, 101, 102});

void PeekTest<T>(IEnumerable<T>? list) where T : IComparable
{
    CustomQueue<T> cqueue = new CustomQueue<T>(list);
    Console.WriteLine($"Peek element is {cqueue.Peek()}");
}

PeekTest(new List<string>(){"a", "b", "c"});  
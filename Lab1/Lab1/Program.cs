
using System.Numerics;
using MyLibrary;

void EnqueueHandler (object? sender, EventArgs e) => Console.WriteLine("Enquque operation completed");
void DequeueHandler (object? sender, EventArgs e) => Console.WriteLine("Dequque operation completed");
void ClearHandler (object? sender, EventArgs e) => Console.WriteLine("Clear operation completed");
void CopiedToHandler (object? sender, EventArgs e) => Console.WriteLine("Copy operation completed");
void ReversedHandler (object? sender, EventArgs e) => Console.WriteLine("Reverse operation completed");


void EnqueueTest<T>(T enqueueElement, List<T>? list) where T : IComparable
{
    CustomQueue<T> cqueue = new CustomQueue<T>(list);
    cqueue.OnEnqueued += EnqueueHandler;
    cqueue.Enqueue(enqueueElement);
    
    Console.WriteLine("Enqueued elements:");
    foreach(var element in cqueue)
        Console.WriteLine(element);
}

void DequeueTest<T>(List<T>? list) where T : IComparable
{
    CustomQueue<T> cqueue = new CustomQueue<T>(list);
    cqueue.OnDequeued += DequeueHandler;
    var poped_element = cqueue.Dequeue();
    
    Console.WriteLine($"Dequeued element is: {poped_element}");
    Console.WriteLine("Collection elements are:");
    foreach(var element in cqueue)
        Console.WriteLine(element);
}   
 
void ClearTest<T>(List<T>? list) where T : IComparable
{
    CustomQueue<T> cqueue = new CustomQueue<T>(list);
    cqueue.OnCleared += ClearHandler;
    cqueue.Clear();
    
    Console.WriteLine("Collection elements are:");
    foreach(var element in cqueue)
        Console.WriteLine(element);
}     

void ContainsTest<T>(T checkedElement, List<T>? list) where T : IComparable
{
    CustomQueue<T> cqueue = new CustomQueue<T>(list);
    var hasElement = cqueue.Contains(checkedElement);
    Console.WriteLine($"has {checkedElement}: {hasElement}");
}

void ToArrayTest<T>(List<T>? list) where T : IComparable
{
    CustomQueue<T> cqueue = new CustomQueue<T>(list);
    T[] arr = cqueue.ToArray();
    
    Console.WriteLine("Array elements are:");
    foreach (var el in arr)
        Console.WriteLine(el);
}


void ReverseTest<T>(List<T>? list) where T : IComparable
{
    CustomQueue<T> cqueue = new CustomQueue<T>(list);
    cqueue.OnReversed += ReversedHandler;
    cqueue = cqueue.Reverse();
    
    Console.WriteLine("Collection elements are:");
    foreach (var el in cqueue)
        Console.WriteLine(el);
}

void CopyToTest<T>(T[] insertArray, int startIndex, List<T>? list) where T : IComparable
{
    CustomQueue<T> cqueue = new CustomQueue<T>(list);
    cqueue.OnCopiedTo += CopiedToHandler;
    cqueue.CopyTo(insertArray, startIndex);
    
    Console.WriteLine("Array elements are:");
    foreach (var el in insertArray)
        Console.WriteLine(el);
}    

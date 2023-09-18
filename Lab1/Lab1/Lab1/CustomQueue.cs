using System.Collections;


namespace Lab1;

public class CustomQueue <T>: IEnumerable<T>
{
    public int Count { get; }
    public bool IsSynchronized { get; }
    public object SyncRoot { get; }
    
    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public void CopyTo(Array array, int index)
    {
        throw new NotImplementedException();
    }

    public void Enqueue(T item)
    {
        throw new NotImplementedException();
    }
    
    public T Dequeue()
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public T Peek()
    {
        throw new NotImplementedException();
    }

    public void SetCapacity(int capacity)
    {
        throw new NotImplementedException();
    }

    public int EnsureCapacity(int capacity)
    {
        throw new NotImplementedException();
    }
}
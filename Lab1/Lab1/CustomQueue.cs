using System.Collections;


namespace Lab1;

public class CustomQueue <T>: IEnumerable<T>
{
    private int _size;
    
    public int Count { get; }
    public bool IsSynchronized { get; }
    public object SyncRoot { get; }
    
    
    public CustomQueue()
    {
            
    }
    
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
    
    private class MyEnumerator: IEnumerator<T> 
    {
        private Node<T> _activeNode;
        private Node<T> _headNode;

        public T Current => _activeNode.value;

        object IEnumerator.Current => Current;

        public MyEnumerator(Node<T> headNode)
        {
            _headNode = headNode;
            _activeNode = _headNode;
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            if (_headNode == null)
                return false;
            
            bool hasNext = _activeNode.next != null;
            if (!hasNext)
            {
                return false;
            }
            
            _activeNode = _activeNode.next;
            return hasNext;
        }

        public void Reset()
        {
            _activeNode = _headNode;
        }
        
    }
    
}


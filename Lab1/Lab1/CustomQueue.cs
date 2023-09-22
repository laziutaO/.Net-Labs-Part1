using System.Collections;


namespace Lab1;

public class CustomQueue <T>: IEnumerable<T>
{
    private int _size;
    private Node<T> _headNode;
    private Node<T> _tailNode;

    public int Count
    {
        get
        {
            return _size;
        }
    }

    public bool IsSynchronized { get; }
    public object SyncRoot { get; }
    
    
    public CustomQueue()
    {
        _headNode = null;
        _tailNode = null;
        _size= 0;
    }

    public CustomQueue(IEnumerable<T> collection)
    {
        foreach (var item in collection)
        {
            Enqueue(item);
        }
    }
    
    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return new MyEnumerator(_headNode);
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
        Node<T> node = new Node<T>(item);
        if (_headNode == null)
        {
            _headNode = node;
            _tailNode = node;
        }

        else
        {
            _tailNode.next = new Node<T>(item);
            _tailNode = _tailNode.next;
        }

        _size++;
    }
    
    public T Dequeue()
    {
        if (_headNode == null)
            throw new InvalidOperationException();

        T headNodeValue = _headNode.value;
        _headNode = _headNode.next;

        _size--;
        return headNodeValue;
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


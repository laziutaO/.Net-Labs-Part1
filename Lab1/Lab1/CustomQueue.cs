using System.Collections;


namespace Lab1;

public class CustomQueue <T>: IEnumerable<T> where T: IComparable
{
    private int _size;
    private Node<T> _headNode;
    private Node<T> _tailNode;

    public int Count => _size;

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
        _size = 0;
        foreach (var item in collection)
        {
            Enqueue(item);
        }
    }
    
    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    { 
        Node<T> currentNode = _headNode;
        while (currentNode != null)
        {
            yield return currentNode.value;
            currentNode = currentNode.next;
        }
    }

    public IEnumerator GetEnumerator()
    {
        return new MyEnumerator(_headNode);
    }

    public void CopyTo(T[] array, int index)
    {
        Node<T> activeNode = _headNode;
        if (index < 0 || index > array.Length - 1)
            throw new ArgumentOutOfRangeException();
        else if (array == null)
            throw new ArgumentNullException();
        else if (array.Length - index + 1 < _size)
            throw new ArgumentException();
        
        while (activeNode != null)
        {
            array[index] = activeNode.value;
            activeNode = activeNode.next;
            index++;
        }
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
        _headNode = null;
        _tailNode = null;
    }

    public bool Contains(T item)
    {
        Node<T> activeNode = _headNode;
        while (activeNode != null)
        {
            if (activeNode.value.Equals(item))
                return true;
            activeNode = activeNode.next;
        }

        return false;
    }

    public T Peek()
    {
        if (_size == 0)
            throw new InvalidOperationException();
        return _headNode.value;
    }
    
    
    private class MyEnumerator: IEnumerator<T> 
    {
        private Node<T> _activeNode;
        private Node<T> _headNode;
        private bool _beganEnumerating = false;

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
            
            else if(!_beganEnumerating)
            {
                _beganEnumerating = true;
                _activeNode = _headNode;
                return true;
            }
            
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


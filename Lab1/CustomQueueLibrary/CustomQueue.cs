using System;
using System.Collections;
using System.Linq;

namespace CustomQueueLibrary
{
    public class CustomQueue <T>: IEnumerable<T> where T: IComparable
    {
        private int _size;
    private Node<T> _headNode;
    private Node<T> _tailNode;
    
    private event EventHandler? OnEnqueued = (sender, eventArgs) 
        => Console.WriteLine("Enquque operation completed");
    private event EventHandler? OnDequeued = (sender, eventArgs) 
        => Console.WriteLine("Dequeue operation completed");
    private event EventHandler? OnCleared = (sender, eventArgs) 
        => Console.WriteLine("Clear operation completed");
    private event EventHandler? OnCopiedTo = (sender, eventArgs) 
        => Console.WriteLine("Copy operation completed");
    private event EventHandler? OnReversed = (sender, eventArgs) 
        => Console.WriteLine("Reverse operation completed");

    public int Count => _size;
    
    public CustomQueue()
    {
        _headNode = null;
        _tailNode = null;
        _size= 0;
    }

    public CustomQueue(IEnumerable<T> collection)
    {
        _headNode = null;
        _tailNode = null;
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
        if (array == null)
            throw new ArgumentNullException("Value can not be null");
        else if (index < 0 || index > array.Length - 1)
            throw new ArgumentOutOfRangeException("Index can not be out of range");
        else if (array.Length - index + 1 < _size)
            throw new ArgumentException("Number of the elements in CustomQueue is greater than the Array can contain");
        
        while (activeNode != null)
        {
            array[index] = activeNode.value;
            activeNode = activeNode.next;
            index++;
        }
        OnCopiedTo?.Invoke(this, new EventArgs());
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
        OnEnqueued?.Invoke(this, new EventArgs());
    }
    
    public T Dequeue()
    {
        if (_headNode == null)
            throw new InvalidOperationException("CustomQueue is empty");

        T headNodeValue = _headNode.value;
        _headNode = _headNode.next;

        _size--;
        OnDequeued?.Invoke(this, new EventArgs());
        return headNodeValue;
        
    }

    public void Clear()
    {
        _headNode = null;
        _tailNode = null;
        OnCleared?.Invoke(this, new EventArgs());
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
            throw new InvalidOperationException("CustomQueue is empty");
        
        return _headNode.value;
    }

    public T[] ToArray()
    {
        Node<T> activeNode = _headNode;
        T[] array = new T[_size];
        for (int i = 0; i < _size; i++)
        {
            array[i] = activeNode.value;
            activeNode = activeNode.next;
        }

        return array;
    }

    public CustomQueue<T> Reverse()
    {
        CustomQueue<T> reversed_queue;
        IEnumerable<T> tempArray;
        tempArray = this.ToArray().Reverse();
        reversed_queue = new CustomQueue<T>(tempArray);
        OnReversed?.Invoke(this, new EventArgs());
        return reversed_queue;
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
        
        public void Dispose()
        {
            
        }
    }
    }
}
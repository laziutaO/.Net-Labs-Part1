namespace Lab1;

public class Node<T>
{
    public Node<T> next;
    public T value;

    public Node(T value)
    {
        next = null;
        this.value = value;
    }
}
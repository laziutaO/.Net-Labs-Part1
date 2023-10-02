namespace MyLibrary;

public class Node<T>
{
    public Node<T>? Next { get; set; }
    public readonly T Value;

    public Node(T value)
    {
        Next = null;
        this.Value = value;
    }
}
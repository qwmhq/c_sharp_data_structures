namespace DataStructures;

public class SinglyLinkedListNode<T>
{
    public T Value { get; set; }
    public SinglyLinkedListNode<T>? Next { get; set; }

    public SinglyLinkedListNode(T value)
    {
        this.Value = value ?? throw new ArgumentNullException(nameof(value));
    }

}

public class SinglyLinkedList<T>
{
    public SinglyLinkedListNode<T>? Head { get; private set; }
    public SinglyLinkedListNode<T>? Tail { get; private set; }

    public int Count { get; private set; } = 0;

    public void AddHead(T value)
    {
        AddHead(new SinglyLinkedListNode<T>(value));
    }

    public void AddHead(SinglyLinkedListNode<T> node)
    {
        var temp = Head;

        Head = node;

        Head.Next = temp;

        if (Count == 0)
        {
            Tail = Head;
        }

        Count++;
    }

    public void AddTail(T value)
    {
        AddTail(new SinglyLinkedListNode<T>(value));
    }   

    public void AddTail(SinglyLinkedListNode<T> node)
    {
        if (Count == 0)
        {
            AddHead(node);
            return;
        }

        Tail!.Next = node;
        Tail = node;
        Count++;
    }

    public void RemoveHead()
    {
        if (Count == 0)
        {
            return;
        }

        if (Count == 1)
        {
            Head = null;
            Tail = null;
            Count--;
            return;
        }

        Head = Head!.Next;
        Count--;
    }

    public void RemoveTail()
    {
        if (Count == 0)
        {
            return;
        }
        
        if (Count == 1)
        {
            RemoveHead();
            return;
        }

        SinglyLinkedListNode<T>? currentNode = Head, previousNode = null;

        while (currentNode != null)
        {
            if (currentNode.Next == null) {
                previousNode!.Next = null;
                Tail = previousNode;
                Count--;
            }
            previousNode = currentNode;
            currentNode = currentNode.Next;
        } 
    }

    public SinglyLinkedListNode<T>? Find(T value)
    {
        var currentNode = Head;
        while (currentNode != null)
        {
            if (currentNode.Value!.Equals(value))
            {
                return currentNode;
            }
            currentNode = currentNode.Next;
        }
        return null;
    }

    public bool Contains(T value)
    {
        var currentNode = Head;
        while (currentNode != null)
        {
            if (currentNode.Value!.Equals(value))
            {
                return true;
            }
            currentNode = currentNode.Next;
        }
        return false;
    }

    public void Add(T value)
    {
        AddTail(value);
    }

    public bool Remove(T value)
    {
        if (Count == 0)
        {
            return false;
        }
        if (Head!.Value!.Equals(value))
        {
            RemoveHead();
            return true;
        }
        if (Tail!.Value!.Equals(value))
        {
            RemoveTail();
            return true;
        }

        SinglyLinkedListNode<T>? currentNode = Head, previousNode = null;

        while (currentNode != null)
        {
            if (currentNode.Value!.Equals(value))
            {
                previousNode!.Next = currentNode.Next;
                Count--;
            }
            previousNode = currentNode;
            currentNode = currentNode.Next;
        }

        return false;
    }
}
using System.Collections;

namespace DataStructures;

public class DoublyLinkedListNode<T>
{
    public T Value { get; }

    public DoublyLinkedListNode<T>? Previous { get; set; }

    public DoublyLinkedListNode<T>? Next { get; set; }

    public DoublyLinkedListNode(T value)
    {
        this.Value = value ?? throw new ArgumentNullException(nameof(value));
    }
}

public class DoublyLinkedList<T> : ICollection<T>
{
    public DoublyLinkedListNode<T>? Head { get; private set; }

    public DoublyLinkedListNode<T>? Tail { get; private set; }

    public void AddHead(T value)
    {
        AddHead(new DoublyLinkedListNode<T>(value));
    }

    public void AddHead(DoublyLinkedListNode<T> node)
    {
        var temp = Head;
        Head = node;

        if (Count == 0)
        {
            Tail = node;
        } 
        else 
        {
            Head.Next = temp;
            temp!.Previous = Head;
        }
        Count++;
    }

    public void AddTail(T value)
    {
        AddTail(new DoublyLinkedListNode<T>(value));
    }

    public void AddTail(DoublyLinkedListNode<T> node)
    {
        if (Count == 0)
        {
            AddHead(node);
            return;
        }

        var temp = Tail;
        Tail = node;

        temp!.Next = Tail;
        Tail.Previous = temp;

        Count++;
    }

    public void RemoveHead()
    {
        if (Count != 0)
        {
            Head = Head!.Next;

            if (Count == 1)
            {
                Tail = null;
            }
            else
            {
                Head!.Previous = null;
            }
            Count--;
        }
    }

    public void RemoveTail()
    {
        if (Count != 0)
        {
            if (Count == 1)
            {
                RemoveHead();
                return;
            }

            Tail = Tail!.Previous;
            Tail!.Next = null;
            Count--;
        }
    }

    public DoublyLinkedListNode<T>? Find(T value)
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

    // ICollection members
    public int Count { get; private set; } = 0;

    public bool IsReadOnly 
    {
        get { return false; }
    }

    public void Add(T item)
    {
        AddTail(item);
    }

    public void Clear()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }

    public bool Contains(T item)
    {
        var currentNode = Head;
        
        while (currentNode != null)
        {
            if (currentNode.Value!.Equals(item))
            {
                return true;
            }
            currentNode = currentNode.Next;
        }

        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        var currentNode = Head;
        
        while (currentNode != null)
        {
            array[arrayIndex++] = currentNode.Value;
            currentNode = currentNode.Next;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = Head;
        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Next;
        }
    }

    public IEnumerable<T> GetReverseEnumerator()
    {
        var currentNode = Tail;
        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Previous;
        }
    }

    public bool Remove(T item)
    {
        if (Count != 0)
        {
            if (Head!.Value!.Equals(item))
            {
                RemoveHead();
                return true;
            }
            else if (Tail!.Value!.Equals(item))
            {
                RemoveTail();
                return true;
            }

            var node = Find(item);
            if (node == null)
            {
                return false;
            }

            node!.Previous!.Next = node.Next;
            node!.Next!.Previous = node.Previous;
            Count--;
            return true;
        }
        return false;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
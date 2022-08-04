namespace DataStructures;

/// <summary>
/// A node in a singly linked list
/// </summary>
/// <typeparam name="T"></typeparam>
public class SinglyLinkedListNode<T>
{
    /// <summary>
    /// The value of the node
    /// </summary>
    public T Value { get; set; }

    /// <summary>
    /// The next node in the linked list (null for the last node)
    /// </summary>  
    public SinglyLinkedListNode<T>? Next { get; set; }

    /// <summary>
    /// Constructs a new node containing the given value
    /// </summary>
    /// <param name="value"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public SinglyLinkedListNode(T value)
    {
        this.Value = value ?? throw new ArgumentNullException(nameof(value));
    }

}

/// <summary>
/// A singly linked list collection
/// </summary>
/// <typeparam name="T"></typeparam>
public class SinglyLinkedList<T> : ICollection<T>
{
    /// <summary>
    /// The first node in the linked list
    /// </summary>
    public SinglyLinkedListNode<T>? Head { get; private set; }

    /// <summary>
    /// The last node in the linked list
    /// </summary>
    public SinglyLinkedListNode<T>? Tail { get; private set; }

    /// <summary>
    /// Adds the given value to the beginning of the linked list
    /// </summary>
    /// <param name="value">The value to add to the list</param>
    public void AddHead(T value)
    {
        AddHead(new SinglyLinkedListNode<T>(value));
    }

    /// <summary>
    /// Adds the given node to the beginning of the linked list
    /// </summary>
    /// <param name="node">The node to add to the list</param>
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

    /// <summary>
    /// Adds the given value to the end of the linked list
    /// </summary>
    /// <param name="value">The value to add to the list</param>
    public void AddTail(T value)
    {
        AddTail(new SinglyLinkedListNode<T>(value));
    }

    /// <summary>
    /// Adds the given node to the end of the linked list
    /// </summary>
    /// <param name="node">The node to add to the list</param>
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

    /// <summary>
    /// Removes the first node the linked list
    /// </summary>
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

    /// <summary>
    /// Removes the last node in the linked list
    /// </summary>
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
            if (currentNode.Next == null)
            {
                previousNode!.Next = null;
                Tail = previousNode;
                Count--;
            }
            previousNode = currentNode;
            currentNode = currentNode.Next;
        }
    }

    /// <summary>
    /// Searches the linked list for a node containing the given value
    /// </summary>
    /// <param name="value">The value to search for</param>
    /// <returns>A linked list node containing the given value, or null if the value is not found</returns>
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

    // ICollection members

    /// <summary>
    /// The number of items currently in the list
    /// </summary>
    public int Count { get; private set; } = 0;
    
    /// <summary>
    /// True if the collection is readonly, false otherwise
    /// </summary>
    public bool IsReadOnly
    {
        get { return false; }
    }

    /// <summary>
    /// Adds the specified value to the beginning of the list
    /// </summary>
    /// <param name="value">The value to add to the list</param>
    public void Add(T value)
    {
        AddTail(value);
    }

    /// <summary>
    /// Clears the linked list
    /// </summary>
    public void Clear()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }

    /// <summary>
    /// Checks if the linked list contains a given value
    /// </summary>
    /// <param name="value">The value to check the list for</param>
    /// <returns>true if the list contains the value, otherwise false</returns>
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

    /// <summary>
    /// Copies the contents of the linked list to an array
    /// </summary>
    /// <param name="array">The array to copy the contents to</param>
    /// <param name="arrayIndex">The index in the array to which copying should begin from</param>
    public void CopyTo(T[] array, int arrayIndex)
    {
        var currentNode = Head;
        while (currentNode != null)
        {
            array[arrayIndex++] = currentNode.Value;
            currentNode = currentNode.Next;
        }
    }

    /// <summary>
    /// Enumerates over the linked list from head to tail
    /// </summary>
    /// <returns>A head to tail enumerator</returns>
    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = Head;
        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Next;
        }
    }

    /// <summary>
    /// Removes the first occurrence of the given value from the list
    /// </summary>
    /// <param name="value">The value to be removed</param>
    /// <returns>true if a value was removed, otherwise false</returns>
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
                return true;
            }
            previousNode = currentNode;
            currentNode = currentNode.Next;
        }

        return false;
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
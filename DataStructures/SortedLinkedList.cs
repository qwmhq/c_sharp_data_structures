using System.Collections;

namespace DataStructures;

/// <summary>
/// A node in a sorted linked list
/// </summary>
/// <typeparam name="T"></typeparam>
public class SortedLinkedListNode<T> where T : IComparable
{
    /// <summary>
    /// The value of the node
    /// </summary>
    public T Value { get; }

    /// <summary>
    /// The previous node in the linked list (null for the first node in the list)
    /// </summary>
    public SortedLinkedListNode<T>? Previous { get; set; }

    /// <summary>
    /// The next node in the linked list (null for the last node in the list)
    /// </summary>
    public SortedLinkedListNode<T>? Next { get; set; }

    /// <summary>
    /// Constructs a node from the given value
    /// </summary>
    /// <param name="value"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public SortedLinkedListNode(T value)
    {
        Value = value ?? throw new ArgumentNullException();;
    }
}

/// <summary>
/// A collection of linked list nodes in sort order
/// </summary>
/// <typeparam name="T"></typeparam>
public class SortedLinkList<T> : ICollection<T> where T : IComparable
{
    /// <summary>
    /// The first node in the list
    /// </summary>
    public SortedLinkedListNode<T>? Head { get; private set; }

    /// <summary>
    /// The last node in the list
    /// </summary>
    public SortedLinkedListNode<T>? Tail { get; private set; }

    public SortedLinkedListNode<T>? Find(T value)
    {
        var currentNode = Head;
        while (currentNode != null)
        {
            if (currentNode.Value.Equals(value))
            {
                return currentNode;
            }
            currentNode = currentNode.Next;
        }
        return null;
    }

    /// <summary>
    /// The number of items in the list
    /// </summary>
    public int Count { get; private set; } = 0;

    /// <summary>
    /// true if the collection is readonly, otherwise false
    /// </summary>
    public bool IsReadOnly
    {
        get { return false; }
    }

    /// <summary>
    /// Adds the specified item to the sorted list
    /// </summary>
    /// <param name="item">The item to add to the list</param>
    public void Add(T item)
    {
        var itemNode = new SortedLinkedListNode<T>(item);

        if (Count == 0)
        {
            Head = Tail = itemNode;
        }
        else if (item.CompareTo(Head!.Value) < 0)
        {
            itemNode.Next = Head;
            Head.Previous = itemNode;
            Head = itemNode;
        }
        else if (item.CompareTo(Tail!.Value) > 0)
        {
            itemNode.Previous = Tail;
            Tail.Next = itemNode;
            Tail = itemNode;
        }
        else
        {
            var currentNode = Head;
            while(currentNode != null)
            {
                if (item.CompareTo(currentNode.Value) > 0)
                {
                    var nextNode = currentNode.Next;
                    var previousNode = currentNode;
                    
                    itemNode.Previous = previousNode;
                    previousNode.Next = itemNode;
                    itemNode.Next = nextNode;
                    nextNode!.Previous = itemNode;

                    break;
                }
            }
        }
        Count++;
    }

    /// <summary>
    /// Removes all items from the list
    /// </summary>
    public void Clear()
    {
        Head = Tail = null;
        Count = 0;
    }

    /// <summary>
    /// Checks if the list contains the specified item
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool Contains(T item)
    {
        foreach (T value in this)
        {
            if (value.Equals(item))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Copies the contents of the sorted list to the specified array
    /// </summary>
    /// <param name="array"></param>
    /// <param name="arrayIndex"></param>
    public void CopyTo(T[] array, int arrayIndex)
    {
        foreach (var item in this)
        {
            array[arrayIndex++] = item;
        }
    }

    /// <summary>
    /// Enumerates the sorted linked list from head to tail
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

    public bool Remove(T item)
    {
        if (Count != 0)
        {
            if (Head!.Value.Equals(item))
            {
                Head = Head.Next;               
                if (Count == 1)
                {
                    Tail = null;
                }
                else
                {
                    Head!.Previous = null;
                }
            }
            else if (Tail!.Value.Equals(item))
            {
                Tail = Tail.Previous;
                Tail!.Next = null;
            }
            else
            {
                var itemNode = Find(item);
                if (itemNode != null)
                {
                    var previousNode = itemNode.Previous;
                    var nextNode = itemNode.Next;
                    previousNode!.Next = nextNode;
                    nextNode!.Previous = previousNode;
                }
            }
            Count--;
            return true;
        }
        return false;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
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
}
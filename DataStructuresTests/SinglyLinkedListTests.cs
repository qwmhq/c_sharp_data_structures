using DataStructures;

namespace DataStructuresTests;

[TestClass]
public class SinglyLinkedListTests
{
    [TestMethod]
    public void InitializeEmptyTest()
    {
        SinglyLinkedList<int> ints = new SinglyLinkedList<int>();
        Assert.AreEqual(0, ints.Count);
    }
    
    [TestMethod]
    public void AddHeadTest()
    {
        var ints = new SinglyLinkedList<int>();
        for (int i = 1; i <= 5; i++)
        {
            ints.AddHead(i);
            Assert.AreEqual(i, ints.Count);
            Assert.AreEqual(i, ints.Head!.Value);
        }
        
        int expected = 5;
        var currentNode = ints.Head;

        while (currentNode != null)
        {
            Assert.AreEqual(expected--, currentNode.Value);
            currentNode = currentNode.Next;
        }
    }

    [TestMethod]
    public void AddTailTest()
    {
        var ints = new SinglyLinkedList<int>();
        for (int i = 1; i <= 5; i++)
        {
            ints.AddTail(i);
            Assert.AreEqual(i, ints.Count);
            Assert.AreEqual(i, ints.Tail!.Value);
            Assert.AreEqual(null, ints.Tail.Next);
        }

        int expected = 1;
        var currentNode = ints.Head;
        while (currentNode != null)
        {
            Assert.AreEqual(expected++, currentNode.Value);
            currentNode = currentNode.Next;
        }
    }

    [TestMethod]
    public void RemoveHeadTest()
    {
        var ints = Create(5, 1);

        for (int i = 5; i >= 1; i--)
        {
            Assert.AreEqual(i, ints.Head!.Value);
            Assert.AreEqual(i, ints.Count);
            ints.RemoveHead();
        }

        Assert.AreEqual(null, ints.Head);
        Assert.AreEqual(0, ints.Count);
    }

    [TestMethod]
    public void RemoveTailTest()
    {
        var ints = Create(1, 5);

        for (int i = 5; i >= 1; i--)
        {
            Assert.AreEqual(i, ints.Tail!.Value);
            Assert.AreEqual(i, ints.Count);
            ints.RemoveTail();
        }

        Assert.AreEqual(null, ints.Tail);
        Assert.AreEqual(0, ints.Count);
    }

    [TestMethod]
    public void FindTest()
    {
        var ints = Create(1, 10);

        for (int i = 1; i <= 10; i++)
        {
            Assert.AreEqual(i, ints.Find(i)!.Value);
        }

        Assert.AreEqual(null, ints.Find(0));
        Assert.AreEqual(null, ints.Find(11));
    }

    [TestMethod]
    public void ContainsTest()
    {
        var ints = Create(1, 10);

        for (int i = 1; i <= 10; i++)
        {
            Assert.AreEqual(true, ints.Contains(i));
        }

        Assert.AreEqual(false, ints.Contains(0));
        Assert.AreEqual(false, ints.Contains(11));
    }

    [TestMethod]
    public void AddTest()
    {
        var ints = new SinglyLinkedList<int>();

        for (int i = 1; i <= 10; i++)
        {
            ints.Add(i);
            Assert.AreEqual(i, ints.Count);
            Assert.IsTrue(ints.Contains(i));
        }
    }

    [TestMethod]
    public void RemoveTest()
    {
        var ints = Create(1, 10);

        for (int i = 10; i >= 1; i--)
        {
            Assert.AreEqual(i, ints.Count);
            Assert.IsTrue(ints.Remove(i));
            Assert.IsFalse(ints.Contains(i));
        }

        Assert.IsFalse(ints.Remove(0));
        Assert.IsFalse(ints.Remove(11));
    }

    private SinglyLinkedList<int> Create(int start, int end)
    {
        var ints = new SinglyLinkedList<int>();
        if (start < end)
        {
            for (int i = start; i <= end; i++)
            {
                ints.AddTail(i);
            }
        } 
        else
        {
            for (int i = start; i >= end; i--)
            {
                ints.AddTail(i);
            }
        }
        return ints;
    }
}
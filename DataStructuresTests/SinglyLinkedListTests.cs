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

        var values = new int[] {2, 5, 7, 8, 1, 4, 9, 6, 10, 3};

        var expectedCount = 10;

        foreach (var value in values)
        {
            Assert.AreEqual(expectedCount--, ints.Count);
            Assert.IsTrue(ints.Remove(value));
            Assert.IsFalse(ints.Contains(value));
        }
    }

    [TestMethod]
    public void ClearTest()
    {
        var ints = Create(1, 10);

        ints.Clear();
    }

    [TestMethod]
    public void CopyToTest()
    {
        var ints = Create(1, 10);

        var intsArray = new int[10];
        ints.CopyTo(intsArray, 0);

        var currentNode = ints.Head;
        int currentIndex = 0;
        
        while (currentNode != null)
        {
            Assert.AreEqual(currentNode.Value, intsArray[currentIndex++]);
            currentNode = currentNode.Next;
        }

        var largerIntsArray = new int[20];
        ints.CopyTo(largerIntsArray, 10);

        currentNode = ints.Head;
        currentIndex = 10;
        
        while (currentNode != null)
        {
            Assert.AreEqual(currentNode.Value, largerIntsArray[currentIndex++]);
            currentNode = currentNode.Next;
        }
    }

    [TestMethod]
    public void IsReadOnlyTest()
    {
        var ints = Create(1, 10);
        Assert.IsFalse(ints.IsReadOnly);
    }

    [TestMethod]
    public void GetEnumeratorTest()
    {
        var ints = Create(1, 10);
        int expected = 1;
        foreach (int i in ints)
        {
            Assert.AreEqual(i, expected++);
        }
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
using DataStructures;

namespace DataStructuresTests;

[TestClass]
public class SortedLinkListTests
{
    [TestMethod]
    public void InitializeEmptyTest()
    {
        var ints = new SortedLinkList<int>();
        Assert.AreEqual(0, ints.Count);
    }

    [TestMethod]
    public void AddTest()
    {
        var ints = new SortedLinkList<int>();
        var intsArray = new int[] { 3, 1, 4, 2, 5 };

        for (int i = 0; i < 5; i++)
        {
            ints.Add(intsArray[i]);
            Assert.AreEqual(i + 1, ints.Count);
        }

        int expected = 1;
        var currentNode = ints.Head;

        while(currentNode != null)
        {
            Assert.AreEqual(expected++, currentNode.Value);
            currentNode = currentNode.Next;
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
    public void ContainsTest()
    {
        var ints = Create(1, 10);

        for (int i = 1; i <= 10; i++)
        {
            Assert.IsTrue(ints.Contains(i));
        }

        Assert.IsFalse(ints.Contains(0));
        Assert.IsFalse(ints.Contains(11));
    }

    [TestMethod]
    public void FindTest()
    {
        var ints = Create(1, 10);

        for (int i = 1; i <= 10; i++)
        {
            Assert.AreEqual(i, ints.Find(i)!.Value);
        }

        Assert.IsNull(ints.Find(0));
        Assert.IsNull(ints.Find(11));
    }

    [TestMethod]
    public void ClearTest()
    {
        var ints = Create(1, 10);

        ints.Clear();

        Assert.AreEqual(0, ints.Count);
        Assert.IsNull(ints.Head);
        Assert.IsNull(ints.Tail);
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

    [TestMethod]
    public void GetReverseEnumeratorTest()
    {
        var ints = Create(1, 10);
        int expected = 10;
        foreach (int i in ints.GetReverseEnumerator())
        {
            Assert.AreEqual(expected--, i);
        }
    }

    private SortedLinkList<int> Create(int start, int end)
    {
        var ints = new SortedLinkList<int>();

        if (start < end)
        {
            for (int i = start; i <= end; i++)
            {
                ints.Add(i);
            }
        } 
        else
        {
            for (int i = start; i >= end; i--)
            {
                ints.Add(i);
            }
        }
        return ints;
    }
}
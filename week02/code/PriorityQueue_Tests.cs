using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Test that Enqueue adds items to the back of the queue
    // Expected Result: Items should be stored in the order they were added, regardless of priority
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 3);

        // Use ToString to verify items are stored in order added (back of queue)
        string queueContents = priorityQueue.ToString();
        Assert.IsTrue(queueContents.Contains("First") && queueContents.Contains("Second") && queueContents.Contains("Third"));
        // The exact order should be: First, Second, Third (as added)
        Assert.AreEqual("[First (Pri:1), Second (Pri:5), Third (Pri:3)]", queueContents);
    }

    [TestMethod]
    // Scenario: Test that Dequeue removes and returns the highest priority item
    // Expected Result: "High" (5), "Medium" (3), "Low" (1) 
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Test tie-breaking - when priorities are equal, return the one closest to front
    // Expected Result: "First" then "Second" (both priority 5, but "First" was added first)
    // Defect(s) Found:
    // 1. In PriorityQueue.Dequeue, the for loop's condition caused it to skip the last item in the queue.
    // 2. In PriorityQueue.Dequeue, the dequeued item was not being removed from the queue.
    // 3. In PriorityQueue.Dequeue, the comparison for determining the highest priority was incorrect, affecting FIFO order.

    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Lower", 2);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Lower", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Test empty queue exception
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: 
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception of type {e.GetType()} caught: {e.Message}");
        }
    }
}
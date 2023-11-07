using MyLibrary;
namespace MyLibraryTest;

public class EventsTest
{
    [Fact]
    public void Enqueue_OnCall_Invoke()
    {
        CustomQueue<int> cq = new CustomQueue<int>();
        bool wasRaised = false;
        int element = 1;
        object senderClass = null;
        
        cq.OnEnqueued += (sender, args) =>
        {
            wasRaised = true;
            senderClass = sender;
        };
        cq.Enqueue(element);
        
        Assert.True(wasRaised);
        Assert.IsType<CustomQueue<int>>(senderClass);
    }
    
    [Fact]
    public void Dequeue_OnCall_Invoke()
    {
        CustomQueue<int> cq = new CustomQueue<int>();
        bool wasRaised = false;
        int element = 1;
        object senderClass = null;
        
        cq.Enqueue(element);
        cq.OnDequeued += (sender, args) =>
        {
            wasRaised = true;
            senderClass = sender;
        };
        cq.Dequeue();
        
        Assert.True(wasRaised);
        Assert.IsType<CustomQueue<int>>(senderClass);
    }
    
    [Fact]
    public void Clear_OnCall_Invoke()
    {
        CustomQueue<int> cq = new CustomQueue<int>(new int[] {2, 41, 1234, -1}) ;
        bool wasRaised = false;
        object senderClass = null;
        
        cq.OnCleared += (sender, args) =>
        {
            wasRaised = true;
            senderClass = sender;
        };
        cq.Clear();
        
        Assert.True(wasRaised);
        Assert.IsType<CustomQueue<int>>(senderClass);
    }
    
    [Fact]
    public void Reverse_OnCall_Invoke()
    {
        CustomQueue<int> cq = new CustomQueue<int>(new int[] {2, 41, 1234, -1}) ;
        bool wasRaised = false;
        object senderClass = null;
        
        cq.OnReversed += (sender, args) =>
        {
            wasRaised = true;
            senderClass = sender;
        };
        cq.Reverse();
        
        Assert.True(wasRaised);
        Assert.IsType<CustomQueue<int>>(senderClass);
    }
    
    [Theory]
    [MemberData(nameof(SuccessfulCopyToEventTestData))]
    public void CopyTo_OnCall_Invoke(CustomQueue<int> startingCollection, int[] array, int index)
    {
        CustomQueue<int> cq = startingCollection ;
        bool wasRaised = false;
        object senderClass = null;
        
        cq.OnCopiedTo += (sender, args) =>
        {
            wasRaised = true;
            senderClass = sender;
        };
        cq.CopyTo(array, index);
        
        Assert.True(wasRaised);
        Assert.IsType<CustomQueue<int>>(senderClass);
    }
    
    [Theory]
    [MemberData(nameof(OutOfRangeCopyToEventTestData))]
    public void CopyTo_OutOfRangeException_DontInvoke(CustomQueue<int> startingCollection, int[] array, int index)
    {
        CustomQueue<int> cq = startingCollection ;
        bool wasRaised = false;
        object senderClass = null;
        
        cq.OnCopiedTo += (sender, args) =>
        {
            wasRaised = true;
            senderClass = sender;
        };
        
        Assert.Throws<ArgumentOutOfRangeException>(()=>cq.CopyTo(array, index));
        Assert.False(wasRaised);
    }
    
    [Theory]
    [MemberData(nameof(NullExceptionCopyToEventTestData))]
    public void CopyTo_NullExceptionException_DontInvoke(CustomQueue<int> startingCollection, int[] array, int index)
    {
        CustomQueue<int> cq = startingCollection ;
        bool wasRaised = false;
        object senderClass = null;
        
        cq.OnCopiedTo += (sender, args) =>
        {
            wasRaised = true;
            senderClass = sender;
        };
        
        Assert.Throws<ArgumentNullException>(()=>cq.CopyTo(array, index));
        Assert.False(wasRaised);
    }
    
    [Theory]
    [MemberData(nameof(ArgumentExceptionCopyToEventTestData))]
    public void CopyTo_ArgumentException_DontInvoke(CustomQueue<int> startingCollection, int[] array, int index)
    {
        CustomQueue<int> cq = startingCollection ;
        bool wasRaised = false;
        object senderClass = null;
        
        cq.OnCopiedTo += (sender, args) =>
        {
            wasRaised = true;
            senderClass = sender;
        };
        
        Assert.Throws<ArgumentException>(()=>cq.CopyTo(array, index));
        Assert.False(wasRaised);
    }
    public static IEnumerable<object[]> SuccessfulCopyToEventTestData()
    {
        yield return new object[] {
            new CustomQueue<int>(new int[] { 232, 441, 55 }),
            new int[] { 2, 4, 5, 5, 6}, 
            2 
        };
        yield return new object[] {
            new CustomQueue<int>(new int[] { 0, 0, 0, 1}),
            new int[] { 24, 451, -5, 85, 6}, 
            0
        };
    }
    
    public static IEnumerable<object[]> OutOfRangeCopyToEventTestData()
    {
        yield return new object[] {
            new CustomQueue<int>(new int[] { 232, 441, 55 }),
            new int[] { 2, 4, 5, 5, 6}, 
            -3 
        };
        
        yield return new object[] {
            new CustomQueue<int>(new int[] { 0, 0, 0, 1}),
            new int[] { 24, 451, -5, 85, 6}, 
            5
        };
    }
    
    public static IEnumerable<object[]> NullExceptionCopyToEventTestData()
    {
        yield return new object[] {
            new CustomQueue<int>(new int[] { 232, 441, 55 }),
            null, 
            1 
        };
    }
    
    public static IEnumerable<object[]> ArgumentExceptionCopyToEventTestData()
    {
        yield return new object[] {
            new CustomQueue<int>(new int[] { 232, 441, 55 }),
            new int[] {31, 34}, 
            1 
        }; 
        
        yield return new object[] {
            new CustomQueue<int>(new int[] { 51123, 234, -3251, 23 }),
            new int[] {11, 33, 5}, 
            0
        }; 
    }
}
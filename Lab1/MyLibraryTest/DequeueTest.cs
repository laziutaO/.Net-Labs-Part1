using MyLibrary;
namespace MyLibraryTest;

public class DequeueTest
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Dequeue_IntElement_SuccessfulDequeue(int expected, int[] enqueueElements)
    {
        CustomQueue<int> cq = new(enqueueElements);

        var actualElement = cq.Dequeue();
        
        Assert.Equal(expected, actualElement);
        Assert.DoesNotContain(expected, cq);
    }
    
    [Fact]
    public void Dequeue_EmptyCollection_InvalidOperationException()
    {
        CustomQueue<int> cq = new();

        Assert.Throws<InvalidOperationException>(() => cq.Dequeue());
    }
    
    public static IEnumerable<object[]> TestData()
    {
        yield return new object[] { 2 , new int[] { 2, 4, 5, 5, 6 } };
        yield return new object[] { 132, new int[] { 132, 441, 5412, -55, 612 } };
        yield return new object[] { -652, new int[] { -652, 524, 551, -7545, 452366 } };
    }
}
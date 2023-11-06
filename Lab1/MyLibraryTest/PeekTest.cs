using MyLibrary;
namespace MyLibraryTest;

public class PeekTest
{
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void Peek_NotEmptyCollection_FirstElement(int expected, int[] queueElements)
    {
        CustomQueue<int> cq = new(queueElements);
        
        var peekedElement = cq.Peek();
        
        Assert.Equal(expected, peekedElement);
    }
    
    [Fact]
    public void Peek_EmptyCollection_InvalidOperationException()
    {
        CustomQueue<int> cq = new();

        Assert.Throws<InvalidOperationException>(() => cq.Peek());
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[] { 2, new int[] { 2, 4, 5, 5, 6 } };
        yield return new object[] { 12, new int[] { 12, -44, 35, 25, 16 } };
        yield return new object[] { 123, new int[] { 123, 451, 1, 0, -41235 } };
    }
}
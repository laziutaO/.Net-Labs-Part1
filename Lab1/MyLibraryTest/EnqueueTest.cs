using MyLibrary;
namespace MyLibraryTest;

public class EnqueueTest
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Enqueue_IntCollection_SuccessfulFilling(CustomQueue<int> expected, int[] enqueueElements)
    {
        CustomQueue<int> cq = new();

        foreach (var element in enqueueElements)
        {
            cq.Enqueue(element);
        }
        
        Assert.Equal(expected, cq);
    }
    
    public static IEnumerable<object[]> TestData()
    {
        yield return new object[] { new CustomQueue<int>(new int[] { 2, 4, 5, 5, 6 }), new int[] { 2, 4, 5, 5, 6 } };
        yield return new object[] { new CustomQueue<int>(new int[] { 132, 441, 5412, 55, 612 }), new int[] { 132, 441, 5412, 55, 612 } };
        yield return new object[] { new CustomQueue<int>(new int[] { 652, 524, 551, 7545, 452366 }), new int[] { 652, 524, 551, 7545, 452366 } };
    }
}
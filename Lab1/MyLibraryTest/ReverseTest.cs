using MyLibrary;
namespace MyLibraryTest;

public class ReverseTest
{
    [Theory]
    [MemberData(nameof(ReverseTestData))]
    public void Reverse_FromIntQueue_SuccessfulReverse(CustomQueue<int> expectedCq, CustomQueue<int> startingCq)
    {
        CustomQueue<int> cq = startingCq;

        var reversedCq = cq.Reverse();
        
        Assert.Equal(expectedCq, reversedCq);
    }

    public static IEnumerable<object[]> ReverseTestData()
    {
        yield return new object[] 
        { 
            new CustomQueue<int>(new int[] { 73, 6, 51, 1234, -1234, 516, 53, 23 }),
            new CustomQueue<int>(new int[] { 23, 53, 516, -1234, 1234, 51, 6, 73 }) 
        };
        yield return new object[] 
        { 
            new CustomQueue<int>(new int[] { 341, -2, -2, 51 }),
            new CustomQueue<int>(new int[] { 51, -2, -2, 341}) 
        };
        yield return new object[]
        {
            new CustomQueue<int>(new int[] { -1 }),
            new CustomQueue<int>(new int[] { -1 })
        };
        yield return new object[]
        {
            new CustomQueue<int>(new int[] { }),
            new CustomQueue<int>(new int[] { })
        };
    }
}
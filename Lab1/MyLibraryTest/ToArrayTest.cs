using MyLibrary;
namespace MyLibraryTest;

public class ToArrayTest
{
    [Theory]
    [MemberData(nameof(ToArrayTestData))]
    public void ToArray_FromIntQueue_SuccessfulConversion(int[] expectedArray)
    {
        CustomQueue<int> cq = new CustomQueue<int>(expectedArray);

        var arr = cq.ToArray();
        
        Assert.Equal(expectedArray, arr);
    }

    public static IEnumerable<object[]> ToArrayTestData()
    {
        yield return new object[] { new int[] { 23, 53, 516, -1234, 1234, 51, 6, 73 } };
        yield return new object[] { new int[] { 43, 72, 34, 43 } };
        yield return new object[] { new int[] { -1 } };
        yield return new object[] { new int[] { } };
    }
}
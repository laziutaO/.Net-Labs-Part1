using MyLibrary;
namespace MyLibraryTest;

public class ContainsTest
{
    [Theory]
    [MemberData(nameof(ContainsNumberTestData))]
    public void Contains_CheckOnContainingNumber_NumberIsInCollection(int number, CustomQueue<int> startingCollection)
    {
        CustomQueue<int> cq = startingCollection;
        var contains = cq.Contains(number);
        
        Assert.True(contains);
    }
    
    [Theory]
    [MemberData(nameof(NotContainNumberTestData))]
    public void Contains_CheckOnContainingNumber_NumberIsNotInCollection(int number, CustomQueue<int> startingCollection)
    {
        CustomQueue<int> cq = startingCollection;
        var contains = cq.Contains(number);
        
        Assert.False(contains);
    }

    public static IEnumerable<object[]> ContainsNumberTestData()
    {
        yield return new object[] { -234, new CustomQueue<int>(new int[] { 213, 43, -234, -234, -2 }) };
        yield return new object[] { 11, new CustomQueue<int>(new int[] { 34, 5, -2, -87, 90, 11 }) };
        yield return new object[] { 0, new CustomQueue<int>(new int[] { 0, 0, -2, -3 }) };
    }
    
    public static IEnumerable<object[]> NotContainNumberTestData()
    {
        yield return new object[] { 5156, new CustomQueue<int>(new int[] { 213, 43, -234, -234, -2 }) };
        yield return new object[] { 12, new CustomQueue<int>(new int[] { 34, 5, -2, -87, 90, 11 }) };
        yield return new object[] { 5, new CustomQueue<int>(new int[] { 0, 0, -2, -3 }) };
    }
}
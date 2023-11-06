using MyLibrary;
namespace MyLibraryTest;

public class ClearTest
{
    [Theory]
    [MemberData(nameof(FilledCollectionTestData))]
    public void Clear_ClearCollection_EmptyCollection(CustomQueue<int> startingCollection)
    {
        CustomQueue<int> cq = startingCollection;
        cq.Clear();
        
        Assert.Empty(cq);
    }

    public static IEnumerable<object[]> FilledCollectionTestData()
    {
        yield return new object[] { new CustomQueue<int>(new int[] { 213, 43, -234, -234, -2 }) };
        yield return new object[] { new CustomQueue<int>() };
    }
}
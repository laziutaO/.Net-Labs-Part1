using MyLibrary;
namespace MyLibraryTest;

public class EnumeratorTest
{
    [Fact]
    public void Enumerator_MoveNextInEmptyCollection_ReturnsFalse()
    {
        CustomQueue<int> cq = new CustomQueue<int>();
        var enumerator = cq.GetEnumerator();
        
        Assert.False(enumerator.MoveNext());
    }

    [Theory]
    [InlineData(new int[] {23, 123, 512})]
    public void Enumerator_MoveNextInFilledCollection_ReturnsTrue(int[] arr)
    {
        CustomQueue<int> cq = new CustomQueue<int>(arr);
        var enumerator = cq.GetEnumerator();
        
        Assert.True(enumerator.MoveNext()); 
        Assert.True(enumerator.MoveNext()); 
        Assert.True(enumerator.MoveNext()); 
        Assert.False(enumerator.MoveNext()); 
    }

    [Theory]
    [InlineData(new int[] {23, 123, 512})]
    public void Enumerator_Reset_ResetsEnumeration(int[] arr)
    {
        CustomQueue<int> cq = new CustomQueue<int>(arr);
        var enumerator = cq.GetEnumerator();

        enumerator.MoveNext(); 
        enumerator.MoveNext();
        enumerator.Reset();
        
        Assert.True(enumerator.MoveNext()); 
    }

    [Theory]
    [InlineData(123, new int[] {23, 123, 512})]
    public void Enumerator_Current_ReturnsCorrectItem(int expected, int[] arr)
    {
        CustomQueue<int> cq = new CustomQueue<int>(arr);
        var enumerator = cq.GetEnumerator();
        
        enumerator.MoveNext();
        enumerator.MoveNext();
        
        Assert.Equal(expected, enumerator.Current);
    }
    
}
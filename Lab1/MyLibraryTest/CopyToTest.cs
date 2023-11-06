using MyLibrary;
namespace MyLibraryTest;

public class CopyToTest
{
    [Theory]
    [MemberData(nameof(SuccessfulTestData))]
    public void CopyTo_FromIntQueue_SuccessfulCopy(int[] expectedArray, CustomQueue<int> startingCollection, int[] array, int index)
    {
        CustomQueue<int> cq = startingCollection;

        cq.CopyTo(array, index);
        
        Assert.Equal(expectedArray, array);
    }
    
    [Theory]
    [MemberData(nameof(OutOfRangeIndexTestData))]
    public void CopyTo_FromIntQueue_IndexOutOfRange(CustomQueue<int> startingCollection, int[] array, int index)
    {
        CustomQueue<int> cq = startingCollection;
        
        Assert.Throws<ArgumentOutOfRangeException>(()=>cq.CopyTo(array, index));
    }
    
    [Theory]
    [MemberData(nameof(ArgumentNullExceptionTestData))]
    public void CopyTo_ToNullArray_NullException(CustomQueue<int> startingCollection, int[] array, int index)
    {
        CustomQueue<int> cq = startingCollection;
        
        Assert.Throws<ArgumentNullException>(()=>cq.CopyTo(array, index));
    }
    
    [Theory]
    [MemberData(nameof(ArgumentExceptionTestData))]
    public void CopyTo_ToSmallArray_ArgumentException(CustomQueue<int> startingCollection, int[] array, int index)
    {
        CustomQueue<int> cq = startingCollection;
        
        Assert.Throws<ArgumentException>(()=>cq.CopyTo(array, index));
    }
    public static IEnumerable<object[]> SuccessfulTestData()
    {
        yield return new object[] {
            new int[] { 2, 4, 232, 441, 55 },
            new CustomQueue<int>(new int[] { 232, 441, 55 }),
            new int[] { 2, 4, 5, 5, 6}, 
            2 
        };
        
        yield return new object[] {
            new int[] { 0, 0, 0, 1, 6 },
            new CustomQueue<int>(new int[] { 0, 0, 0, 1}),
            new int[] { 24, 451, -5, 85, 6}, 
            0
        };
        
        yield return new object[] {
            new int[] { 24, -3, 124, 34, 2135, 87, 90 },
            new CustomQueue<int>(new int[] { -3, 124, 34, 2135}),
            new int[] { 24, 451, -5, 85, 6, 87, 90}, 
            1
        };
    }
    
    public static IEnumerable<object[]> OutOfRangeIndexTestData()
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
    
    public static IEnumerable<object[]> ArgumentNullExceptionTestData()
    {
        yield return new object[] {
            new CustomQueue<int>(new int[] { 232, 441, 55 }),
            null, 
            1 
        };
    }

    public static IEnumerable<object[]> ArgumentExceptionTestData()
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
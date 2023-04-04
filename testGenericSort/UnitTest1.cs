namespace testGenericSort;

public class UnitTest1
{
    [Fact]
    public void test_sortIntegers()
    {
        var unsortedIntegers = new List<int> { 5, 4, 3, 2, 1 };
        var expectedResults = new List<int> { 1, 2, 3, 4, 5 };

        var sortedNumbers = genericSort.Program.Sort(unsortedIntegers);

        Assert.Equal(expectedResults, sortedNumbers);
    }

    public void test_sortStrings()
    {
        var unsortedStrings = new List<string> { "e", "d", "c", "b", "a" };
        var expectedResults = new List<string> { "a", "b", "c", "d", "e" };

        var sortedStrings = genericSort.Program.Sort(unsortedStrings);

        Assert.Equal(expectedResults, sortedStrings);
    }
}
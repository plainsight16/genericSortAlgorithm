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
    [Fact]
    public void test_sortStrings()
    {
        var unsortedStrings = new List<string> { "e", "d", "c", "b", "a" };
        var expectedResults = new List<string> { "a", "b", "c", "d", "e" };

        var sortedStrings = genericSort.Program.Sort(unsortedStrings);

        Assert.Equal(expectedResults, sortedStrings);
    }
    [Fact]
    public void test_sortDoubles()
    {
        var unsortedDoubles = new List<double> { 5.5, 4.4, 3.3, 2.2, 1.1 };
        var expectedResults = new List<double> { 1.1, 2.2, 3.3, 4.4, 5.5 };

        var sortedDoubles = genericSort.Program.Sort(unsortedDoubles);

        Assert.Equal(expectedResults, sortedDoubles);
    }
    [Fact]
    public void test_sortBooleans()
    {
        var unsortedBooleans = new List<bool> { true, false, true, false, true };
        var expectedResults = new List<bool> { false, false, true, true, true };

        var sortedBooleans = genericSort.Program.Sort(unsortedBooleans);

        Assert.Equal(expectedResults, sortedBooleans);
    }

    [Fact]
    public void test_emptyList()
    {    
        var unsortedList = new List<int>(){};
        var expectedResults = "List is empty";

        var actualResults = Assert.Throws<ArgumentException>(() => genericSort.Program.Sort(unsortedList));
        Assert.Equal(expectedResults, actualResults.Message);
    }
}
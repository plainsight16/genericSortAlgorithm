
namespace Exampractice;

public class Program
{
    static void main(String[] args)
    {
        PerformOperation(10, x => x * x);
        PerformOperation(2, x => x % 2 == 0 ? "even" : "odd");

        Department[] departments = new Department[3];

        departments[0] = new Department("Science", "Computer Science");
        departments[1] = new Department("Science", "Mathematics");
        departments[2] = new Department("Engineering", "Computer Engineering");
    }

    // Question 3
    static void PerformOperation(int number, Func<int, object> operation)
    {
        var result = operation(number);
        Console.WriteLine($"Result is {result}");
    }

    // Question 4
    static void hasMoreThan2Programmes(Department[] departments)
    {
        var result = departments.Where(department => department.getNoProg() > 2);
        Console.WriteLine($"Result is {result}");
    }
}

// Question 4
class Department
{
    private string name;

    private string code;
    private int noProg;

    public Department(string a, int b)
    {
        this.name = a;
        this.code = b;
    }
    public int getNoProg()
    {
        return noProg;
    }
    public void setNoProg(int noProg)
    {
        this.noProg = noProg;
    }
}
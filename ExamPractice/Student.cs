namespace Exampractice;

// Question 2
public class Student
{
    public string name;
    public int age;
    public abstract void Study(); 
    
}

public class Undergraduate : Student
{
    public Undergraduate(): base(name, age)
    {
        this.name = name;
        this.age = age;
    }

    public override void Study()
    {
        Console.WriteLine("Undergraduate is studying");
    }
}
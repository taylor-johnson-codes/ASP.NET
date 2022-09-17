global using System;  // with "global", you don't have to put "using System" anywhere else in project
using Users;  // to access classes from another file
using TestInheritance;  // to access classes from another file
using Taylor;  // namespace example at bottom

// can use "namespace CSC595;" instead of using "namespace CSC595{}"
namespace CSC595
{
    static class Program
    {
        public static void Main()
        {
            //Console.BackgroundColor = ConsoleColor.Green;
            //Console.ForegroundColor = ConsoleColor.Blue;

            // data types
            int x = 10;
            var y = 20;
            string myStr = "Welcome to SMU!";
            Console.WriteLine(myStr);
            Console.WriteLine();

            int salary = 123456;
            Console.WriteLine($"Currency shortcut example with \"c\": {salary:c}");  // displays as currency with dollar sign, comma, and cents
            salary = 123_456_789;  // underscores are for developer readability; doesn't effect numbers
            Console.WriteLine($"Currency shortcut example with \"F2\": {salary:F2}");  // displays as floating point with 2 decimal places
            Console.WriteLine();

            Student student1 = new Student();
            student1.StudentName = "Joey";
            //student1.Major = "CS";
            student1.Major = MajorOptions.COMP_SCIENCE;
            student1.GPA = 3.48;  // set property
            Console.WriteLine($"{student1.StudentName}'s GPA: {student1.GPA}"); // get property
            student1.DisplayInfo();
            student1.DisplayInfo("SMU - ");  // method overloading example
            Console.WriteLine();

            // Student inheriting from User
            Student student2 = new Student();
            student2.DisplayInfo();
            student2.UserName = "admin";
            student2.Password = "pass123";
            Console.WriteLine();

            //TestInheritance examples
            BaseClass bc = new BaseClass();  // BaseClass constructor is called
            DerivedClass dc = new DerivedClass();  // BaseClass AND DerivedClass constructors are called due to inheritance
            Console.WriteLine();

            /*
            // Exception example:
            SomeMethod(4, 5);
            SomeMethod(0, 5);
            //SomeMethod(5, 0);  // infinity sign represents where program crashes if using older .NET version
            SomeMethod(5, 0);  // fixed problem by adding if-else with exception

            // to catch an exception here:
            try
            {
                SomeMethod(4, 5);
                SomeMethod(0, 5);
                SomeMethod(5, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("You can divide by zero!");
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine();
            */

            // interface example
            A a = new A();
            B b = new B();
            C c = new C();
            FancyMethod(a);
            FancyMethod(b);
            FancyMethod(c);
            Console.WriteLine();

            Console.WriteLine(a);  // will display "CSC595.A" without the override method in the class
            Console.WriteLine(b);  // will display "CSC595.B" without the override method in the class
            Console.WriteLine(c);  // will display "CSC595.C" without the override method in the class
            Console.WriteLine();

            // Display contents of roster
            List<int> roster = new List<int>();
            roster.Add(10);
            roster.Add(20);
            roster.Add(15);
            roster.Add(17);
            roster.Add(9);
            roster.Add(100);
            roster.Add(50);

            roster.Sort();

            foreach(int num in roster)
                Console.Write($"{num}  ");
            
            Console.WriteLine();
            Console.WriteLine();

            // Display contents of roster2
            List<Student> roster2 = new List<Student>();
            roster2.Add(new Student() { Major=MajorOptions.MATH, StudentName="Alice", GPA=4.0});
            roster2.Add(new Student() { Major=MajorOptions.COMP_SCIENCE, StudentName= "Ashley", GPA=3.1});
            roster2.Add(new Student() { Major=MajorOptions.INFO_TECH, StudentName="Alex", GPA=2.0});
            roster2.Add(new Student() { Major=MajorOptions.MATH, StudentName="Alice Jr", GPA=3.0});

            roster2.Sort();  // can't sort by default, will crash; need to implement IComparable interface on the class to sort

            foreach (Student student in roster2)
                Console.WriteLine(student);  // prints "Users.Student" for each entry without override method in the class

            // from namespace examples at the bottom:
            // with using statement at top
            //CSC myObject = new CSC();
            // without using statement at top
            //Taylor.CSC obj = new Taylor.CSC();
            //Johnson.CSC obj = new Johnson.CSC();
        }

        /*
        // Exception example
        // if class is static, methods need to be static
        public static double SomeMethod(double a, double b)
        {
            if (b != 0)
            {
                Console.WriteLine($"{a}/{b} = {a / b}");
                return a / b;  // method needs a double returned
            }
            else
            {
                //throw new Exception("You can't divide by zero!");  // Exception() is the most general; there are more specific exceptions...
                throw new DivideByZeroException("You can't divide by zero!");
                // if throwing an exception, don't need to return anything
            }
        }
        */

        // FancyMethod() goes with the interface class and class A, B, C below
        //public static void FancyMethod(A a)  // only works with class A; we want it to work with A, B, or C
        //public static void FancyMethod(object a)  // works, but not the best solution because Student and User could also be called with this method
        public static void FancyMethod(IPrintable myObject)  // creating an interface is the best solution
        {
            myObject.Print();
            myObject.PrettyPrint();
        }
    }

    // Interface example, uses FancyMethod() in Program class:
    public interface IPrintable  // start variable name with I for interface names
    {
        // METHODS (expectations; don't say how they're implemented here)
        void Print();
        void PrettyPrint();
    }
    public class A : IPrintable  // use ": IPrintable" to implement the interface, and define it in the class
    {
        int a = 10;

        public void Print()
        {
            Console.WriteLine(a);
        }
        
        public void PrettyPrint()
        {
            Console.WriteLine($"a = {a}");
        }

        public override string ToString()
        {
            return $"a = {a}";
        }
    }

    public class B : IPrintable 
    {
        int b1 = 20;
        string b2 = "Life is great!";
        
        public void Print()
        {
            Console.WriteLine(b1);
            Console.WriteLine(b2);
        }
        
        public void PrettyPrint()
        {
            Console.WriteLine($"b1 = {b1}, and b2 = {b2}");
        }

        public override string ToString()
        {
            return $"b1 = {b1}, and b2 = {b2}";
        }
    }

    public class C : IPrintable
    {
        int c = 100;

        public void Print()
        {
            Console.WriteLine(c);
        }

        public void PrettyPrint()
        {
            Console.WriteLine($"c = {c}");
        }

        public override string ToString()
        {
            return $"c = {c}";
        }
    }
}

// other namespace examples
// a namespace is just a container of code
// you can have as many namespaces as you wish
namespace Taylor
{
    class CSC  // without "using Taylor;" at the top, this class can be accessed with "Taylor.CSC"
    {
        
    }
}

namespace Johnson
{
    class CSC  // classes can have the same name if they're in different namespaces
    {

    }
}

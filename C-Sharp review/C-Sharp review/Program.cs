// See https://aka.ms/new-console-template for more information

global using System;  // with "global", don't have to put "using System" anywhere else
using Taylor;

// can use "namespace CSC595;" instead of using {}

namespace CSC595
{
    // Interface example, uses FancyMethod() in Program class:
    public interface IPrintable  // lead with I for interface names
    {
        // methods (don't say how they're implemented here)
        void Print();
        void PrettyPrint();
    }
    public class A : IPrintable
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
    }
    public class B : IPrintable  // WATCH at 7:48 to finish
    {
        public void Print();
        public void PrettyPrint();
    }
    public class C : IPrintable
    {
        public void Print();
        public void PrettyPrint();
    }

    static class Program
    {
        public static void Main()
        {
            //Console.BackgroundColor = ConsoleColor.Green;
            //Console.ForegroundColor = ConsoleColor.Blue;

            // data types
            int x = 10;
            string myStr = "Welcome to SMU!";
            Console.WriteLine(myStr);

            int salary = 123456;
            Console.WriteLine($"Currency shortcut example: {salary:c}");

            Student student1 = new Student();
            student1.StudentName = "Joey";
            //student1.Major = "CS";
            student1.Major = Major.COMP_SCIENCE;
            student1.GPA = 3.48;  // set property
            student1.DisplayInfo();

            Console.WriteLine($"Joey's GPA: {student1.GPA}"); // get property

            Student student2 = new Student();
            student2.DisplayInfo();

            CSC myObject = new CSC();  // from Taylor namespace at bottom

            SomeMethod(4, 5);
            SomeMethod(0, 5);
            //SomeMethod(5, 0);  
            // infinity sign represents where program crashes if using older .NET version
            // fixed by adding if-else with exception

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

            List<Student> roster2 = new List<Student>();
            roster2.Add(new Student() { Major=Major.MATH, StudentName="Alice", GPA=4.0});
            roster2.Add(new Student() { Major=Major.COMP_SCIENCE, StudentName="Alex", GPA=3.1});
            roster2.Add(new Student() { Major=Major.INFO_TECH, StudentName="Ashley", GPA=2.0});
            roster2.Add(new Student() { Major=Major.MATH, StudentName="Alice Jr", GPA=3.0});

            roster2.Sort();

            foreach(Student student in roster)
                Console.WriteLine(student);   // 8:04 watch how he printed it nicely



            Console.ReadLine();
        }

        // method example (and with overloading) SEE SLIDE 6
        // if class is static, methods need to be static
        public static double SomeMethod(double a, double b)
        {
            if (b != 0)
                return a / b;
            else
            {
                Console.WriteLine("There is an error.");
                throw new Exception("You can't divide by zero!");
            }
        }

        public static void FancyMethod(IPrintable a)  
        {

        }
    }

    //PUT ENUM USER AND STUDENT IN CLASS FILE, FOLLOW VIDEO
    // to set specific values that can be used
    enum Major { COMP_SCIENCE, MATH, INFO_TECH}

    class User  // base class, more general
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public void UserLogin()
        {

        }
    }

    class Student : User, IComparable // derived class, more specific/specialized 
    // all properties of User and Student available 
    // IComparable to sort alphabetically  FINISH WATCHED 8:06
    {
        // data (fields, properties)
        public string StudentName { get; set; }  // { private get; private set; }
        //public string Major { get; set; }
        public Major Major { get; set; }  // from enum above
        public double GPA { get; set; }

        // other access modifier:
        // private so it's not accessible in Main()
        // private is default

        // actions, behavior (methods)
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {StudentName}, Major: {Major}, GPA: {GPA}");
        }

        // constructor(s) - ctor shortcut

    }
}

namespace Taylor
{
    class CSC
    {

    }
}

namespace Johnson
{
    class CSC  // classes can have the same name if they're in different namespaces
    {

    }
}

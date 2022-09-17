namespace Users
{
    // use enum to set specific values that can be used
    enum MajorOptions { COMP_SCIENCE, INFO_TECH, MATH }
    // if you need results sorted alphabetically by MajorOoptions, put them in alphabetical order here
    // will be compared by index position

    class User  // base class, more general
    {
        // DATA
        public string UserName { get; set; }
        public string Password { get; set; }

        // METHODS
        public void UserLogin() { }
    }

    class Student : User, IComparable  // need to implement IComparable to be able to sort the users alphabetically
    // Student is derived from User; a more specific/specialized class
    // all properties for User are available for Student
    {
        // DATA (fields, properties) - prop+tab+tab shortcut
        // use "private" instead of "public" if you don't want it to be accessible in Main() - private is default
        public string StudentName { get; set; }  // { private get; private set; }
        //public string Major { get; set; }  // replaced with enum from above
        public MajorOptions Major { get; set; }  // from enum above
        public double GPA { get; set; }

        // METHODS (actions, behavior)
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {StudentName}, Major: {Major}, GPA: {GPA}");
        }

        public void DisplayInfo(string preamble)  // method overloading example
        {
            Console.WriteLine($"{preamble} Name: {StudentName}, Major: {Major}, GPA: {GPA}");
        }

        public override string ToString()
        {
            return $"Name: {StudentName}, Major: {Major}, GPA: {GPA}";
        }

        public int CompareTo(object? obj)  
        // skeleton added automatically after implementing IComparable to the class and clicking "implement interface" associated with the red error message
        {
            Student st1 = this;  // this is the current instance of st1
            Student st2 = obj as Student;

            return st1.StudentName.CompareTo(st2.StudentName);
            // -1 if st1 is largest
            // 0 if st1 and st2 are equal
            // 1 if st2 is the largest
        }

        // CONSTRUCTOR(S) - ctor+tab+tab shortcut

    }
}

namespace TestInheritance
{
    class BaseClass
    {
        public int MyBasePublicProperty { get; set; }
        private int MyBasePrivateProperty { get; set; }
        protected int MyBaseProtectedProperty { get; set; }

        public BaseClass()
        {
            Console.WriteLine("Base class constructor called.");
        }
    }

    class DerivedClass : BaseClass
    {
        public int MyDerivedPublicProperty { get; set; }
        private int MyDerivedPrivateProperty { get; set; }  // private to the class it's in
        protected int MyDerivedProtectedProperty { get; set; }  

        public void TestMethod()
        {
            MyDerivedPublicProperty = 10;
            MyDerivedPrivateProperty = 20;
            MyDerivedProtectedProperty = 30;

            MyBasePublicProperty = 40;
            //MyBasePrivateProperty = 50;  // can't access private from other classes even if inheriting 
            MyBaseProtectedProperty = 60;  // can access protected if inherited
        }

        public DerivedClass()  // calls the BaseClass constructor first due to inheritance
        {
            Console.WriteLine("Derived class constructor called.");
        }
    }

    class SomeRandomClass
    {
        public void TestMethod()
        {
            BaseClass obj = new BaseClass();
            obj.MyBasePublicProperty = 40;
            //obj.MyBasePrivateProperty = 50;  // not accessible
            //obj.MyBaseProtectedProperty = 60;  // not accessible
        }
    }
}

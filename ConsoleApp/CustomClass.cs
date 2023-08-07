using System;

namespace ConsoleApp1
{
    [MyAttribute("hk")]
    public class CustomClass
    {
        public void Method()
        {
            Console.WriteLine("this CustomClass goes to...");
        }
    }
    [AttributeUsage(AttributeTargets.Class)]
    public class MyAttributeAttribute : System.Attribute
    {
        public string Description;

        public MyAttributeAttribute(string desc)
        {
            Description = desc;
        }
    }

}

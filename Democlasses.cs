using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionSample
{

    /// <summary>
    /// Interface has one methode
    /// </summary>
    public interface ITalk
    {
        void Talk(string sentence);
    }


    /// <summary>
    /// Attribute
    /// </summary>
    public class EmployeeMarkerAttribute : Attribute
    {
    }

    [EmployeeMarkerAttribute]
    public class Employee : Person
    {
        public string Company { get; set; }
    }

    /// <summary>
    /// Alien class 
    /// </summary>
    public class Alien : ITalk
    {
        public void Talk(string sentence)
        {
            // talk...
            Console.WriteLine($"Alien talking...: {sentence}");
        }
    }


    /// <summary>
    /// Class personn implements ITalk
    /// </summary>
    public class Person : ITalk
    {
        // public fields
        public string Name { get; set; }
        public int age;
        // Private field
        private string _aPrivateField = "initial private field value";

        // 2 constructor public et one private 
        public Person()
        {
            Console.WriteLine("A person is being created.");
        }

        public Person(string name)
        {
            Console.WriteLine($"A person with name {name} is being created.");
            Name = name;
        }

        private Person(string name, int age)
        {
            Console.WriteLine($"A person with name {name} and age {age} " +
                $"is being created using a private constructor.");
            Name = name;
            this.age = age;
        }

        // Public methode
        public void Talk(string sentence)
        {
            // talk...
            Console.WriteLine($"Talking...: {sentence}");
        }

        //protected methode
        protected void Yell(string sentence)
        {
            // yell...
            Console.WriteLine($"YELLING! {sentence}");
        }
        
        public override string ToString()
        {
            return $"{Name} {age} {_aPrivateField}";
        }
    }
}

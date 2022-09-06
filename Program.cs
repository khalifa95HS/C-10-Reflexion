using ReflectionSample;
using System.Reflection;

Console.Title = "Learning Reflexion";
#region sample example string
//var name = "aspnet";
//var nameType = name.GetType();
//Console.WriteLine(nameType);
//Console.ReadLine();
#endregion

#region  Local Assembly
 // Get the assembly
 var currentAssembly = Assembly.GetExecutingAssembly();

// Get all types defined in this assembly
 var typesFromCurrentAssembly = currentAssembly.GetTypes();

// List all the assembly names
foreach (var type in typesFromCurrentAssembly)
{
    Console.WriteLine(type.Name); 
}

// If we want to get ^specific type 
var personAssembly = currentAssembly.GetType("ReflectionSample.Person");
#endregion

#region External Assembly
// Load external assembly
var externalAssembly = Assembly.Load("System.Text.Json");

// get all types or specific type
var typeExternalAssembly = externalAssembly.GetTypes();
var oneTypeExternalAssembly =externalAssembly.GetType("System.Text.Json.JsonProperty");

// get modules  or specific 
var modulesFromExternalAssembly = externalAssembly.GetModules();
var onemodulesFromExternalAssembly = externalAssembly.GetModule("System.Text.Json.dll");
#endregion

#region  Working with Person constructors , Meyhodes , Fields , Properties

// Get Constructors
foreach(var cons in personAssembly.GetConstructors())
{
    Console.WriteLine(cons);
    // we can get information used in constructor or declare type 
    // cons.getParameters() ...
}

// Get methodes 
foreach (var meth in personAssembly.GetMethods())
{
    Console.WriteLine(meth);
}

// get fields 
foreach (var f in personAssembly.GetFields())
{
    Console.WriteLine(f);
}
// get properties
foreach (var p in personAssembly.GetProperties())
{
    Console.WriteLine(p);
}
#endregion

#region  Binding and BindingFlags

// Get methodes public or not public
foreach (var meth in personAssembly.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
{
    Console.WriteLine($"methode :{meth}, public : {meth.IsPublic}");
}

// Get fields public or not public
foreach (var f in personAssembly.GetFields(BindingFlags.Public | BindingFlags.NonPublic))
{
    Console.WriteLine($"field: {f}, public : {f.IsPublic}");
}
#endregion

#region  Instantianting and Manipulating Objects

#region Invoking Constructor (call constructor)
var personType = typeof(Person);
var personConstructors = personType.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
foreach(var cto in personConstructors)
{
    Console.WriteLine(cto);
}

// get constructor
var privateCtoWithTwoParam = personType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic,
    null,
    new Type[]
    { typeof(string) , typeof(int) },
    null);

// Invoke 
var person01 = personConstructors[0].Invoke(null);
var person02 = personConstructors[1].Invoke(new object[] {"Reflexion"});
var person03 = personConstructors[2].Invoke(new object[] { "Reflexion",02 });
var person04 = privateCtoWithTwoParam.Invoke(new object[] { "Reflexion", 02 });
#endregion

#region Create instance of class by knowing the name of class
var person = Activator.CreateInstance(typeof(Person));

var pers = Type.GetType("ReflectionSample.Person");
// constructor 1 param
var person1 = Activator.CreateInstance(pers,new object[] {"Activator"});
// constructor 2 param private 
// var prvPers = Activator.CreateInstance("ReflectionSample", "Person",true,BindingFlags.Instance|BindingFlags.NonPublic,null, new object[] {"private constr",30 },null,null);

// with assembly
var assemblyper=Assembly.GetExecutingAssembly();
var personAssembly0 = assemblyper.CreateInstance("ReflectionSample.Person");
#endregion

#region set name and Create name setValue et getValue

var nameProperty = person1.GetType().GetProperty("Name");
nameProperty.SetValue(person1, "seven");
Console.WriteLine(person1);

var _ageField = person1.GetType().GetField("age");
_ageField.SetValue(person1, 30);
Console.WriteLine(person1);
#endregion

#region Invoking Methode

var talkMethod = person1.GetType().GetMethod("Talk");
talkMethod.Invoke(person1, new[] {"say something hahaha ..." });

#endregion
#endregion


Console.ReadLine();
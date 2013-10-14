using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;
namespace Json
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.name = "John";
            p.age = 42;

            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Person));
            ser.WriteObject(stream1, p);


            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            Console.Write("JSON form of Person object: ");
            Console.WriteLine(sr.ReadToEnd());

            stream1.Position = 0;
            Person p2 = (Person)ser.ReadObject(stream1);

            Console.Write("Deserialized back, got name=");
            Console.Write(p2.name);
            Console.Write(", age=");
            Console.WriteLine(p2.age);


        }
    }
}

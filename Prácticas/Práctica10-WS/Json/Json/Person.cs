using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Json
{
    [DataContract]
    public class Person
    {
        [DataMember]
        internal string name;

        [DataMember]
        internal int age;
    }
}

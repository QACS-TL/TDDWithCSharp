using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimpleApplicationWithTest
{
    public class Person
    {
        private String _givenName, _familyName;
        private int _age;
        // Constructor to initialise the members

        public  Person( int age, string gName, string fName )
        {
            _age = age;
            _givenName = gName;
            _familyName = fName;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Person)) return false;

            return this == (Person)obj;
        }

        public static bool operator ==(Person p1, Person p2)
        {
            return Comparison(p1, p2) == 0;
        }

        public static bool operator !=(Person p1, Person p2)
        {
            return Comparison(p1, p2) != 0;
       }

        private static int Comparison(Person p1, Person p2)
        {
            int result = -1;

            if (p1._age == p2._age && (string.Compare(p1._familyName, p2._familyName, true) == 0)
                && (string.Compare(p1._givenName, p2._givenName, true) == 0))
            {
                result = 0;
            }
            else if (p1._age < p2._age || (string.Compare(p1._familyName, p2._familyName) < 0)
                || (string.Compare(p1._givenName, p2._givenName) < 0))
                result = -1;
            else if (p1._age > p2._age || (string.Compare(p1._familyName, p2._familyName) > 0)
                || (string.Compare(p1._givenName, p2._givenName) > 0))
                result = 1;

            return result;
        }
    }
}

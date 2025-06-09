using System;

namespace PersonUtils
{
    public class Person
    {
        private String _givenName, _familyName;
        private int _age;
        // Constructor to initialise the members

        public Person(int age, string gName, string fName)
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

        private static  int    ValidObjectReferences(Person p1, Person p2 )
        {
            int result = 0;

            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(p1, p2))
            {
                result = 1;
            }

            // If one is null, but not both, return false.
            if ((p1 is null) || (p2 is null))
            {
                result = -1;
            }
            return result;
        }

        public static bool operator ==(Person p1, Person p2)
        {
            int objRefResult = ValidObjectReferences(p1, p2);

            if (objRefResult == 1)
                return true;
            else if (objRefResult == 0)
                // Return true if the fields match:
                return Comparison(p1, p2) == 0;
            else
                return false;
        }

        public static bool operator !=(Person p1, Person p2)
        {
            int objRefResult = ValidObjectReferences(p1, p2);

            if (objRefResult == 1)
                return true;
            else if (objRefResult == 0)
                // Return true if the fields match:
                return Comparison(p1, p2) != 0;
            else
                return false;
        }

        public static bool operator > (Person p1, Person p2)
        {
            int objRefResult = ValidObjectReferences(p1, p2);

            if (objRefResult == 1)
                return true;
            else if (objRefResult == 0)
                // Return true if the fields match:
                return Comparison(p1, p2) > 0;
            else
                return false;
        }

        public static bool operator < (Person p1, Person p2)
        {
            int objRefResult = ValidObjectReferences(p1, p2);

            if (objRefResult == 1)
                return true;
            else if (objRefResult == 0)
                // Return true if the fields match:
                return Comparison(p1, p2) < 0;
            else
                return false;
        }

        private static int Comparison(Person p1, Person p2)
        {
            int result = -1;

            if (p1._age == p2._age && (p1._familyName == p2._familyName)
                && (p1._givenName == p2._givenName))
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

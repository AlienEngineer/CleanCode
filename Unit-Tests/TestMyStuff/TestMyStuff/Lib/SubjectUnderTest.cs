using System;

namespace TestMyStuff.Lib
{
    
    public class SubjectUnderTest
    {
        public ComplexObject SomeCalculation()
        {
            return new ComplexObject
            {
                Field = new SomeOtherObject()
            };
        }

        public void InvalidOperation()
        {
            throw new Exception("some message");
        }
    }
}

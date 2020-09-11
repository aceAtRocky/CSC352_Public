using System;

namespace ExampleClassLibrary
{
    public static class Class1
    {
        public static void MyPublicMethod()
        {
            throw new NotImplementedException();
        }

        private static void MyPrivateMethod()
        {
            throw new NotSupportedException();
        }

        internal static void MyInternalMethod()
        {
            throw new NotSupportedException();
        }
    }
}

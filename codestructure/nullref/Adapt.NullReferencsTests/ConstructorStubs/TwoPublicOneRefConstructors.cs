using System;

namespace Adapt.NullReferenceTests.ConstructorStubs {
    public class TwoPublicOneRefConstructors {
        public TwoPublicOneRefConstructors(string param)
        {
            throw new ArgumentNullException();
        }
        public TwoPublicOneRefConstructors(object param)
        {
            throw new ArgumentNullException();
        }
    }
}
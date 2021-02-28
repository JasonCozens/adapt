using System;

namespace Adapt.NullReferenceTests.ConstructorStubs {
    public class OnePublicConstructorOneRef {
        public OnePublicConstructorOneRef(object param)
        {
            throw new ArgumentNullException();
        }
    }
}
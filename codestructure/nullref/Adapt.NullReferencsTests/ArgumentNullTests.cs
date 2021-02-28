using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace Adapt.NullReferenceTests
{
    public class ArgumentNullTests
    {
        private static ITestOutputHelper output;

        public ArgumentNullTests(ITestOutputHelper output)
        {
            ArgumentNullTests.output = output;
        }

        [Theory]
        [MemberData(nameof(GetConstrutorTests))]
        public void NullArgument_ThrowsArgumentNullException(Action nullTest)
        {
            try
            {
                nullTest.Invoke();
                Assert.False(true, "No exception thrown");
            }
            catch (System.Exception ex)
            {
                Assert.IsType<ArgumentNullException>(ex.InnerException);
            }
        }

        public static IEnumerable<object[]> GetConstrutorTests()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes())
            {
                var @namespace = type.Namespace;
                if (@namespace != null && @namespace.StartsWith("Adapt.NullReferenceTests.ConstructorStubs"))
                {
                    foreach (var action in ArgumentNullConstructorTests(type))
                    {
                        yield return new object[] { action };
                    };
                }
            }
        }

        private static Action[] ArgumentNullConstructorTests(Type type)
        {
            var actions = new List<Action> { };
            foreach (var constructorInfo in type.GetConstructors())
            {
                if (constructorInfo.GetParameters().Length == 1)
                {
                    actions.Add(NullArgumentTest(type, constructorInfo));
                }
            }
            return actions.ToArray();
        }

        private static Action NullArgumentTest(Type type, ConstructorInfo constructorInfo)
        {
            return new Action(() =>
                            {
                                output.WriteLine($"Inside Test: {type.FullName}.{constructorInfo.Name} - {constructorInfo.GetParameters().Length}");
                                constructorInfo.Invoke(new object[] { null });
                            });
        }
    }
}

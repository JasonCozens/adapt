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
                // ConstructorInfo c;
                foreach (var c in type.GetConstructors())
                {
                    // c = con;
                    if (c.GetParameters().Length == 1)
                    {
                        yield return new object[] {
                            new Action(() => {
                                output.WriteLine($"Inside Test: {type.FullName}.{c.Name} - {c.GetParameters().Length}");
                                c.Invoke(new object[] {null}); })
                            };
                    }
                }
            }
        }
    }
}

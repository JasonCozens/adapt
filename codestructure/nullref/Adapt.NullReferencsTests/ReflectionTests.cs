using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Adapt.NullReferencsTests
{
    public interface IRelect
    {
        public void Execute();
    }

    public class ReflectionClass
    {
        public ReflectionClass()
        {

        }

        public ReflectionClass(IReflect reflect)
        {

        }
    }

    public class ReflectionTests
    {
        [Fact]
        public void GetReflectionClassTest()
        {
            var assembly = Assembly.GetExecutingAssembly();

            var reflectionClass = assembly.GetType("Adapt.NullReferencsTests.ReflectionClass");

            Assert.NotNull(reflectionClass);
        }

        [Fact]
        public void GetReflectionClassConstructorsTest()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var reflectionClass = assembly.GetType("Adapt.NullReferencsTests.ReflectionClass");

            var constructors = reflectionClass.GetConstructors();

            Assert.Equal(2, constructors.Count());
            Assert.Equal(1, constructors.Count(c => c.GetParameters().Length == 0));
            Assert.Equal(1, constructors.Count(c => c.GetParameters().Length == 1));
        }
    }
}

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
    }
}

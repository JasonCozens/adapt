using Moq;
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
        private readonly IReflect _reflect;

        public ReflectionClass()
        {

        }

        public ReflectionClass(IReflect reflect)
        {
            _reflect = reflect ?? throw new ArgumentNullException(nameof(reflect));
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

            Assert.Equal(2, constructors.Length);
            Assert.Equal(1, constructors.Count(c => c.GetParameters().Length == 0));
            Assert.Equal(1, constructors.Count(c => c.GetParameters().Length == 1));
        }

        [Fact]
        public void GetParameterType()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var reflectionClass = assembly.GetType("Adapt.NullReferencsTests.ReflectionClass");
            var constructor = reflectionClass.GetConstructors().First(c => c.GetParameters().Length == 1);

            var parameter = constructor.GetParameters()[0];

            Assert.Equal(typeof(IReflect), parameter.ParameterType);
        }

        [Fact]
        public void InvokeDefaultConstructor()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var reflectionClassType = assembly.GetType("Adapt.NullReferencsTests.ReflectionClass");
            var constructor = reflectionClassType.GetConstructors().First(c => c.GetParameters().Length == 0);

            var reflectionClass = constructor.Invoke(null);

            Assert.Equal(typeof(ReflectionClass), reflectionClass.GetType());
        }

        [Fact]
        public void InvokeOneParameterConstructor()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var reflectionClassType = assembly.GetType("Adapt.NullReferencsTests.ReflectionClass");
            var constructor = reflectionClassType.GetConstructors().First(c => c.GetParameters().Length == 1);
            var iReflectMock = new Mock<IReflect>();

            var reflectionClass = constructor.Invoke(new object[] { iReflectMock.Object });

            Assert.Equal(typeof(ReflectionClass), reflectionClass.GetType());
        }
    }
}

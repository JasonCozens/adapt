using Xunit;
using Xunit.Abstractions;

namespace Adapt.NullReferenceTests
{
    public class ConstructorTests
    {
        private readonly ITestOutputHelper output;

        public ConstructorTests(ITestOutputHelper output)
        {
            this.output = output; 
        }

        [Fact]
        public void ListTypes()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            foreach (var m in assembly.GetTypes())
            {
                output.WriteLine($"Type: {m.FullName}");
            }
        }

        [Fact]
        public void ListConstructors()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            foreach (var m in assembly.GetTypes())
            {
                foreach (var c in m.GetConstructors())
                {
                    output.WriteLine($"Constructor: {m.FullName}.{c.Name} - {c.GetParameters().Length}");
                }
            }
        }
    }
}
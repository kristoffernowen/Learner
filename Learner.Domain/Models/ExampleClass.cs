using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learner.Domain.Models
{
    internal abstract class ExampleClass<T> where T : class
    {
        public string Title { get; set; }
        public abstract List<T> GetCollection();
    }

    internal abstract class ExampleNestedClass
    {
        public string Name { get; set; }
    }

    internal class ClassOne : ExampleNestedClass
    {

    }

    internal class ClassTwo : ExampleNestedClass
    {

    }
}

using System.Collections;

namespace Semantics.BigStepSemantics;

public class Environment : Dictionary<string, Expression>
{
    public Environment()
    {}
    public Environment(Dictionary<string, Expression> environment) : base(environment)
    {}
    public void Display()
    {
        this.Select(i => $"{{{i.Key}=>{i.Value}}}").ToList().ForEach(Console.WriteLine);
    }
}
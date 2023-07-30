namespace Semantics.BigStepSemantics;

public class Variable : Expression
{
    public string Name { get; }
    public Variable(string name)
    {
        Name = name;
    }

    public override Expression Evaluate(Environment environment)
    {
        return environment[Name];
    }

    public override string ToString()
    {
        return Name.ToString();
    }
}

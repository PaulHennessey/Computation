namespace Semantics.SmallStepSemantics;

public class Variable : Expression
{
    public string Name { get; }
    public Variable(string name)
    {
        Name = name;
    }

    public override bool Reducible()
    {
        return true;
    }

    public override string ToString()
    {
        return Name.ToString();
    }

    public override Expression Reduce(Environment environment)
    {
        return environment[Name];
    }

}

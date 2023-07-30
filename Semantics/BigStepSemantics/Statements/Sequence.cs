namespace Semantics.BigStepSemantics;

public class Sequence : Statement
{
    public Statement First { get; }
    public Statement Second { get; }
    
    public Sequence(Statement first, Statement second)
    {
        First = first;
        Second = second;
    }

    public override string ToString()
    {
        return $"{First}; {Second}";
    }

    public override void Evaluate(Environment environment)
    {
        First.Evaluate(environment);
        Second.Evaluate(environment);
    }

}
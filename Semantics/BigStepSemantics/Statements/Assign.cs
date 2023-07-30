namespace Semantics.BigStepSemantics;

public class Assign : Statement
{
    public string Name { get; }
    public Expression Expression { get; }
    public Assign(string name, Expression expression)
    {
        Name = name;
        Expression = expression;
    }

    public override string ToString()
    {
        return $"{Name} = {Expression}";
    }

    public override void Evaluate(Environment environment)
    {
        if(environment.ContainsKey(Name))
        {
            environment[Name] = Expression.Evaluate(environment);
        }
        else
        {            
            environment.Add(Name, Expression.Evaluate(environment));
        }
    }
}

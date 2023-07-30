namespace Semantics.SmallStepSemantics;

public class Assign : Statement
{
    public string Name { get; }
    public Expression Expression { get; }
    public Assign(string name, Expression expression)
    {
        Name = name;
        Expression = expression;
    }

    public override bool Reducible()
    {
        return true;
    }

    public override string ToString()
    {
        return $"{Name} = {Expression}";
    }

    public override Statement Reduce(Environment environment)
    {
        if(Expression.Reducible())
        {
            return new Assign(Name, Expression.Reduce(environment));
        }
        else
        {
            if(environment.ContainsKey(Name))
            {
                environment[Name] = Expression;
            }
            else
            {            
                environment.Add(Name, Expression);
            }

            return new DoNothing();
        }
    }
}

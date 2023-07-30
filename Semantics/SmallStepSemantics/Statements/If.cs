namespace Semantics.SmallStepSemantics;

public class If : Statement
{
    public Expression Condition { get; }
    public Statement Consequence { get; }
    public Statement Alternative { get; }
    
    public If(Expression condition, Statement consequence, Statement alternative)
    {
        Condition = condition;
        Consequence = consequence;
        Alternative = alternative;
    }

    public override bool Reducible()
    {
        return true;
    }

    public override string ToString()
    {
        return $"if ({Condition}) {{ {Consequence} }} else {{ {Alternative} }}";
    }

    public override Statement Reduce(Environment environment)
    {
         if(Condition.Reducible())
        {
            return new If(Condition.Reduce(environment), Consequence, Alternative);
        }
        else
        {
            Boolean condition = (Boolean)Condition;
            if(condition.Value)
                return Consequence;
            else
                return Alternative;
        }
    }
}
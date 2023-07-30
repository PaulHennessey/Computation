namespace Semantics.BigStepSemantics;

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

    public override void Evaluate(Environment environment)
    {
        Boolean condition = (Boolean)Condition.Evaluate(environment);
        if(condition.Value)
            Consequence.Evaluate(environment);
        else
            Alternative.Evaluate(environment);
    }

    public override string ToString()
    {
        return $"if ({Condition}) {{ {Consequence} }} else {{ {Alternative} }}";
    }
}
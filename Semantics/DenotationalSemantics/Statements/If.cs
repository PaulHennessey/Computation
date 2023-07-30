namespace Semantics.DenotationalSemantics;

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

    public override string ToString()
    {
        return $"if ({Condition}) {{ {Consequence} }} else {{ {Alternative} }}";
    }

    public override string ToCSharp(Environment e)
    {
        return @"(e, exp) => {        
                if (exp.Condition.ToCSharp(e)) 
                {
                    exp.Consequence.ToCSharp(e)
                } 
                else 
                {
                    exp.Alternative.ToCSharp(e)
                }
            };";
    }
}

namespace Semantics.DenotationalSemantics;

public class While  : Statement
{
    public Expression Condition { get; }
    public Statement Body { get; }
    public While(Expression condition, Statement body)
    {
        Condition = condition;
        Body = body;
    }

    public override string ToString()
    {
        return $"while ({Condition}) {{ {Body} }}";
    }

    public override string ToCSharp(Environment e)
    {
        return @"(e, exp) => { 
            while (exp.Condition.ToCSharp(e)) 
            {
                exp.Body.ToSharp(e);
            }
        };";
    }    
}
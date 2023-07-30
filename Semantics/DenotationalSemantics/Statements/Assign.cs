namespace Semantics.DenotationalSemantics;

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

    public override string ToCSharp(Environment e)
    {
        return @"(e, exp) => {
                if(e.ContainsKey(Name))
                {
                    e[Name] = exp.ToCSharp(e);
                }
                else
                {            
                    e.Add(Name, exp.ToCSharp(e));
                }
        }";
    }
}

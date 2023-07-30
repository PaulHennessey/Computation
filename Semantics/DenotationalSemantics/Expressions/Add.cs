namespace Semantics.DenotationalSemantics;

public class Add : Expression
{
    public Expression Left { get; }
    public Expression Right { get; }
    public Add(Expression left, Expression right)
    {
        Left = left;
        Right = right;
    }

    public override string ToString()
    {
        return $"{Left} + {Right}";
    }

    public override string ToCSharp(Environment e)
    {        
        return "(e, a) => {return a.Left.ToCSharp(e) + a.Right.ToCSharp(e);}";
    }
}   
namespace Semantics.DenotationalSemantics;

public class Multiply : Expression
{
    Expression Left { get; }
    Expression Right { get; }
    public Multiply(Expression left, Expression right)
    {
        Left = left;
        Right = right;
    }

    public override string ToString()
    {
        return $"{Left} * {Right}";
    }

    public override string ToCSharp(Environment e)
    {
        return "(e, a) => {return a.Left.ToCSharp(e) * a.Right.ToCSharp(e);}";
    }
}   
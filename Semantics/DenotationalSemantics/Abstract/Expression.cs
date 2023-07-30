namespace Semantics.DenotationalSemantics;
public abstract class Expression
{
    public abstract String ToCSharp(Environment environment);
}

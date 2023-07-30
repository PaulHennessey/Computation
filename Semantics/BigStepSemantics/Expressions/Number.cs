﻿namespace Semantics.BigStepSemantics;

public class Number : Expression
{
    public int Value { get; }
    public Number(int value)
    {
        Value = value;
    }

    public override Expression Evaluate(Environment environment)
    {
        return this;
    }

    public override bool Equals(Object obj)
    {
        if ((obj == null) || ! this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else {
            Number n = (Number) obj;
            return (Value == n.Value);
        }
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}

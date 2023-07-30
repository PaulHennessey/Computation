using Semantics.DenotationalSemantics;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

using Boolean = Semantics.DenotationalSemantics.Boolean;
using Environment = Semantics.DenotationalSemantics.Environment;
using System.Reflection;

namespace Semantics.DenotationalSemanticsTest;

[TestClass]
public class UnitTest
{
    [TestMethod]
    public async Task TestNumber()
    {
        var number = new Number(1);
        var environment = new Environment();

        var expectedLambda = "(e, n) => {return n.Value;}";
        var actualLambda = number.ToCSharp(environment);
        Assert.AreEqual(expectedLambda, actualLambda);

        var options = ScriptOptions.Default.AddReferences(typeof(Environment).Assembly);
        Func<Environment, Number, int> func = await CSharpScript.EvaluateAsync<Func<Environment, Number, int>>(actualLambda, options);

        int result = func(environment, number);
        Assert.AreEqual(number.Value, result);
    }

    [TestMethod]
    public async Task TestBoolean()
    {
        var boolean = new Boolean(true);
        var environment = new Environment();

        var expectedLambda = "(e, b) => {return b.Value;}";
        var actualLambda = boolean.ToCSharp(environment);
        Assert.AreEqual(expectedLambda, actualLambda);

        var options = ScriptOptions.Default.AddReferences(typeof(Environment).Assembly);
        Func<Environment, Boolean, bool> func = await CSharpScript.EvaluateAsync<Func<Environment, Boolean, bool>>(actualLambda, options);

        bool result = func(environment, boolean);
        Assert.AreEqual(boolean.Value, result);
    }        

    [TestMethod]
    public async Task TestVariable()
    {
        Variable variable = new Variable("x");
        var environment = new Environment()
        {
            {"x", new Number(1)}
        };

        var expected = "(e, v) => {return e[v.Name];}";
        var actual = variable.ToCSharp(environment);
        Assert.AreEqual(expected, actual);

        var options = ScriptOptions.Default.AddReferences(typeof(Environment).Assembly);
        Func<Environment, Variable, Expression> func = await CSharpScript.EvaluateAsync<Func<Environment, Variable, Expression>>(actual, options);
        
        Number result = (Number)func(environment, variable);
        Assert.AreEqual(1, result.Value);
    }            

    [TestMethod]
    public async Task TestAddExpression()
    {
        Add add = new Add
        (
            new Number(1),
            new Number(1)
        );
        var environment = new Environment();

        var expected = "(e, a) => {return a.Left.ToCSharp(e) + a.Right.ToCSharp(e);}";
        var actual = add.ToCSharp(environment);
        Assert.AreEqual(expected, actual);
    }            

    [TestMethod]
    public async Task TestRoslyn()
    {
        // Good info about expressions: https://stackoverflow.com/questions/793571/why-would-you-use-expressionfunct-rather-than-funct

        var options = ScriptOptions.Default.AddReferences(typeof(Semantics.DenotationalSemantics.Number).Assembly);
        var result = await CSharpScript.EvaluateAsync("return 2 + new Semantics.DenotationalSemantics.Number(3).Value;", options);
        Assert.AreEqual(5, result);
    }            

    [TestMethod]
    public void TestMultiplyExpression()
    {
        Multiply multiply = new Multiply
        (
            new Number(1),
            new Number(1)
        );

        var environment = new Environment();

        var expected = "(e, a) => {return a.Left.ToCSharp(e) * a.Right.ToCSharp(e);}";
        var actual = multiply.ToCSharp(environment);
        Assert.AreEqual(expected, actual);
    }                

    [TestMethod]
    public void TestLessThanExpression()
    {
        LessThan lessThan = new LessThan
        (
            new Number(1),
            new Number(1)
        );

        var environment = new Environment();

        var expected = "(e, a) => {return a.Left.ToCSharp(e) < a.Right.ToCSharp(e);}";
        var actual = lessThan.ToCSharp(environment);
        Assert.AreEqual(expected, actual);
    }                    
}

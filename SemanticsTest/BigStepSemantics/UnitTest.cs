using Semantics.BigStepSemantics;

namespace Semantics.BigStepSemanticsTest;

[TestClass]
public class UnitTest
{
    [TestMethod]
    public void TestNumberExpression()
    {
        Number number = new Number(23);

        number.Evaluate(new BigStepSemantics.Environment());

        Assert.AreEqual(23, number.Value);
    }    

    [TestMethod]
    public void TestVariableExpression()
    {
        Variable variable = new Variable("x");

        Number number = (Number)variable.Evaluate
        (
            new BigStepSemantics.Environment()
            {
                {"x", new Number(23)}
            }
        );

        Assert.AreEqual(23, number.Value);
    }    


    [TestMethod]
    public void TestAdd()
    {        
        Add add = new Add
        (
            new Number(2),
            new Number(3)
        );
        
        Number number = (Number)add.Evaluate(new BigStepSemantics.Environment());

        Assert.AreEqual(5, number.Value);
    }        

    [TestMethod]
    public void TestLessThanExpression()
    {        
        LessThan lessThan = new LessThan
        (
            new Add
            (
                new Variable("x"),
                new Number(2)
            ),
            new Variable("y")
        );
        
        BigStepSemantics.Boolean boolean = (BigStepSemantics.Boolean)lessThan.Evaluate
        (
            new BigStepSemantics.Environment()
            {
                {"x", new Number(2)},
                {"y", new Number(5)}
            }
        );        

        Assert.AreEqual("True", boolean.ToString());
    }            

    [TestMethod]
    public void TestNestedAddExpression()
    {        
        Add add = new Add
        (
            new Add
            (
                new Number(2),
                new Number(3)
            ),
            new Add
            (
                new Number(4),
                new Number(5)
            )
        );
        
        Number number = (Number)add.Evaluate(new BigStepSemantics.Environment());

        Assert.AreEqual(14, number.Value);
    }                

    [TestMethod]
    public void TestNestedMultiplyExpression()
    {        
        Multiply multiply = new Multiply
        (
            new Multiply
            (
                new Number(2),
                new Number(3)
            ),
            new Multiply
            (
                new Number(4),
                new Number(5)
            )
        );
        
        Number number = (Number)multiply.Evaluate(new BigStepSemantics.Environment());

        Assert.AreEqual(120, number.Value);
    }                

    [TestMethod]
    public void TestSimpleAssignmentStatement()
    {   
        var environment = new BigStepSemantics.Environment();
        var expected = new BigStepSemantics.Environment()
        {
            {"x", new Number(1)}
        };

        Assign assign = new Assign
        (
            "x",
            new Number(1)
        );
        
        assign.Evaluate(environment);
        
        environment.Display();
        Assert.IsTrue(environment.SequenceEqual(expected));
    }                

    [TestMethod]
    public void TestSimpleAssignmentStatementWithAdd()
    {        
        var environment = new BigStepSemantics.Environment();
        var expected = new BigStepSemantics.Environment()
        {
            {"x", new Number(3)}
        };

        Assign assign = new Assign
        (
            "x",
            new Add
            (
                new Number(1),
                new Number(2)
            )
        );

        assign.Evaluate(environment);
        
        environment.Display();
        Assert.IsTrue(environment.SequenceEqual(expected));
    }                    

    [TestMethod]
    public void TestOverrideAssignmentWithAdd()
    {        
        var environment = new BigStepSemantics.Environment()
        {
            {"x", new Number(1)},
            {"y", new Number(4)}
        };
        var expected = new BigStepSemantics.Environment()
        {
            {"x", new Number(3)},
            {"y", new Number(4)}
        };

        Assign assign = new Assign
        (
            "x",
            new Add
            (
                new Number(1),
                new Number(2)
            )
        );

        assign.Evaluate(environment);
        
        environment.Display();
        Assert.IsTrue(environment.SequenceEqual(expected));
    }                        

    [TestMethod]
    public void TestIfStatement()
    {
        var environment = new BigStepSemantics.Environment()
        {
            {"x", new BigStepSemantics.Boolean(true)}
        };
        var expected = new BigStepSemantics.Environment()
        {
            {"x", new BigStepSemantics.Boolean(true)},
            {"y", new Number(1)}
        };

        If select = new If
        (
            new Variable("x"),
            new Assign
            (
                "y",
                new Number(1)
            ),
            new Assign
            (
                "y",
                new Number(2)
            )                
        );

        Console.WriteLine(select);

        select.Evaluate(environment);
        environment.Display();
        Assert.IsTrue(environment.SequenceEqual(expected));
    }       

    [TestMethod]
    public void TestSequence()
    {
        var environment = new BigStepSemantics.Environment()
        {};
        var expected = new BigStepSemantics.Environment()
        {
            {"x", new Number(2)},
            {"y", new Number(5)}
        };

        Sequence sequence = new Sequence
        (
            new Assign
            (
                "x",
                new Add
                (
                    new Number(1),
                    new Number(1)
                )
            ),
            new Assign
            (
                "y",
                new Add
                (
                    new Variable("x"),
                    new Number(3)
                )
            )                
        );

        Console.WriteLine(sequence);

        sequence.Evaluate(environment);
        environment.Display();
        Assert.IsTrue(environment.SequenceEqual(expected));
    }       


    [TestMethod]
    public void TestWhileStatement()
    {
        var environment = new BigStepSemantics.Environment()
        {
            {"x", new Number(1)}                
        };
        var expected = new BigStepSemantics.Environment()
        {
            {"x", new Number(9)}
        };

        While loop = new While
        (
            new LessThan
            (
                new Variable("x"),
                new Number(5)
            ),
            new Assign
            (
                "x",
                new Multiply
                (
                    new Variable("x"),
                    new Number(3)    
                )
            )                
        );

        Console.WriteLine(loop);

        loop.Evaluate(environment);
        environment.Display();
        Assert.IsTrue(environment.SequenceEqual(expected));
    }                
}
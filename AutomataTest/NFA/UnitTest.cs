using Automata.Common;
using Automata.NFA;

namespace AutomataTest.NFATest;

[TestClass]
public class UnitTest
{
    NFARulebook rulebook = new NFARulebook(
        new List<FARule>()
        {
            new FARule(1, 'a', 1),
            new FARule(1, 'b', 1),
            new FARule(1, 'b', 2),
            new FARule(2, 'a', 3),
            new FARule(2, 'a', 3),
            new FARule(2, 'b', 3),
            new FARule(3, 'a', 4),
            new FARule(3, 'b', 4)
        }
    );

    [TestMethod]
    public void TestMethod1()
    {        
        CollectionAssert.AreEqual(new List<int>{1, 2}, rulebook.NextStates(new List<int>{1}, 'b'));
        CollectionAssert.AreEqual(new List<int>{1, 3}, rulebook.NextStates(new List<int>{1, 2}, 'a'));
        CollectionAssert.AreEqual(new List<int>{1, 2, 4}, rulebook.NextStates(new List<int>{1, 3}, 'b'));
    }

    [TestMethod]
    public void TestMethod2()
    {        
        NFA nfa = new NFA(new List<int>{1}, new List<int>{4}, rulebook);
        Assert.AreEqual(false, nfa.Accepting());

        nfa = new NFA(new List<int>{1, 2, 4}, new List<int>{4}, rulebook);
        Assert.AreEqual(true, nfa.Accepting());

    }

    [TestMethod]
    public void TestMethod3()
    {        
        NFA nfa = new NFA(new List<int>{1}, new List<int>{4}, rulebook);
        Assert.AreEqual(false, nfa.Accepting());

        nfa.ReadCharacter('b');
        Assert.AreEqual(false, nfa.Accepting());

        nfa.ReadCharacter('a');
        Assert.AreEqual(false, nfa.Accepting());

        nfa.ReadCharacter('b');
        Assert.AreEqual(true, nfa.Accepting());
    }


    [TestMethod]
    public void TestMethod4()
    {        
        NFA nfa = new NFA(new List<int>{1}, new List<int>{4}, rulebook);
        Assert.AreEqual(false, nfa.Accepting());

        nfa.ReadString("bbbbb");
        Assert.AreEqual(true, nfa.Accepting());
    }

    [TestMethod]
    public void TestMethod5()
    {        
        NFADesign design = new NFADesign(1, new List<int>{4}, rulebook);

        Assert.AreEqual(true, design.Accepts("bab"));
        Assert.AreEqual(true, design.Accepts("bbbbb"));
        Assert.AreEqual(false, design.Accepts("bbabb"));
    }

}
namespace Automata.NFA;

using Automata.Common;

public class NFARulebook
{
    public List<FARule> Rules { get; set; }
    public NFARulebook(List<FARule> rules)
    {
        Rules = rules;
    }

    // This takes a list of states, and a character, and returns a list of possible next states
    public List<int> NextStates(List<int> states, char character)
    {
        return states.SelectMany(s => FollowRulesFor(s, character)).Distinct().ToList();
    }

    // https://blog.submain.com/csharp-functional-programming/


    // This takes a list of rules and returns a list of next states
    private List<int> FollowRulesFor(int state, char character)
    {
        return RulesFor(state, character).Select(r => r.NextState).ToList();
    }

    // This returns a list of rules that could apply for a given state/character
    private List<FARule> RulesFor(int state, char character)
    {
        return Rules.Where(r => r.AppliesTo(state, character)).ToList();
    }    
}

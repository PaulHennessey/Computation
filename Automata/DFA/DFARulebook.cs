namespace Automata.DFA;

using Automata.Common;

public class DFARulebook
{
    public List<FARule> Rules { get; set; }
    public DFARulebook(List<FARule> rules)
    {
        Rules = rules;
    }

    public int NextState(int state, char character)
    {
        return RuleFor(state, character).NextState;
    }

    private FARule RuleFor(int state, char character)
    {
        return Rules.Where(r => r.AppliesTo(state, character)).First();
    }
}

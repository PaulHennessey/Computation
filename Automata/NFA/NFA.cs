namespace Automata.NFA;
public class NFA
{
    public List<int> CurrentStates { get; set; }
    public List<int> AcceptStates { get; set; }
    public NFARulebook Rulebook { get; set; }
    public NFA(List<int> currentStates, List<int> acceptStates, NFARulebook rulebook)
    {
        CurrentStates = currentStates;
        AcceptStates = acceptStates;
        Rulebook = rulebook;
    }

    public bool Accepting()
    {
        return AcceptStates.Intersect(CurrentStates).Count() > 0;
    }

    public void ReadCharacter(char c)
    {
        CurrentStates = Rulebook.NextStates(CurrentStates, c);
    }

    public void ReadString(string s)
    {
        foreach(char c in s)
            ReadCharacter(c);
    }    
}

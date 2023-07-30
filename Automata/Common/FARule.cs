namespace Automata.Common;

public class FARule
{
    public int State { get; set;}
    public char Character { get; set;}
    public int NextState { get; set;}
    public FARule(int state, char character, int nextState)
    {
        State = state;
        Character = character;
        NextState = nextState;
    }

    public bool AppliesTo(int state, char character)
    {
        return this.State == state && this.Character == character;
    }

    public override string ToString()
    {
        return $"FARule {State} --- {Character} --> {NextState}";
    }

}

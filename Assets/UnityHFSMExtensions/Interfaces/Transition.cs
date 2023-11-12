namespace UnityHFSMExtensions.Interfaces
{
    public interface Transition
    {
    #region Public Variables

        bool   Condition  { get; }
        string FromStates { get; }
        string ToState    { get; }

    #endregion
    }
}
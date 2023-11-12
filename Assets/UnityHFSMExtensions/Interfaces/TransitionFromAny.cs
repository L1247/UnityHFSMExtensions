namespace UnityHFSMExtensions.Interfaces
{
    public interface TransitionFromAny
    {
    #region Public Variables

        bool   Condition { get; }
        string ToState   { get; }

    #endregion
    }
}
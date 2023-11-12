#region

using System.Collections.Generic;

#endregion

namespace UnityHFSMExtensions.Interfaces
{
    public interface Transitions
    {
    #region Public Variables

        bool         Condition  { get; }
        List<string> FromStates { get; }
        string       ToState    { get; }

    #endregion
    }
}
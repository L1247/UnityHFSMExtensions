#region

using System.Collections.Generic;

#endregion

namespace UnityHFSMExtensions.Interfaces
{
    public interface TriggerTransitions
    {
    #region Public Variables

        List<string> FromStates { get; }
        string       ToState    { get; }

        public string Trigger { get; }

    #endregion
    }
}
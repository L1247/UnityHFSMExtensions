#region

using UnityHFSMExtensions.Interfaces;

#endregion

namespace Sample.Scripts
{
    public class TransitionTest : Transition
    {
    #region Public Variables

        public bool   Condition  => true;
        public string FromStates => "A";
        public string ToState    => "B";

    #endregion
    }
}
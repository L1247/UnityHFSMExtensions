#region

using UnityHFSM;

#endregion

namespace UnityHFSMExtensions.Inherits
{
    public class SMState : State
    {
    #region Public Variables

        public StateMachine sm => (StateMachine)fsm;

    #endregion
    }
}
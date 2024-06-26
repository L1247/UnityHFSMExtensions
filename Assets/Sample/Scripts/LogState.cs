#region

using UnityEngine;
using UnityHFSMExtensions.Main;
using Zenject;

#endregion

namespace Sample.Scripts
{
    public class LogState : ITickable
    {
    #region Private Variables

        [Inject]
        private FsmManager fsmManager;

    #endregion

    #region Public Methods

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space) && fsmManager.Initialized)
            {
                Debug.Log($"{fsmManager.GetState("A").name}");
                Debug.Log($"{fsmManager.GetState<TestState>().name}");
                Debug.Log($"{fsmManager.GetCurrentStateName()}");
                fsmManager.ChangeState(nameof(TestState));
                Debug.Log($"{fsmManager.GetCurrentStateName()}");
            }
        }

    #endregion
    }
}
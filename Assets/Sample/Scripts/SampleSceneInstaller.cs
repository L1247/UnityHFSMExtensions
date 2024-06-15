#region

using Sample.Scripts;
using UnityHFSMExtensions.Extensions;
using Zenject;

#endregion

public class SampleSceneInstaller : MonoInstaller
{
#region Public Methods

    public override void InstallBindings()
    {
        Container.Bind_FSM();
        Container.Bind_State("A");
        Container.Bind_State("B");
        Container.Bind_State("C");
        Container.Bind_State<TestState>();
        Container.Bind_Start_State("A");

        Container.BindInterfacesTo<LogState>().AsSingle();
    }

#endregion
}
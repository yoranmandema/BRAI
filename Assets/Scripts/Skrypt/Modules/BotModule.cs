using UnityEngine;
using UnityEngine.AI;
using Skrypt;

public class BotModule : BaseModule {
    
    private readonly BotBehaviour _botBehaviour;


    public BotModule(SkryptEngine engine, BotBehaviour botBehaviour) : base(engine) {
        _botBehaviour = botBehaviour;
    }

    public static SkryptObject Move(SkryptEngine engine, SkryptObject self, Arguments arguments) {
        var module = self as BotModule;

        var location = SkryptTypeConverter.FromSkryptVector3(arguments.GetAs<Vector3Instance>(0));

        module._botBehaviour.navMeshAgent.SetDestination(location);

        return null;
    }
}

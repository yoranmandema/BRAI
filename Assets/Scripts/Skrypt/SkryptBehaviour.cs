using System;
using UnityEngine;
using Skrypt;

public class SkryptBehaviour : MonoBehaviour {

    public TextAsset file;
    public readonly SkryptEngine engine;

    private IFunction _updateFunction;

    public SkryptBehaviour() {
        engine = SkryptEngineFactory.CreateEngine();

        engine.SetValue("print", new Action<object>(print));
    }

    private void Execute(string code) {
        try {
            engine.Execute(code);
        }
        catch (SkryptException e) {
            Debug.LogError(e);
        }
    }

    void Start() {
        engine.Execute(file.text);

        var hasUpdate = engine.TryGetValue("Update", out SkryptObject update);

        if (update is FunctionInstance functionInstance) {
            _updateFunction = functionInstance.Function;
        }
    }

    void Update() {
        if (_updateFunction != null)
            _updateFunction.Run(engine, null, Arguments.Empty);
    }
}

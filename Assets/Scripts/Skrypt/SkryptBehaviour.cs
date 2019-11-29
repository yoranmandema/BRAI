using System;
using UnityEngine;
using Skrypt;

public class SkryptBehaviour : MonoBehaviour {

    public TextAsset file;

    private readonly SkryptEngine _engine;
    private IFunction _updateFunction;

    public SkryptBehaviour () {
        _engine = new SkryptEngine();
        _engine.ErrorHandler = new ErrorHandler(_engine);

        _engine.SetValue("print", new Action<object>(print));
    }

    private void Execute (string code) {
        try {
            _engine.Execute(code);
        } catch (SkryptException e) {
            Debug.LogError(e);
        }
    }

    void Start() {
        _engine.Execute(file.text);

        var hasUpdate = _engine.TryGetValue("Update", out SkryptObject update);

        if (update is FunctionInstance functionInstance) {
            _updateFunction = functionInstance.Function;
        }
    }

    void Update() {
        _updateFunction.Run(_engine, null, Arguments.Empty);
    }
}

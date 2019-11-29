using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skrypt;

public class SkryptBehaviour : MonoBehaviour {

    public TextAsset file;

    private readonly SkryptEngine _engine;

    public SkryptBehaviour () {
        _engine = new SkryptEngine();
    }

    private void Execute (string code) {
        try {
            var program = _engine.ParseProgram(code, new Skrypt.Compiling.ParserOptions {
                Tolerant = true
            });

            _engine.Execute(program);
        } catch (SkryptException e) {

        }
    }

    void Start() {
        _engine.Execute(file.text);
    }

    // Update is called once per frame
    void Update() {

    }
}

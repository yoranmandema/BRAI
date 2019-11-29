using UnityEngine;
using Skrypt;

public static class SkryptEngineFactory {
    public static SkryptEngine CreateEngine (Options engineOptions = null) {
        var engine = new SkryptEngine(engineOptions)
                .AddExportTypeMapper(typeof(Vector3Instance), (v) => SkryptTypeConverter.FromSkryptVector3((Vector3Instance)v))
                .AddExportTypeMapper(typeof(Vector2Instance), (v) => SkryptTypeConverter.FromSkryptVector2((Vector2Instance)v))
                ;

        engine.ErrorHandler = new ErrorHandler(engine);

        return engine;
    }
}


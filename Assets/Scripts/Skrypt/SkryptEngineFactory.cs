using UnityEngine;
using Skrypt;

public static class SkryptEngineFactory {

    public static SkryptEngine CreateEngine (Options engineOptions = null) {
        var engine = new SkryptEngine(engineOptions);

        var hitResultType = engine.FastAdd(new HitResultType(engine));

        engine
            .AddExportTypeMapper(typeof(Vector3Instance), (v) => SkryptTypeConverter.FromSkryptVector3((Vector3Instance)v))
            .AddExportTypeMapper(typeof(Vector2Instance), (v) => SkryptTypeConverter.FromSkryptVector2((Vector2Instance)v))
            .AddImportTypeMapper(typeof(RaycastHit), (e, v) => hitResultType.Construct((RaycastHit)v))
            .AddImportTypeMapper(typeof(Vector3), (e, v) => SkryptTypeConverter.ToSkryptVector3(e,(Vector3)v))
            ;

        engine.ErrorHandler = new ErrorHandler(engine);

        return engine;
    }
}


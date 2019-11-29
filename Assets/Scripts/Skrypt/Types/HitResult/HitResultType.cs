using UnityEngine;
using Skrypt;

public class HitResultType : BaseType {
    public HitResultType(SkryptEngine engine) : base(engine) {

    }

    public SkryptInstance Construct(RaycastHit val) {
        var obj = new HitResultInstance(Engine, val);

        obj.GetProperties(Template);
        obj.TypeObject = this;

        return obj;
    }

    public override SkryptInstance Construct(Arguments arguments) {
        var rayCastHit = new RaycastHit {
            point = SkryptTypeConverter.FromSkryptVector3(arguments.GetAs<Vector3Instance>(0)),
            normal = SkryptTypeConverter.FromSkryptVector3(arguments.GetAs<Vector3Instance>(1))
        };

        return Construct(rayCastHit);
    }
}

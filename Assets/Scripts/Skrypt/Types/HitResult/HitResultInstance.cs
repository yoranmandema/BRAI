using UnityEngine;
using Skrypt;

public class HitResultInstance : SkryptInstance {

    public RaycastHit raycastHit;

    public HitResultInstance(SkryptEngine engine, RaycastHit hit) : base(engine) {
        raycastHit = hit;
    }

    public static SkryptObject Normal (SkryptEngine engine, SkryptObject self) {
        var hitResultInstance = self as HitResultInstance;
        var normal = hitResultInstance.raycastHit.normal;

        return engine.CreateVector3(normal.x, normal.y, normal.z);
    }

    public static SkryptObject Position(SkryptEngine engine, SkryptObject self) {
        var hitResultInstance = self as HitResultInstance;
        var point = hitResultInstance.raycastHit.point;

        return engine.CreateVector3(point.x, point.y, point.z);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skrypt;

public static class SkryptTypeConverter {
    public static Vector3 FromSkryptVector3 (Vector3Instance vector3Instance) {
        return new Vector3(
            (float)vector3Instance.Components[0],
            (float)vector3Instance.Components[1],
            (float)vector3Instance.Components[2]
            );
    }
    public static Vector3 FromSkryptVector2(Vector2Instance vector2Instance) {
        return new Vector3(
            (float)vector2Instance.Components[0],
            (float)vector2Instance.Components[1]
            );
    }

    public static Vector3Instance ToSkryptVector3(SkryptEngine engine, Vector3 vector3) {
        return engine.CreateVector3(vector3.x, vector3.y, vector3.z);
    }
}

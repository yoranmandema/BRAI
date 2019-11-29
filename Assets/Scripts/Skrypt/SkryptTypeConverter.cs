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

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCreator : MonoBehaviour
{
    [HideInInspector]
    public Path path;

    public void CreatePath(Transform nextPoint, Vector3 direction, float velocity) {
        this.path = new Path(this.transform.position, nextPoint.position, direction, velocity);
    }
}

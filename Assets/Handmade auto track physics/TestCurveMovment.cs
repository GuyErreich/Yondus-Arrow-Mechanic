using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCurveMovment : MonoBehaviour
{
    [SerializeField] private Transform obj;
    [SerializeField] private List<Transform> points;
    [SerializeField, Range(0, 1)] private float time;

    private List<Vector3> vPoints = new List<Vector3>();

    // Start is called before the first frame update
    private void Awake() {        
        foreach (var point in this.points)
        {
            this.vPoints.Add(point.position);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        for (int i = 0; i < this.points.Count; i++) {
            this.vPoints[i] =  this.points[i].position;
        }

        this.MoveOnCurve(this.vPoints, this.vPoints.Count, this.time);
    }

    private void MoveOnCurve(List<Vector3> points,int numOfPoints, float t) {
        var i = 0;

        if(points.Count > 1 && points.Count <= 2) {
            this.obj.position = BezireCurve.Lerp(points[i], points[i + 1], t);
        }
        else if(points.Count > 2 && points.Count <= 3) {
            this.obj.position = BezireCurve.Quadratic(points[i], points[i + 1], points[i + 2], t);
        }
        else {
            this.obj.position = BezireCurve.Cubic(points[i], points[i + 1], points[i + 2], points[i + 3], t);
        }
    }
}

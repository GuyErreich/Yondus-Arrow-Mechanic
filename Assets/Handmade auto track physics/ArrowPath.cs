using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPath
{
    private List<Vector3> points;

    public ArrowPath(Vector3 anchor1, Vector3 anchor2, Vector3 direction, float velocity) {
        var control1 = anchor1 + (direction * velocity);

        this.points = new List<Vector3> {
            anchor1,
            control1,
            (control1 + anchor2) * .5f,
            anchor2
        };
    }

    public Vector3 this[int i] {
        get {
            return this.points[i];
        }
    }

    //TODO: remember to remove if not used
    public Vector3[] Points {
        get => this.points.ToArray();
    }

    public int NumOfPoints { 
        get {
            return this.points.Count;
        } 
    }

    public int NumOfSegments { 
        get {
            return (this.points.Count - 4) / 3 + 1;
        } 
    }

    public void AddSegment(Vector3 anchor, float force) {
        var direction = (this.points[this.points.Count - 1] - this.points[this.points.Count - 2]);
        this.points.Add(this.points[this.points.Count - 1] + direction * force);
        this.points.Add((this.points[this.points.Count - 1] + anchor) * .5f);
        this.points.Add(anchor);
    }

    public Vector3[] GetPointsInSegment(int i) {
        return new Vector3[] { 
            this.points[i * 3],
            this.points[i * 3 + 1],
            this.points[i * 3 + 2],
            this.points[i * 3 + 3] 
        };
    }

    public void MovePoint(int i , Vector3 pos) {
        this.points[i] = pos;
    }
}

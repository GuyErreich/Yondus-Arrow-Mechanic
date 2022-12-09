using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCreator : MonoBehaviour
{
    [SerializeField] private List<Transform> points;
    [SerializeField] private bool loop;
    [SerializeField, Range(1, 2)] private float force = 1f;

    public static ArrowPath Path { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(points == null || points.Count == 0)
            return;

        var direction = this.transform.forward;
        var velocity = (this.points[0].position - this.transform.position).magnitude * 0.5f;
        Path = new ArrowPath(this.transform.position, this.points[0].position, direction, velocity);
        
        for (var i = 1; i < this.points.Count; i++) {
            Path.AddSegment(this.points[i].position, this.force);
        }

        if (loop && !Path.isClosed)
            Path.ToggleClosed(force);
    }
}

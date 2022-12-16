using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace YundosArrow.Scripts.Player 
{
    [RequireComponent(typeof(LineRenderer))]
    public class MarkTargets : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private MonoBehaviour shootScript;

        [Header("Raycast settings")]
        [SerializeField] private Transform startPoint;
        [SerializeField] private float radius = 5f;
        [SerializeField] private float range = 5f;
        [SerializeField] private LayerMask layerMask = new LayerMask();

        [Header("Time")]
        [SerializeField] private float duration = 5f;
        [SerializeField, Range(0, 1)] private float slowAmount = 0.5f;

        [Header("Aim assist draw setting")]
        [SerializeField] private GameObject aimPoint;
        [SerializeField] private float pointRange = 20f;

        private float currentTime = 0f;
        private RaycastHit hit;
        private LineRenderer lineRenderer;
        private Transform sphere;

        private void Awake() {
            this.sphere = Instantiate(aimPoint).transform;
            this.sphere.gameObject.SetActive(false);
        }
        private void Start() {
            this.lineRenderer = this.GetComponent<LineRenderer>();
        }

        private void LateUpdate() {
            if (InputReceiver.Bool[InputReceiverType.AimPressed])
                if(this.currentTime == 0f)
                    StartCoroutine(this.StartMarking());
        }

        // Update is called once per frame
        private IEnumerator StartMarking() {
            Time.timeScale = slowAmount;
            TargetsCollection.Points =  new List<Transform>();
            this.lineRenderer.positionCount = 3;
            this.sphere.gameObject.SetActive(true);

            while (this.currentTime <= this.duration) {
                this.Mark();
                this.DrawMarkingLine();
                yield return new WaitForEndOfFrame();

                this.currentTime += Time.unscaledDeltaTime;
            }
            
            
            this.sphere.gameObject.SetActive(false);
            this.lineRenderer.positionCount = 0;
            this.currentTime = 0f;
            Time.timeScale = 1f;
            StartCoroutine((shootScript as ArrowMovement).Move());
        }

        private void Mark() {
            Ray ray = Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f));
            // if (Physics.SphereCast(, this.radius, Camera.main.transform.forward, out hit, this.range, this.layerMask)) {
            if (Physics.SphereCast(ray, this.radius, out this.hit, this.range, this.layerMask)) {
                if (InputReceiver.Bool[InputReceiverType.ShootPressed])
                    if(!TargetsCollection.Points.Contains(this.hit.transform))
                        TargetsCollection.Points.Add(this.hit.transform);
            }

            if (this.hit.point == Vector3.zero)
                this.hit.point = ray.origin + ray.direction * this.pointRange;
        }

        private void DrawMarkingLine() {
            var endPoint = this.hit.point - this.sphere.transform.lossyScale / 2;
            var linePoints =  new Vector3[] {
                this.startPoint.position,
                (endPoint * 2 - (this.hit.point - this.startPoint.position)) * 0.5f,
                endPoint
            };

            var dir = (endPoint - linePoints[0]).normalized;

            this.lineRenderer.material.SetVector("_Direction", dir);
            this.lineRenderer.SetPositions(linePoints);

            this.sphere.gameObject.GetComponent<Renderer>().material.SetVector("_Direction", dir);
            this.sphere.position = endPoint;
        }

        private void OnDrawGizmos() {
            Gizmos.DrawLine(this.startPoint.position,  this.hit.point);
            Gizmos.DrawWireSphere(this.hit.point, this.radius);
            // Gizmos.matrix = Camera.main.transform.localToWorldMatrix;
        }
    }
}

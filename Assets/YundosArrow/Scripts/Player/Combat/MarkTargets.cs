using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YundosArrow.Scripts.Player 
{
    public class MarkTargets : MonoBehaviour
    {
        [Header("Raycast settings")]
        [SerializeField] private Transform mainCamera;
        [SerializeField] private float radius = 5f;
        [SerializeField] private float range = 5f;
        [SerializeField] private LayerMask layerMask = new LayerMask();

        [Header("Time")]
        [SerializeField] private float duration = 5f;
        [SerializeField, Range(0, 1)] private float slowAmount = 0.5f;

        public static List<Transform> Points { get; set; }

        private float currentTime = 0f;

        private void LateUpdate() {
            if (InputReceiver.Bool[InputReceiverType.AimPressed])
                if(this.currentTime == 0f)
                    StartCoroutine(this.StartMarking());
        }

        // Update is called once per frame
        private IEnumerator StartMarking() {
            Time.timeScale = slowAmount;
            Points =  new List<Transform>();

            while (this.currentTime <= this.duration) {
                if (InputReceiver.Bool[InputReceiverType.ShootPressed])
                    this.Mark();

                yield return new WaitForEndOfFrame();

                this.currentTime += Time.unscaledDeltaTime;
            }

            print("done");
            print(this.currentTime);
            
            this.currentTime = 0f;
            Time.timeScale = 1f;
        }

        private void Mark() {
            Ray ray = Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f));
            RaycastHit hit;
            // if (Physics.SphereCast(, this.radius, Camera.main.transform.forward, out hit, this.range, this.layerMask)) {
            if (Physics.SphereCast(ray, this.radius, out hit, this.range, this.layerMask)) {
                if(!Points.Contains(hit.transform))
                    Points.Add(hit.transform);
            }
        }

        private void OnDrawGizmos() {
            Gizmos.matrix = Camera.main.transform.worldToLocalMatrix;
            Gizmos.DrawLine(Camera.main.ScreenToViewportPoint(new Vector2(0.5f, 0.5f)),  Camera.main.transform.forward * (this.range - this.radius));
            Gizmos.DrawWireSphere(Camera.main.transform.forward * this.range, this.radius);
        }
    }
}

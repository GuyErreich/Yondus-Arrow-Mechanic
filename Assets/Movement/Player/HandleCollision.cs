using UnityEngine;

public class HandleCollision : MonoBehaviour {
    [SerializeField, Range(1, 360)] private int precision = 10;
    [SerializeField, Range(0.0001f, 1f)] private float radius = 0.2f;
    [SerializeField] private LayerMask unwantedLayers;

    private CharacterController controller;
    private float distance;
 
    void Awake(){
        this.controller = GetComponent<CharacterController>();
    }
 
    public void Update(){
        this.distance = this.controller.radius + radius;

        RaycastHit hit;
 
        //Bottom of controller. Slightly above ground so it doesn't bump into slanted platforms. (Adjust to your needs)
        Vector3 p1 = this.transform.position + Vector3.up * 0.25f;
        //Top of controller
        Vector3 p2 = p1 + Vector3.up * this.controller.height;
 
        //Check around the character in a 360, 10 times (increase if more accuracy is needed)
        for(int i=0; i<360; i+= 360/this.precision){
            //Check if anything with the platform layer touches this object
            if (Physics.CapsuleCast(p1, p2, 0, new Vector3(Mathf.Cos(i), 0, Mathf.Sin(i)), out hit, this.distance, this.unwantedLayers, QueryTriggerInteraction.Ignore)){
                //If the object is touched by a platform, move the object away from it
                this.controller.Move(hit.normal*(this.distance-hit.distance));
            }
        }
 
        //[Optional] Check the players feet and push them up if something clips through their feet.
        //(Useful for vertical moving platforms)
        // if (Physics.Raycast(this.transform.position + Vector3.up, -Vector3.up, out hit, 1, unwantedLayers, QueryTriggerInteraction.Ignore)){
        //     controller.Move(Vector3.up * (1-hit.distance));
        // }
    }

    void OnDrawGizmosSelected() {
        Gizmos.matrix = this.transform.localToWorldMatrix;  

        Gizmos.color = Color.blue; 

        //Check around the character in a 360, 10 times (increase if more accuracy is needed)
        for (int i = 0; i < 360; i += (360 / this.precision)) {
            var direction = new Vector3(Mathf.Cos(i), 0, Mathf.Sin(i));
            var endPoint = Vector3.zero + (direction * (this.controller.radius + radius));
            Gizmos.DrawLine(endPoint + Vector3.up * 0.25f, endPoint + Vector3.up * this.controller.height);
        }
    }
}
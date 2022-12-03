// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEditor;

// [CustomEditor(typeof(PathCreator))]
// public class TestPath : MonoBehaviour 
// {
//     private PathCreator creator;
//     private Path path;

//     private void OnSceneGUI() {
//         Draw();
//     }

//     private void Draw() {
//         Handles.color = Color.red;
//         for (int i = 0; i < path.NumOfPoints; i++) {
//             var newPos = Handles.FreeMoveHandle(path[i], Quaternion.identity, 1f,Vector3.zero, Handles.CylinderHandleCap);
//             if (path[i] != newPos) {
//                 Undo.RecordObject(creator, "Move point");
//                 path.MovePoint(i, newPos);
//             }
//         }
//     }

//     private void OnEnable() {
//         this.creator = target as PathCreator;
//         if (this.creator.path == null) {
//             var targetTrans = target as Transform;
//             var direction = this.creator.nextPoint.position - targetTrans.position;
//             this.creator.CreatePath(this.creator.nextPoint, direction, this.creator.velocity);
//         }

//         this.path = creator.path;
//     }
// }

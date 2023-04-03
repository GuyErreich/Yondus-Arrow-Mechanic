// using System.Collections.Generic;
// using UnityEngine;

// namespace Assembly_CSharp.Assets.YundosArrow.Scripts
// {
//     public class OutlineInRange : MonoBehaviour
//     {
//         [SerializeField] private Material _outlineMaterial;
//         [SerializeField] private float _range = 70f;
//         [SerializeField] private LayerMask _layerMask;

//         private void Update() {
//             Ray ray = Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f));
//             if (Physics.Raycast(ray, out var hit, _range, _layerMask, QueryTriggerInteraction.Collide)) {
//                 var materials = new List<Material>();
//                 var renderer = hit.collider.gameObject.<Renderer>(false);
//                 materials.Add(renderer.material);
//                 materials.Add(_outlineMaterial);
//                 renderer.GetMaterials(materials);
//             }
//         }
//     }
// }

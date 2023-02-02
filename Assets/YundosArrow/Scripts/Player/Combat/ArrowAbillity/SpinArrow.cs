//using System.Collections;
//using System.Collections.Generic;
//using DG.Tweening;
//using UnityEngine;
//using YundosArrow.Scripts.Player.Combat.ArrowAbilities;
//
//namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities
//{
//    public class SpinArrow : MonoBehaviour, ISerializationCallbackReceiver
//    {
//        [SerializeField] private Vector3Int axis;
//        [SerializeField] private float speed;
//
//        private Vector3Int clamped = new Vector3Int(0,0,0);
//
//        // Update is called once per frame
//        void Update()
//        {
//            ArrowStats.Arrow.DOBlendableLocalRotateBy((Vector3)axis * speed * Time.deltaTime, 0f);
//        }
//
//        public void OnAfterDeserialize()
//        {
//            this.clamped.x = Mathf.Clamp(this.axis.x, 0, 1);
//            this.clamped.y = Mathf.Clamp(this.axis.y, 0, 1);
//            this.clamped.z = Mathf.Clamp(this.axis.z, 0, 1);
//        }
//
//        public void OnBeforeSerialize()
//        {
//            this.axis = clamped;
//        }
//    }
//}

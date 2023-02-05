using Assets.YundosArrow.Scripts.Systems.Managers;
using Assets.YundosArrow.Scripts.Systems.Managers.Enemy;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using YundosArrow.Scripts.UI.HealthBars;

namespace Assets.YundosArrow.Scripts.Editor
{
    public class MenuItems : ScriptableObject
    {
        [MenuItem("GameObject/Systems/Managers/ComboManager")]
        private static void CreateComboManager()
        {
            GameObject go = new GameObject("ComboManager");
            go.AddComponent<ComboManager>();
        }

        [MenuItem("GameObject/Systems/Managers/Enemy/EnemySpawnManager/SpawnArea")]
        private static void CreateSpawnArea()
        {
            GameObject go = new GameObject("SpawnArea");
            go.AddComponent<SpawnArea>();
        }

        [MenuItem("GameObject/Systems/Managers/Enemy/EnemySpawnManager/Manager")]
        private static void CreateEnemySpawnManager()
        {
            GameObject go = new GameObject("EnemySpawnManager");
            go.AddComponent<EnemySpawnManager>();
        }

        [MenuItem("GameObject/Systems/Managers/Enemy/EnemyManager")]
        private static void CreateEnemyManager()
        {
            GameObject go = new GameObject("EnemyManager");
            go.AddComponent<EnemyManager>();
        }


        [MenuItem("GameObject/Systems/Health/DynamicHealthBar")]
        private static void CreateDynamicHealthBar()
        {
            GameObject go = new GameObject("DynamicHealthBar");
            go.AddComponent<DynamicHealthBar>();
            var image = go.GetComponent<Image>();

            image.type = Image.Type.Filled;
            image.fillMethod = Image.FillMethod.Horizontal;
            image.fillOrigin = (int)Image.OriginHorizontal.Right;
        }
    }
}
using Common;
using UnityEngine;
using UnityEngine.UI;

namespace Battle.Tests
{
    public class TestPD : Producer
    {
        public Vector2 scale;
        public Vector2 offset;

        [Range(0,100)]
        public float limit;

        public GameObject model;

        public override IMgr imgr => null;

        //==================================================================================================

        public override void init(int priority)
        {
            var camera = BattleSceneRoot.instance.mainCamera;
            camera.transform.localPosition = new(50, 50, -10);
            camera.orthographicSize = 60;
        }


        public override void call()
        {
            var count = transform.childCount;
            for (int i = 0; i < count; i++)
            {
                DestroyImmediate(transform.GetChild(0).gameObject);
            }

            GenerateRandomMap();
        }


        //private void Update()
        //{
        //    GenerateRandomMap();
        //}


        void GenerateRandomMap()
        {
            Vector2 ori;

            for (int y = 0; y < 100; y++)
            {
                for (int x = 0; x < 100; x++)
                {
                    ori = new(x, y);
                    ori += offset;
                    ori.x /= scale.x;
                    ori.y /= scale.y;

                    var value = Mathf.PerlinNoise(ori.x, ori.y) * 100;

                    if (value > limit)
                    {
                        var cell = Instantiate(model, transform);
                        cell.transform.localPosition = new(x, y);
                        cell.gameObject.SetActive(true);
                    }
                }
            }
        }
    }
}


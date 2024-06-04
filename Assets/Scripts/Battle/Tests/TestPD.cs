using Common;
using UnityEngine;
using UnityEngine.UI;

namespace Battle.Tests
{
    public class TestPD : Producer
    {
        public float scale;
        public Vector2 offset;

        [Header("out")]
        public RawImage output;

        public override IMgr imgr => null;

        //==================================================================================================

        public override void init(int priority)
        {
            //GenerateRandomMap();
        }


        public override void call()
        {
            //GenerateRandomMap();
        }


        private void Update()
        {
            GenerateRandomMap();
        }


        void GenerateRandomMap()
        {
            var depthMap = new Texture2D(100, 100);
            Vector2 ori;

            for (int y = 0; y < depthMap.height; y++)
            {
                for (int x = 0; x < depthMap.width; x++)
                {
                    ori = new(x, y);
                    ori += offset;
                    ori /= scale;

                    float noiseValue = Mathf.PerlinNoise(ori.x, ori.y);

                    Color color = new(noiseValue, noiseValue, noiseValue, 1.0f);
                    depthMap.SetPixel(x, y, color);
                }
            }

            depthMap.Apply();

            output.texture = depthMap;
        }
    }
}


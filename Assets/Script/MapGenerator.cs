using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject tilePrefab; // 配置する地形タイル
    public int mapWidth = 100; // マップの横幅
    public int mapHeight = 10; // マップの最大高さ
    public float noiseScale = 0.1f; // ノイズのスケール
    public int[] options = new int[5];

    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        int preY = 0;
        for (int x = 5; x < mapWidth; x++)
        {
            // Perlinノイズで高さを決定
            // float height = Mathf.PerlinNoise(x * noiseScale, 0) * mapHeight;
            // int yMax = Mathf.FloorToInt(height);

            int index = Random.Range(0, options.Length);
            int diff = options[index];
            int Ymax = preY + diff > -5 ? preY + diff : -5;
            preY = Ymax;

            // 0からyMaxまでタイルを配置
            for (int y = -5; y <= Ymax; y++)
            {
                Vector2 position = new Vector2(x, y);
                Instantiate(tilePrefab, position, Quaternion.identity, transform);
            }
        }
    }
}
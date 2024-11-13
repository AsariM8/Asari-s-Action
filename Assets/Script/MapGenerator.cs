using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] GameObject player;
    public GameObject tilePrefab; // 配置する地形タイル
    public int mapWidth = 100; // マップの横幅
    public int mapHeight = 10; // マップの最大高さ
    public float noiseScale = 0.1f; // ノイズのスケール
    private Vector3 playerPos;
    private int preY;
    private int mapEnd;
    public int[] options = new int[5];

    void Start()
    {
        preY = GenerateMap(0, 0);
        mapEnd = mapWidth;
        // Debug.Log("mapend: " + mapEnd);
    }

    void Update()
    {
        playerPos = player.transform.position;
        // map端まで残り50マスを切ったら
        if (mapEnd - playerPos.x < 50)
        {
            preY = GenerateMap(mapEnd, preY);
            mapEnd += mapWidth;
        }
    }

    int GenerateMap(int startX, int preY)
    {
        // Debug.Log("Generated Map");
        int index;
        int diff;
        int Ymax = 0;
        for (int x = startX; x < startX + mapWidth; x++)
        {
            // Debug.Log("map position:" + x);
            // Perlinノイズで高さを決定
            // float height = Mathf.PerlinNoise(x * noiseScale, 0) * mapHeight;
            // int yMax = Mathf.FloorToInt(height);

            // 2回に1度，高さを変える
            if (x % 2 == 0)
            {
                index = Random.Range(0, options.Length);    // 高さ選択用インデックス取得
                diff = options[index];  // 高さ決定
                Ymax = preY + diff > -5 ? preY + diff : -5; // 最低高度を下回らないように
                preY = Ymax;
            }

            // 0からyMaxまでタイルを配置
            for (int y = -5; y <= Ymax; y++)
            {
                Vector2 position = new Vector2(x, y);
                Instantiate(tilePrefab, position, Quaternion.identity, transform);
            }
        }
        return preY;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : BaseMonoBehaviour
{
    static public int Size = 32;
    GameObject[][] Chunk;


    protected override void Awake()
    {
        base.Awake();

        Chunk = new GameObject[Size][];
        GenerateChunk();
    }

    void GenerateChunk()
    {
        for (int i = 0; i < Size; i++)
        {
            Chunk[i] = new GameObject[Size];
            for (int j = 0; j < Size; j++)
            {
                var go = gameObject.CreateChildren();
                go.AddComponent<SoilBase>();
                go.transform.localPosition = new Vector2(i, j);
                go.name = $"X {transform.position.x + i} Y {transform.position.y + j}";
                Chunk[i][j] = go;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

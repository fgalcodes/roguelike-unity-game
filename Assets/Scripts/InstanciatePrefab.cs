using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InstanciatePrefab : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase tile;

    [SerializeField] private int width = 10;
    [SerializeField] private int height = 10;

    // Start is called before the first frame update
    void Start()
    {
        for (int w = 0; w < width; w++)
        {
            for (int h = 0; h < height; h++)
            {
                tilemap.SetTile(new Vector3Int(w, h, 0), tile);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

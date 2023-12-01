using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomsAndCorridors : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase tile;

    [SerializeField] private int roomWidth = 5;
    [SerializeField] private int roomHeight = 5;
    [SerializeField] private int corridorWidth = 2; // Updated: Width of the corridors
    [SerializeField] private int gap = 2;
    [SerializeField] private int rows = 3;
    [SerializeField] private int columns = 3;

    private Vector2Int currentCenter;

    // Start is called before the first frame update
    void Start()
    {
        currentCenter = new Vector2Int(0, 0); // Starting position
        CreateRoomsAndCorridors();
    }

    void CreateRoomsAndCorridors()
    {
        for (int i = 0; i < rows * columns; i++)
        {
            CreateRoom(currentCenter);
            Vector2Int nextDirection = ChooseNextDirection();
            if (!(i == (rows * columns) -1))
            {
                CreateCorridor(currentCenter, nextDirection);
                currentCenter += nextDirection * (roomWidth + gap);
                
            }
        }
    }

    void CreateRoom(Vector2Int center)
    {
        int startX = center.x - roomWidth / 2;
        int startY = center.y - roomHeight / 2;

        for (int w = 0; w < roomWidth; w++)
        {
            for (int h = 0; h < roomHeight; h++)
            {
                tilemap.SetTile(new Vector3Int(startX + w, startY + h, 0), tile);
            }
        }
    }

    Vector2Int ChooseNextDirection()
    {
        // Example: For simplicity, just alternate between right and up directions
        return (Random.value < 0.5f) ? Vector2Int.right : Vector2Int.up;
    }

    void CreateCorridor(Vector2Int start, Vector2Int direction)
    {
        int corridorLength = gap + roomWidth; // Updated: Length of the corridor

        Vector2Int perpendicular = new Vector2Int(-direction.y, direction.x); // Calculate perpendicular manually

        for (int i = 0; i < corridorWidth; i++) // Updated: Width of the corridor
        {
            for (int j = 0; j < corridorLength; j++)
            {
                Vector2Int currentPos = start + direction * (j + 1) + perpendicular * i;
                tilemap.SetTile(new Vector3Int(currentPos.x, currentPos.y, 0), tile);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

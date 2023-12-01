using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InstanciatePrefab : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase tile;

    [SerializeField] private int roomWidth = 5;
    [SerializeField] private int roomHeight = 5;
    [SerializeField] private int gap = 2;
    [SerializeField] private int rows = 3;
    [SerializeField] private int columns = 3;

    private List<Vector2Int> roomCenters = new List<Vector2Int>();
    private Dictionary<Vector2Int, int[]> roomConnections = new Dictionary<Vector2Int, int[]>();

    // Start is called before the first frame update
    void Start()
    {
        CreateRooms();
        CalculateConnections();
        CreateCorridors();
    }

    void CreateRooms()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                int startX = column * (roomWidth + gap);
                int startY = row * (roomHeight + gap);

                for (int w = 0; w < roomWidth; w++)
                {
                    for (int h = 0; h < roomHeight; h++)
                    {
                        tilemap.SetTile(new Vector3Int(startX + w, startY + h, 0), tile);
                    }
                }

                int centerX = startX + roomWidth / 2;
                int centerY = startY + roomHeight / 2;

                roomCenters.Add(new Vector2Int(centerX, centerY));
                roomConnections[new Vector2Int(centerX, centerY)] = new int[4]; // 4 connections: top, right, bottom, left
            }
        }
    }

    void CalculateConnections()
    {
        foreach (Vector2Int center in roomCenters)
        {
            int[] connections = roomConnections[center];

            foreach (Vector2Int otherCenter in roomCenters)
            {
                if (center != otherCenter)
                {
                    if (otherCenter.x == center.x) // Same vertical line
                    {
                        if (otherCenter.y < center.y) // Other room is above
                            connections[0]++; // Top connection
                        else
                            connections[2]++; // Bottom connection
                    }
                    else if (otherCenter.y == center.y) // Same horizontal line
                    {
                        if (otherCenter.x < center.x) // Other room is to the left
                            connections[3]++; // Left connection
                        else
                            connections[1]++; // Right connection
                    }
                }
            }
        }
    }

    void CreateCorridors()
    {
        foreach (var entry in roomConnections)
        {
            Vector2Int currentCenter = entry.Key;
            int[] connections = entry.Value;

            CreateCorridor(currentCenter, connections[0], Vector2Int.up); // Top
            CreateCorridor(currentCenter, connections[1], Vector2Int.right); // Right
            CreateCorridor(currentCenter, connections[2], Vector2Int.down); // Bottom
            CreateCorridor(currentCenter, connections[3], Vector2Int.left); // Left
        }
    }

    void CreateCorridor(Vector2Int start, int count, Vector2Int direction)
    {
        for (int i = 0; i < count; i++)
        {
            Vector2Int currentPos = start + direction * (i + 1);
            tilemap.SetTile(new Vector3Int(currentPos.x, currentPos.y, 0), tile);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

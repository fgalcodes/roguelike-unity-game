using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DungeonGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase floorTile;
    public int mapWidth = 10;
    public int mapHeight = 10;
    public int numberOfRooms = 5;

    private List<Vector2Int> roomCenters;

    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        InitializeMap();

        // Generate random rooms
        GenerateRooms();

        // Connect the rooms
        ConnectRooms();

        // Draw the rooms on the Tilemap
        DrawRooms();
    }

    void InitializeMap()
    {
        tilemap.ClearAllTiles();
        roomCenters = new List<Vector2Int>();
    }

    void GenerateRooms()
    {
        for (int i = 0; i < numberOfRooms; i++)
        {
            int roomWidth = Random.Range(10, 20);  // Adjust the range as needed
            int roomHeight = Random.Range(10, 30);

            int x = Random.Range(1, mapWidth - roomWidth - 1);
            int y = Random.Range(1, mapHeight - roomHeight - 1);

            Vector2Int roomCenter = new Vector2Int(x + roomWidth / 2, y + roomHeight / 2);
            roomCenters.Add(roomCenter);

            for (int w = 0; w < roomWidth; w++)
            {
                for (int h = 0; h < roomHeight; h++)
                {
                    tilemap.SetTile(new Vector3Int(x + w, y + h, 0), floorTile);
                }
            }
        }
    }

    void ConnectRooms()
    {
        for (int i = 0; i < roomCenters.Count - 1; i++)
        {
            Vector2Int fromRoom = roomCenters[i];
            Vector2Int toRoom = roomCenters[i + 1];
            
            Debug.Log(roomCenters[i]);
            Debug.Log(roomCenters[i + 1]);
            
            while (fromRoom != toRoom)
            {
                if (fromRoom.x < toRoom.x)
                {
                    fromRoom.x++;
                }
                else if (fromRoom.x > toRoom.x)
                {
                    fromRoom.x--;
                }

                if (fromRoom.y < toRoom.y)
                {
                    fromRoom.y++;
                }
                else if (fromRoom.y > toRoom.y)
                {
                    fromRoom.y--;
                }

                tilemap.SetTile(new Vector3Int(fromRoom.x, fromRoom.y, 0), floorTile);   
                tilemap.SetTile(new Vector3Int(fromRoom.x + 1, fromRoom.y, 0), floorTile);
                tilemap.SetTile(new Vector3Int(fromRoom.x, fromRoom.y + 1, 0), floorTile);
                tilemap.SetTile(new Vector3Int(fromRoom.x + 1, fromRoom.y + 1, 0), floorTile);



                
            }
        }
    }

    void DrawRooms()
    {
        tilemap.RefreshAllTiles();
    }
}

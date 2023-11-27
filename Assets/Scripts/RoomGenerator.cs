using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public GameObject roomPrefab; // Prefab of the room to be instantiated
    public int numberOfRooms = 10; // Number of rooms to generate
    public Vector2 roomSize = new Vector2(10, 10); // Size of each room
    public float roomSpacing = 15f; // Spacing between rooms

    private List<Vector2> takenPositions = new List<Vector2>(); // List to store taken positions

    void Start()
    {
        GenerateDungeon();
    }

    void GenerateDungeon()
    {
        Vector2 startPosition = Vector2.zero; // Starting position

        for (int i = 0; i < numberOfRooms; i++)
        {
            Vector2 newPosition = GetValidPosition();

            // Instantiate room at the valid position
            GameObject newRoom = Instantiate(roomPrefab);
            // Set the room's size
            //newRoom.transform.localScale = new Vector3(roomSize.x, roomSize.y, 1);

            // Add the position to the list of taken positions
            takenPositions.Add(newPosition);
        }
    }

    Vector2 GetValidPosition()
    {
        Vector2 newPos = Vector2.zero;
        int attempts = 0;
        do
        {
            newPos = new Vector2(Random.Range(-numberOfRooms, numberOfRooms), Random.Range(-numberOfRooms, numberOfRooms));
            attempts++;
        } while (takenPositions.Contains(newPos) && attempts < 100); // Check if position is already taken

        return newPos;
    }
}

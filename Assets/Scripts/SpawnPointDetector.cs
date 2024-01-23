using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnPointDetector : MonoBehaviour
{

    private GameObject[] points;
    private GameObject[] rooms;

    public GameObject exit;



    private void Start()
    {
        points = (GameObject.FindGameObjectsWithTag("SpawnPoint"));
    }

    void Update()
    {
        if (points.Length != 0)
        {
            points = (GameObject.FindGameObjectsWithTag("SpawnPoint"));
        }
        else
        {
            rooms = GameObject.FindGameObjectsWithTag("Room");
            Instantiate(exit, rooms[Random.Range(0, rooms.Length - 1)].transform);
            for (int i = 0; i < points.Length; i++)
            {
                Destroy(points[i]);
            }
            Destroy(gameObject);
        }

    }
}

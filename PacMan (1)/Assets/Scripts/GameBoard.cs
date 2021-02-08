using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    private static int boardWidth = 1000;
    private static int boardHeight = 1000;

    public GameObject[,] board = new GameObject[boardWidth, boardHeight];
    // Start is called before the first frame update
    void Start()
    {
        Object[] objects = GameObject.FindObjectsOfType (typeof(GameObject));

        foreach (GameObject o in objects)
        {
            Vector2 pos = o.transform.position;

            if (o.name != "mainCharacter" && o.name != "Nodes" && o.name != "maze" && o.name != "NonNodes" && o.name != "Canvas" && o.name != "EventSystem" && o.name != "scoreValue")
            {
                board [(int)pos.x, (int)pos.y] = o;
            } else
            {
                Debug.Log ("Found mainCharacter at: " + pos);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class buttonScript : MonoBehaviour
{
    public BoundsInt area;
    public Tilemap tm;
    public Tile FloorTile;
    public Tile DoorTile1;
    public Tile DoorTile2;
    public Tile DoorTile3;
    public Tile DoorTile4;
    public Tile DoorTile5;
    public Tile DoorTile6;
    public Tile buttonTile1;
    public Tile buttonTile2;

    private GameObject[] doors;
    private List<GameObject> doors1 = new List<GameObject>();
    private List<GameObject> doors2 = new List<GameObject>();
    public Vector3Int[] doors1pos;
    public Vector3Int[] doors2pos;

    public Vector3Int buttonPos;


    // Start is called before the first frame update
    void Start()
    {



        doors = GameObject.FindGameObjectsWithTag("Door");

        #region Sort Doors

        foreach (GameObject door in doors)
        {
            if (door.GetComponent<Door>().doorNo == 1)
            {
                doors1.Add(door);
            }
            else if (door.GetComponent<Door>().doorNo == 2)
            {
                doors2.Add(door);
            }
        }

        #endregion
    }

    public void interaction(int number)
    {
        StartCoroutine(buttonSequence(buttonPos));

        if (number == 1)
        {
            foreach (GameObject door in doors1)
            {
                door.SetActive(false);
            }
            foreach (GameObject door in doors2)
            {
                door.SetActive(true);
            }
            foreach (Vector3Int pos in doors1pos)
            {
                StartCoroutine(doorSequence(pos, false));
            }
            foreach (Vector3Int pos in doors2pos)
            {
                StartCoroutine(doorSequence(pos, true));
            }
        }
        else if (number == 2)
        {
            foreach (GameObject door in doors1)
            {
                door.SetActive(true);
            }
            foreach (GameObject door in doors2)
            {
                door.SetActive(false);
            }
            foreach (Vector3Int pos in doors1pos)
            {
                StartCoroutine(doorSequence(pos, true));
            }
            foreach (Vector3Int pos in doors2pos)
            {
                StartCoroutine(doorSequence(pos, false));
            }
        }

        
    }

    IEnumerator doorSequence(Vector3Int position, bool open)
    {
        if (open)
        {
            if (tm.GetTile(position) == DoorTile6)
            {
                tm.SetTile(position, DoorTile5);
                yield return new WaitForSeconds(0.2f);
                tm.SetTile(position, DoorTile4);
                yield return new WaitForSeconds(0.2f);
                tm.SetTile(position, DoorTile3);
                yield return new WaitForSeconds(0.2f);
                tm.SetTile(position, DoorTile2);
                yield return new WaitForSeconds(0.2f);
                tm.SetTile(position, DoorTile1);
            }
        }
        else if (!open)
        {
            if (tm.GetTile(position) == DoorTile1)
            {
                tm.SetTile(position, DoorTile2);
                yield return new WaitForSeconds(0.2f);
                tm.SetTile(position, DoorTile3);
                yield return new WaitForSeconds(0.2f);
                tm.SetTile(position, DoorTile4);
                yield return new WaitForSeconds(0.2f);
                tm.SetTile(position, DoorTile5);
                yield return new WaitForSeconds(0.2f);
                tm.SetTile(position, DoorTile6);
            }
        }
    }

    IEnumerator buttonSequence(Vector3Int position)
    {
        tm.SetTile(position, buttonTile1);
        yield return new WaitForSeconds(0.5f);
        tm.SetTile(position, buttonTile2);
    }

}

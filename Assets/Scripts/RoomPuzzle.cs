using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class RoomPuzzle : MonoBehaviour
{
    public Transform[] roomPositions;

    public Transform[] rooms;

    private Transform currentRoom;
    public Transform emptySpace;

    public bool isDragging = false;
    public Vector3 dragStartPos;
    public Vector3 currentRoomOffset;

    public Camera zoomedOutCamera;

    void Start()
    {
        rooms = new Transform[3];
        rooms[0] = GameObject.Find("Room1").transform;
        rooms[1] = GameObject.Find("Room2").transform;
        rooms[2] = GameObject.Find("Room3").transform;

        currentRoom = rooms[0];
        emptySpace = GameObject.Find("EmptySpace").transform;
    }

    void Update()
    {
        if (zoomedOutCamera.enabled) // Only allow puzzle to be moved when zoomedOutCamera is enabled
        {
            if (EventSystem.current.IsPointerOverGameObject()) // Check if the mouse pointer is over a UI element
            {
                return; // Ignore input if over UI
            }
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    for (int i = 0; i < rooms.Length; i++)
                    {
                        if (hit.transform == rooms[i])
                        {
                            isDragging = true;
                            dragStartPos = hit.point;
                            currentRoomOffset = rooms[i].position - dragStartPos;
                            break;
                        }
                    }
                }
            }
            else if (Input.GetMouseButton(0) && isDragging)
            {
                Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + currentRoomOffset;
                Vector3 emptySpacePosition = emptySpace.position;
                float distanceToEmptySpace = Vector3.Distance(newPosition, emptySpacePosition);

                if (distanceToEmptySpace < 40f)
                {
                    currentRoom.position = newPosition;
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;

                bool isSolved = true;
                for (int i = 0; i < rooms.Length; i++)
                {
                    float distanceToEmptySpace = Vector3.Distance(rooms[i].position, emptySpace.position);
                    if (distanceToEmptySpace < 40f)
                    {
                        Vector3 tempPosition = rooms[i].position;
                        rooms[i].position = emptySpace.position;
                        emptySpace.position = tempPosition;
                    }
                    if (rooms[i] != emptySpace && rooms[i].position != roomPositions[i].position)
                    {
                        isSolved = false;
                    }
                }

                if (isSolved)
                {
                    Debug.Log("Rooms Moving!");
                }
            }
        }
    }
}
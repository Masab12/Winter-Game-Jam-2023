using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Camera zoomedInCamera;
    public Camera zoomedOutCamera;
    public Button zoomButton;

    private Vector3 defaultPosition;
    private bool isZoomedOut = false;
    public GameObject[] allWalls;

void Start()
    {
        defaultPosition = zoomedInCamera.transform.position;
        zoomedInCamera.transform.position = new Vector3(transform.position.x, player.position.y + 2f, player.position.z + 1f);
        zoomedOutCamera.enabled = false;
    }

    void Update()
    {
        if (!isZoomedOut)
        {
            if (!isZoomedOut)
            {
                zoomedInCamera.transform.position = new Vector3(transform.position.x, player.position.y + 2f, player.position.z + 1f);
                defaultPosition = zoomedInCamera.transform.position; // Update defaultPosition
            }
            //zoomedInCamera.transform.position = new Vector3(transform.position.x, player.position.y + 2f, player.position.z + 1f);
        }
    }

    public void ToggleZoom()
    {
        
        if (isZoomedOut)
        {

            if (FindObjectOfType<RoomPuzzle>().isDragging)
            {
                return;
            }
            else
            {
                zoomedInCamera.enabled = true;
                zoomedOutCamera.enabled = false;
                zoomedInCamera.transform.position = defaultPosition;
                isZoomedOut = false;
                for (int i = 0; i < allWalls.Length; i++)
                {
                    allWalls[i].SetActive(true);
                }
            }
        }
        else
        {
            zoomedInCamera.enabled = false;
            zoomedOutCamera.enabled = true;
            isZoomedOut = true;
        //    zoomedInCamera.transform.position = new Vector3(transform.position.x, player.position.y + 2f, player.position.z + 1f);
            for (int i = 0; i < allWalls.Length; i++)
            {
                allWalls[i].SetActive(true);
            }
        }
    }
}
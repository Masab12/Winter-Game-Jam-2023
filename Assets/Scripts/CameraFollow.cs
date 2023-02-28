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
            /*if (CharacterMovement.isMoving)
            {
                zoomedInCamera.transform.position = new Vector3(transform.position.x, player.position.y + 2f, player.position.z + 1f);
            }
            else
            {
                // Update the position of the camera to follow the new position of the character
               
            }*/
            zoomedInCamera.transform.position = new Vector3(transform.position.x, player.position.y + 2f, player.position.z + 1f);
        }
    }

    public void ToggleZoom()
    {
        if (isZoomedOut)
        {
            zoomedInCamera.enabled = true;
            zoomedOutCamera.enabled = false;
            zoomedInCamera.transform.position = defaultPosition;
            isZoomedOut = false;
        }
        else
        {
            zoomedInCamera.enabled = false;
            zoomedOutCamera.enabled = true;
            isZoomedOut = true;
            zoomedInCamera.transform.position = new Vector3(transform.position.x, player.position.y + 2f, player.position.z + 1f);
        }
    }
}
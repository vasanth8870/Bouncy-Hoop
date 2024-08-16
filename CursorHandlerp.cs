using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHandlerp : MonoBehaviour
{
    public GameObject Gamestartpanel;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public GameObject Header;
    public GameObject dragtext;
    public GameObject grownimage;
    public GameObject Dragline;
    public GameObject Cursorhand;
    public GameObject Scorepanel;
    public GameObject BallObject1;

    private float lerpDuration = 1f; // Duration for the lerp to complete
    public Vector2 areaMin;           // Minimum x and y coordinates of the rectangular area
    public Vector2 areaMax;           // Maximum x and y coordinates of the rectangular area

    private Vector3 targetPosition;   // The target position to move towards
    private Vector3 startPosition;    // The starting position for the lerp
    private float lerpStartTime;      // Time when the lerp started

    /* private Vector3 touchStart;
     private Vector3 touchEnd;
     private bool isDragging = false;*/

    public PlayController playercontroller;
    public SpawnContaller spawncontroller;
    public MovementScripts movementScripts;

    void Start()
    {
        SetNewRandomPosition();
    }

    void Update()
    {
        // Calculate how far along the lerp we are (0 to 1)
        float timeSinceStart = Time.time - lerpStartTime;
        float lerpFraction = timeSinceStart / lerpDuration;

        // Perform the lerp
        transform.position = Vector3.Lerp(startPosition, targetPosition, lerpFraction);

        // Check if the lerp has completed
        if (lerpFraction >= 1.0f)
        {
            SetNewRandomPosition();
        }
        if (Input.GetAxis("Mouse X") != 0)
        {
            playercontroller.paddlemoved = true;

        }
    }

    void SetNewRandomPosition()
    {
        // Save the current position as the starting position for the lerp
        startPosition = transform.position;

        // Generate a new random position within the specified rectangular area (x and y only, z remains the same)
        float randomX = Random.Range(areaMin.x, areaMax.x);
        float randomY = Random.Range(areaMin.y, areaMax.y);
        targetPosition = new Vector3(randomX, randomY, startPosition.z);

        // Reset the lerp start time
        lerpStartTime = Time.time;
        if (playercontroller.paddlemoved == true)
        {
            Gamestartpanel.SetActive(false);
            BallObject1.SetActive(true);
            spawncontroller.OnBallSpawn();
            Debug.Log("onballspawn----");
            /*movementScripts = FindObjectOfType<MovementScripts>();
            movementScripts.SetBounciness(0.9f);*/
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
            Header.SetActive(false);
            dragtext.SetActive(false);
            grownimage.SetActive(false);
            Dragline.SetActive(false);
            Cursorhand.SetActive(false);
            Scorepanel.SetActive(true);
        }
    }
}

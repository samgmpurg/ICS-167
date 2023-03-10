using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private static Vector3 cameraPosition;
    public bool yEdgeMin, yEdgeMax;

    [Header("Camera Settings")]
    [SerializeField]
    private float cameraSpeed;
    [SerializeField] [Range(0.01f, 1f)]
    private float smoothSpeed = 0.125f;

    private Vector3 velocity = Vector3.zero;

    [SerializeField]
    private bool border;
    [SerializeField]
    private float minY, maxY;



    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        handleEdgeScrolling();
        handleBorder();
    }

    private void handleEdgeScrolling()
    {
        if (Input.mousePosition.y >= Screen.height * 0.8f)
        {
            cameraPosition.y += cameraSpeed / 20;
            yEdgeMax = true;
        }
        else
            yEdgeMax = false;
        if (Input.mousePosition.y <= Screen.height * 0.2f)
        {
            cameraPosition.y -= cameraSpeed / 20;
            yEdgeMin = true;
        }
        else
            yEdgeMin = false;

        this.transform.position = Vector3.SmoothDamp(transform.position, cameraPosition, ref velocity, smoothSpeed);
    }

    private void handleBorder()
    {
        if (border == true)
            transform.position = new Vector3(transform.position.x,
                                             Mathf.Clamp(transform.position.y, minY, maxY),
                                             transform.position.z);
    }
}

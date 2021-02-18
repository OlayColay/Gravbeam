using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private Vector2 startingPosition;
    [SerializeField] private float ySize = 10f;
    [SerializeField] private bool scrollX = false;
    [SerializeField] private bool scrollY = false;

    private CameraScript cameraScript;

    void Awake()
    {
        cameraScript = GameObject.FindGameObjectWithTag("Camera").GetComponent<CameraScript>();
    }

    void OnCollisionEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            cameraScript.NewAngle(startingPosition, ySize, scrollX, scrollY);
        }
    }
}

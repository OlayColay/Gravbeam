using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private bool scrollX = false;
    [SerializeField] private bool scrollY = false;

    private ChangeCamWindow cameraScript;
    private Vector2 startingPosition;
    private float ySize;

    void Awake()
    {
        cameraScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ChangeCamWindow>();
        startingPosition = transform.GetChild(0).transform.position;
        ySize = GetComponent<BoxCollider2D>().size.y;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            cameraScript.changeWindow(scrollX, scrollY, startingPosition, ySize);
    }
}

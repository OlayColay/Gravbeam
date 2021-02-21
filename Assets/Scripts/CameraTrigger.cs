using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private bool scrollX = false;
    [SerializeField] private bool scrollY = false;
    [SerializeField] private bool yViewSizeIsTriggerHeight = true;
    [SerializeField] private float yViewSize;

    private ChangeCamWindow cameraScript;
    private Vector2 startingPosition;
    private Vector2 minPositions;
    private Vector2 maxPositions;

    void Awake()
    {
        cameraScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ChangeCamWindow>();
        startingPosition = transform.GetChild(0).transform.position;
        if (yViewSizeIsTriggerHeight)
            yViewSize = GetComponent<BoxCollider2D>().size.y;
        minPositions = transform.GetChild(1).transform.position;
        maxPositions = transform.GetChild(2).transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log(yViewSize);
        if (other.tag == "Player")
            cameraScript.changeWindow(scrollX, scrollY, startingPosition, yViewSize, minPositions, maxPositions);
    }
}

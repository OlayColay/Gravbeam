using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CameraTrigger : MonoBehaviour
{
    // [Tooltip("Whether the camera will be allowed to scroll horizontally")]
    // [SerializeField] private bool scrollX = false;
    
    // [Tooltip("Whether the camera will be allowed to scroll vertically")]
    // [SerializeField] private bool scrollY = false;
    
    [Tooltip("Whether the height of the box collider will be the height of the camera")]
    [SerializeField] private bool yViewSizeIsTriggerHeight = true;
    
    [Tooltip("The y-size of the new camera view, if it is NOT the trigger height")]
    [SerializeField] private float yViewSize;

    private Bounds managerBox;   // The BoxCollider2D of the parent object
    private Transform player;    // The player's transform
    private ChangeCamWindow camScript;
    public GameObject boundary;  // The actual camera boundary

    void Start()
    {
        managerBox = GetComponent<BoxCollider2D>().bounds;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        camScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ChangeCamWindow>();

        boundary.GetComponent<BoxCollider2D>().enabled = true;
        boundary.GetComponent<BoxCollider2D>().offset = GetComponent<BoxCollider2D>().offset;
        boundary.GetComponent<BoxCollider2D>().size = GetComponent<BoxCollider2D>().size;

        if (yViewSizeIsTriggerHeight)
            yViewSize = GetComponent<BoxCollider2D>().size.y;
    }

    void Update()
    {
        if (managerBox.min.x < player.position.x && player.position.x < managerBox.max.x &&
          managerBox.min.y < player.position.y && player.position.y < managerBox.max.y)
        {
            boundary.SetActive(true);

            if(gameObject != Globals.curCamBound)
            {
                // Debug.Log("curCamBound changed to " + gameObject);
                camScript.changeWindow(yViewSize);
                Globals.curCamBound = gameObject;
            }
        }
        else
            boundary.SetActive(false);
    }  
}

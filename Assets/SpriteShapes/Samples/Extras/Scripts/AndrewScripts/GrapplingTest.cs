using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrapplingTest : MonoBehaviour
{
    [SerializeField] private LayerMask grappable;
    [SerializeField] private Transform grapplePoint, player;
    
    private LineRenderer lr;
    private Vector3 grappleLand;

    PlayerControls controls;

    void Awake()
    {
        controls = new PlayerControls();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //GrappleStart();
        }
        else if (Input.GetMouseButtonUp(0))
        {

        }
    }

    /*
    void GrappleStart()
    {

    }

    void GrappleEnd()
    {

    }
    *///Still studying 2D raycasting...
}

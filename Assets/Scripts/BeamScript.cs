using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamScript : MonoBehaviour
{
    PlayerControls controls;
    public float BEAM_LENGTH;
    public float BEAM_STRENGTH;
    public float BEAM_LOCATION_OFFSET;


    public GameObject Beam1;
    public GameObject Beam2;
    BeamInterface Beam1Interface;
    BeamInterface Beam2Interface;
    Rigidbody2D rb;
    Vector2 beam1;

    double timeOfBeam = 0;


    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Beam1Interface = Beam1.GetComponent<BeamInterface>();
        controls = new PlayerControls();

        controls.Gameplay.Beam1.performed += ctx => beam1 = ctx.ReadValue<Vector2>();
        controls.Gameplay.Beam1.canceled += ctx => beam1 = Vector2.zero;
    }

    private void Update()
    {
        print(beam1);
    }

    // FixedUpdate is for physics stuff
    void FixedUpdate()
    {
        // Vector2 beam1 = GetDirectionMouse();
        float distance = beam1.magnitude * BEAM_LENGTH;
        //beam1 /= distance;

        //Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Beam1Interface.length = distance;
        if (distance > 0)
        {
            Debug.DrawLine((Vector2)transform.position + beam1 * BEAM_LOCATION_OFFSET, (Vector2)transform.position + beam1 * distance, Color.cyan, 0.05f);
            //move the beamlocationn to that direction and position
            Beam1.transform.position = (Vector2)transform.position + beam1 * BEAM_LOCATION_OFFSET;
            Vector2 beam1Point = (Vector2)Beam1.transform.position + beam1;
            Beam1.transform.LookAt(beam1Point);

            RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + beam1 * BEAM_LOCATION_OFFSET, beam1, distance - BEAM_LOCATION_OFFSET);

            if (hit.collider != null && hit.collider.gameObject.tag == "Beamable")
            {
                print(hit.collider.gameObject.tag);
                Rigidbody2D rbOther = hit.rigidbody;
                float forceStrength = GetForceStrength(hit.distance, 1); //get a strength of beam based on how far away you are from target. may modify later to make circular forces easier.
                rb.AddForce(beam1 * forceStrength);
                if (rbOther)
                {
                    rbOther.AddForce(-beam1 * forceStrength);
                }


            }
            else
            {
                timeOfBeam = 0;
            }

            rb.velocity /= 1.005f;
            //rb.AddForce(beam1 * BEAM_STRENGTH);
        }
    }


    Vector3 GetDirection()
    { 
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            return Vector3.left;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            return Vector3.right;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            return Vector3.up;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            return Vector3.down;
        }
        return Vector3.zero;

    }
    Vector3 GetDirectionMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        return mousePosition - transform.position;
    }
    



    float GetForceStrength(float distance, float time)
    {
        return BEAM_STRENGTH;
    }

}

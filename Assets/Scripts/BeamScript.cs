using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamScript : MonoBehaviour
{
    float RADIUS = 2;
    float BEAM_STRENGTH = 10;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 beam1 = GetDirectionMouse();
        float distance = beam1.magnitude;
        beam1 /= distance;
        print(beam1);
        //Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Debug.DrawLine(transform.position + beam1 * RADIUS, transform.position + beam1 * distance, Color.cyan, 0.05f);

        if (distance > 0.1)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + beam1 * RADIUS, beam1, distance- RADIUS);
            if (hit.collider!=null)
            {
                Rigidbody2D rbOther = hit.rigidbody;
                
                rb.AddForce(beam1* BEAM_STRENGTH);
                rbOther.AddForce(-beam1* BEAM_STRENGTH);

            }
        }

        rb.velocity /= 1.005f;
        rb.AddForce(GetDirection()* BEAM_STRENGTH);
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
    



    float GetForceStrength(float distance)
    {
        return distance;
    }

}

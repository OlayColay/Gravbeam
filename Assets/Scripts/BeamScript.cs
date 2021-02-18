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


    Vector2 beamDir1;
    Vector2 beamDir2;
    float beamAttachedTime1;
    float beamAttachedTime2;

    Vector2 lastAttachedBeamDir1;
    Vector2 lastAttachedBeamDir2;
    Vector2 lastAttachedBeamEnd1;
    Vector2 lastAttachedBeamEnd2;
    float beamTimeFromLastAttached1;
    float beamTimeFromLastAttached2;

    Rigidbody2D rb;


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
        Beam2Interface = Beam2.GetComponent<BeamInterface>();


        controls = new PlayerControls();

        controls.Gameplay.Beam1.performed += ctx => beamDir1 = ctx.ReadValue<Vector2>();
        controls.Gameplay.Beam1.canceled += ctx => beamDir1 = Vector2.zero;

        controls.Gameplay.Beam2.performed += ctx => beamDir2 = ctx.ReadValue<Vector2>();
        controls.Gameplay.Beam2.canceled += ctx => beamDir2 = Vector2.zero;
    }

    private void Update()
    {
    }

    // FixedUpdate is for physics stuff
    void FixedUpdate()
    {        

        doStuff(Beam1, Beam1Interface, beamDir1, ref beamAttachedTime1);
        doStuff(Beam2, Beam2Interface, beamDir2, ref beamAttachedTime2);

        //beam1 /= distance;

        //Vector3 fwd = transform.TransformDirection(Vector3.forward);
        //Beam1Interface.length = distance;

    }

    void doStuff (GameObject Beam, BeamInterface beamInterface, Vector2 beamDir, ref float beamAttachedTime)
    {
        float distance = beamDir.magnitude * BEAM_LENGTH;
        

        if (distance > 0)
        {

            Vector2 beamDirFinal = Vector2.zero;

            //move the beamlocation to that direction and position
            Vector2 beamStartLoc = (Vector2)transform.position + beamDir.normalized * BEAM_LOCATION_OFFSET;
            Vector2 maxEndPoint = (Vector2)beamStartLoc + beamDir*BEAM_LENGTH;



            RaycastHit2D hit = Physics2D.Raycast(beamStartLoc, beamDir, distance);

            float forceStrength = 0;
            Rigidbody2D rbOther = null;

            if (hit.collider != null && hit.collider.gameObject.tag == "Beamable")
            {

                beamInterface.isHooked = true;


                //get a strength of beam based on how far away you are from target. may modify later to make circular forces easier.
                

                rbOther = hit.rigidbody;


                beamDirFinal = beamDir.normalized * hit.distance;

                forceStrength = GetForceStrength(beamStartLoc + beamDirFinal, rb.velocity, beamAttachedTime);



            }

            else
            {
                //raycast to find nearest attachable object

                bool anyHit = false;

                Vector2 endHitLoc = Vector2.zero;

                int NUMBER_OF_RAYS = 20;
                float TOTAL_ANGLE = 90;
                bool beamableNotFound = true;
                int i = 1;
                while (beamableNotFound && i <= NUMBER_OF_RAYS / 2)
                {



                    float minDistance = 100f;
                    for (int j = -1; j < 2; j += 2)
                    {

                        float angle = TOTAL_ANGLE / NUMBER_OF_RAYS * i * j; //do positive, then negative

                        float distanceSideBeam = distance * ((Mathf.Cos(angle / (TOTAL_ANGLE / 2))));

                        Vector2 beamDirNew = Quaternion.AngleAxis(angle, Vector3.forward) * beamDir.normalized;



                        //search for objects a small distance away from the max end point. Small distance is proportional to the max end point distance. about 1/5 of it? Must test.

                        RaycastHit2D hitNew = Physics2D.Raycast(beamStartLoc, beamDirNew, distanceSideBeam);



                        if (hitNew.collider != null && hitNew.collider.gameObject.tag == "Beamable")
                        {
                            //Debug.DrawLine(beamStartLoc, beamStartLoc + beamDirNew.normalized * hitNew.distance, Color.red, 0.025f);
                            if (hitNew.distance < minDistance)
                            {
                                minDistance = hitNew.distance;
                                endHitLoc = beamStartLoc + beamDirNew.normalized * hitNew.distance;
                                anyHit = true;
                                rbOther = hitNew.rigidbody;
                                beamableNotFound = false;
                            }

                        }
                        else
                        {
                            //Debug.DrawLine(beamStartLoc, beamStartLoc + beamDirNew * distanceSideBeam, Color.magenta, 0.025f);
                        }
                    }
                    i++;
                }

                if (anyHit)
                {
                    beamDirFinal = endHitLoc - beamStartLoc;//this is the vector representing the beam
                    forceStrength = GetForceStrength(beamStartLoc + beamDirFinal, rb.velocity, beamAttachedTime);
                }
                else
                {
                    beamDirFinal = beamDir * BEAM_LENGTH;
                }



            }

            if (forceStrength > 0)
            {
                beamInterface.isHooked = true;
                

                rb.AddForce(beamDirFinal.normalized * forceStrength);
                if (rbOther != null)
                {
                    rbOther.AddForce(-beamDirFinal.normalized * forceStrength);

                }
                beamAttachedTime += Time.deltaTime;
            }
            else
            {
                beamInterface.isHooked = false;
                beamInterface.length = 0;
                beamAttachedTime = 0;

            }


            //draw the beam
            beamInterface.length = beamDirFinal.magnitude;
            Beam.transform.position = beamStartLoc;
            Beam.transform.LookAt(beamStartLoc + beamDirFinal);
            Debug.DrawLine(beamStartLoc, beamStartLoc + beamDirFinal, Color.cyan, 0.025f);







            //if(noneHit)
            //{
            //    //raycast to find nearest attachable object

            //    bool anyHit = false;
            //    float minDistance = 100f;
            //    Vector2 endHitLoc = Vector2.zero;

            //    int NUMBER_OF_RAYS = 24;
            //    float angle = 0; //in radians!
            //    for (int i = 0; i < NUMBER_OF_RAYS; i++)
            //    {
            //        float x = Mathf.Sin(angle);
            //        float y = Mathf.Cos(angle);
            //        angle += 2 * Mathf.PI / NUMBER_OF_RAYS; //add the right ammount of radians

            //        Vector2 dir = new Vector2(x, y).normalized;
            //        Vector2 extendedEndPoint;

            //        //search for objects a small distance away from the max end point. Small distance is proportional to the max end point distance. about 1/5 of it? Must test.

            //        RaycastHit2D hitExtended = Physics2D.Raycast(maxEndPoint, dir, distance / 2);

            //        Debug.DrawLine(maxEndPoint, maxEndPoint + dir*(distance / 2), Color.red, 0.025f);

            //        if (hitExtended.collider != null && hitExtended.collider.gameObject.tag == "Beamable")
            //        {
            //            if (hitExtended.distance < minDistance)
            //            {
            //                Debug.DrawLine(maxEndPoint, maxEndPoint + dir * hitExtended.distance, Color.yellow, 0.025f);

            //                minDistance = hitExtended.distance;
            //                endHitLoc = maxEndPoint + dir * hitExtended.distance;
            //                anyHit = true;
            //                rbOther = hitExtended.rigidbody;
            //            }
            //        }

            //    }
            //    if (anyHit)
            //    {
            //        beamDirFinal =  endHitLoc-beamStartLoc;//this is the vector representing the beam
            //        forceStrength = GetForceStrength(beamDirFinal.magnitude, 1);
            //    }
            //    else
            //    {
            //        beamDirFinal = beamDir * BEAM_LENGTH;
            //    }
            //}

            //that was all for a circle of rays. useless now haha



        }//if distance>0
        else
        {
            beamAttachedTime = 0;
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
    



    float GetForceStrength(Vector2 vectorToAttachPoint, Vector2 velocity, float time)
    {

        return BEAM_STRENGTH;
    }

}

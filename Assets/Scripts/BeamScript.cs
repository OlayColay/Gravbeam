using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamScript : MonoBehaviour
{
    [HideInInspector] public PlayerControls controls;

    public float BEAM_LENGTH;
    public float BEAM_STRENGTH;
    public float BEAM_LOCATION_OFFSET;
    public bool hasTwoBeams;

    GameObject[] BeamObject = new GameObject[2];

    BeamInterface[] BeamInterface = new BeamInterface[2];

    Vector2[] beamDir = new Vector2[2];

    float[] beamAttachedTime = new float[2];

    //Vector2[] lastAttachedBeamDir = new Vector2[2];

    //Vector2[] lastAttachedBeamEnd = new Vector2[2];

    //float[] beamTimeFromLastAttached = new float[2];

    bool[] beamAttached = new bool[2];


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
        Time.timeScale = 1f;

        BeamObject[0] = transform.GetChild(0).gameObject;
        BeamObject[1] = transform.GetChild(1).gameObject;

        rb = GetComponent<Rigidbody2D>();

        BeamInterface[0] = BeamObject[0].GetComponent<BeamInterface>();
        BeamInterface[1] = BeamObject[1].GetComponent<BeamInterface>();
        BeamInterface[0].isHooked = false;
        BeamInterface[0].SetLength(0);
        BeamInterface[1].isHooked = false;
        BeamInterface[1].SetLength(0);

        bool Beam1Attached=false;
        bool Beam2Attached=false;

        controls = new PlayerControls();

        controls.Gameplay.Beam1.performed += ctx => beamDir[0] = ctx.ReadValue<Vector2>();
        controls.Gameplay.Beam1.canceled += ctx => beamDir[0] = Vector2.zero;

        controls.Gameplay.Beam2.performed += ctx => beamDir[1] = ctx.ReadValue<Vector2>();
        controls.Gameplay.Beam2.canceled += ctx => beamDir[1] = Vector2.zero;
        
        controls.Gameplay.Pause.started += ctx => Pause();
    }

    private void Update()
    {

    }

    // FixedUpdate is for physics stuff
    void FixedUpdate()
    {

        int numOfBeamsAttached = 0;
        if(beamAttached[0])
        {
            numOfBeamsAttached++;
        }
        if (beamAttached[1])
        {
            numOfBeamsAttached++;
        }

        doStuff(BeamObject[0], BeamInterface[0], beamDir[0], ref beamAttachedTime[0], ref beamAttached[0], numOfBeamsAttached) ;
        if(hasTwoBeams)
            doStuff(BeamObject[1], BeamInterface[1], beamDir[1], ref beamAttachedTime[1], ref beamAttached[1], numOfBeamsAttached) ;

        //beam1 /= distance;

        //Vector3 fwd = transform.TransformDirection(Vector3.forward);
        //Beam1Interface.length = distance;

    }

    void doStuff (GameObject Beam, BeamInterface beamInterface, Vector2 beamDir, ref float beamAttachedTime, ref bool BeamAttached, int numOfBeamsAttached)
    {
        BeamAttached = false;
        numOfBeamsAttached--;

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

                BeamAttached = true;
                numOfBeamsAttached++;
                forceStrength = GetForceStrength(beamDirFinal, rb.velocity, beamAttachedTime, numOfBeamsAttached);




            }

            else
            {
                //raycast to find nearest attachable object

                bool anyHit = false;

                Vector2 endHitLoc = Vector2.zero;

                int NUMBER_OF_RAYS = 30;
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
                    BeamAttached = true;
                    numOfBeamsAttached++;
                    forceStrength = GetForceStrength(beamDirFinal, rb.velocity, beamAttachedTime, numOfBeamsAttached);
                }
                else
                {
                    beamDirFinal = beamDir * BEAM_LENGTH;
                }



            }

            
            
            if (forceStrength > 0)
            {
                beamInterface.isHooked = true;

                if (beamDirFinal.magnitude > 0.1)
                {
                    rb.AddForce(beamDirFinal.normalized * forceStrength);

                    if (rbOther != null)
                    {

                        rbOther.AddForce(-beamDirFinal.normalized * forceStrength);


                    }
                }
                beamAttachedTime += Time.deltaTime;
            }
            else
            {
                // print("non hooked");
                beamInterface.isHooked = false;
                beamAttachedTime = 0;

            }


            //draw the beam
            // print(beamDirFinal);
            beamInterface.SetLength(beamDirFinal.magnitude);

            Beam.transform.position = beamStartLoc;
            Beam.transform.LookAt(beamStartLoc + beamDirFinal);
            Debug.DrawLine(beamStartLoc, beamStartLoc + beamDirFinal, Color.cyan, 0.025f);




        }//if distance>0
        else
        {
            beamInterface.SetLength(0);
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

    public void Pause() {
        GameObject pauseMenu = GameObject.Find("Canvas").transform.Find("PauseMenu").gameObject;
        GameObject optionsMenu = GameObject.Find("Canvas").transform.Find("OptionsMenu").gameObject;
        bool paused = pauseMenu.activeSelf || optionsMenu.activeSelf;

        if (!paused) {
            pauseMenu.SetActive(true);
            controls.Gameplay.Disable();
        }
        else {
            FindObjectOfType<ButtonListeners>().GetComponent<ButtonListeners>().OnClickResume();
        }

        optionsMenu.SetActive(false);
    }

    float GetForceStrength(Vector2 vectorToAttachPoint, Vector2 velocity, float amountOfTimeAttached, int numOfBeamsAttached)
    {

        if(numOfBeamsAttached==0)
        {
            return 0;
        }
        //The player's transform, mass and the pivot object's transform will be needed

        Vector2 dirCen, dirTan;

        float veloCen;
        float veloTan;
        float distance;

        float forceCen;
        float forceBuf;

        float speedLevel = 0.2f;

        //pivot is the transform of the hooked object?

        distance = vectorToAttachPoint.magnitude;

        //Get the distance from the player to the pivot

        dirCen = vectorToAttachPoint.normalized;

        dirTan.x = -dirCen.y;
        dirTan.y = dirCen.x;
        //Get unit vector for radial and tangential directions

        veloTan = Vector2.Dot(velocity, dirTan);
        veloCen = Vector2.Dot(velocity, dirCen);
        //Get the player's radial and tangential velocities

        forceCen = 0.95f * (rb.mass * veloTan * veloTan) / (distance);
        //Original centripetal force
        //Added a calibration factor of 0.95 (it just works .-.)

        if (veloTan > 1000f)
            speedLevel = 0.1f;
        //A stronger modification force is needed for a faster moving player 

        forceBuf = -(rb.mass * veloCen) / speedLevel;
        forceCen += forceBuf;
        //Calculate the modification force that reduces the player's radial velocity and 'push' the player onto perfect orbit, add it to the centripetal force

        float angle = Vector2.Angle(velocity, dirCen);


        //return BEAM_STRENGTH / 2 + BEAM_STRENGTH / distance / 2;

        if(forceCen<0)
        {
            forceCen = 0;
        }
        if (forceCen > (2*BEAM_STRENGTH / 3))
        {
            forceCen = (2*BEAM_STRENGTH / 3);
        }

        forceCen /= numOfBeamsAttached;

        float returnForce = ((forceCen + 2 * BEAM_STRENGTH) / 3);




        return returnForce;



        //forceCen *= Mathf.Sin(angle);

        //return forceCen;



        //return modified centripetal force



        /////////////////////////to do??
        //increase force a bit with velocity. will feel better when making turns at fast speed.
        //insert "cheating" aka centripital force helping hand

        //ramp up the force in the first 0.5 seconds (or so) of the beam. Make it feel like attaching a grapple hook, thenn tugginng onn it to go real fast.

        //return BEAM_STRENGTH;
    }

}

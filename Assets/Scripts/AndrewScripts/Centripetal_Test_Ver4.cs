using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centripetal_Test_Ver4 : MonoBehaviour
{
    //player components / constant attributes
    private Rigidbody2D rb;
    private float mass;

    //initial push parameters
    [SerializeField] private float iniMag;
    private Vector2 iniDir = new Vector2(1f, 1f).normalized;

    //position helpers
    [SerializeField] private Transform player;
    private Transform pivot;

    private bool captured = false;

    /*
    //buffer helpers   
    private bool buffered = false;
    private float bufferTimer;
    private const float BTIME = 0.3f;

    private float forceBuf;
    */

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mass = rb.mass;

        //bufferTimer = BTIME;
    }

    void Start()
    {
        rb.AddForce(iniDir * iniMag, ForceMode2D.Force);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            captured = false;
        }
        //timer for buffer zone
        /*
        if (captured && !buffered)
        {
            bufferTimer -= Time.deltaTime;
            if (bufferTimer <= 0)
            {
                buffered = true;
                bufferTimer = BTIME;
            }
        }
        */
    }

    void FixedUpdate()
    {
        if (captured)   //Equivalent to that the player pivots a beam on an object
        {
            //The player's transform, mass and the pivot object's transform will be needed
            
            Vector2 dirCen, dirTan;
            Vector2 veloPlayer;
            float veloCen;
            float veloTan;
            float distance;

            float forceCen;
            float forceBuf;

            float speedLevel = 0.2f;

            distance = Vector2.Distance(pivot.transform.position, player.transform.position);
            //Get the distance from the player to the pivot

            dirCen = (pivot.transform.position - player.transform.position).normalized;
            dirTan.x = -dirCen.y;
            dirTan.y = dirCen.x;
            //Get unit vector for radial and tangential directions

            veloPlayer = rb.velocity;
            veloTan = Vector2.Dot(veloPlayer, dirTan);
            veloCen = Vector2.Dot(veloPlayer, dirCen);
            //Get the player's radial and tangential velocities

            forceCen = 0.95f * (mass * veloTan * veloTan) / (distance);
            //Original centripetal force
            //Added a calibration factor of 0.95 (it just works .-.)

            if (veloTan > 1000f)
                speedLevel = 0.1f;
            //A stronger modification force is needed for a faster moving player 

            forceBuf = -(mass * veloCen)/speedLevel;
            forceCen += forceBuf;
            //Calculate the modification force that reduces the player's radial velocity and 'push' the player onto perfect orbit, add it to the centripetal force

            rb.AddForce(dirCen * forceCen);
            //Apply the modified centripetal force
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        Vector2 iniDirCen;
        float iniVeloCen;
        */

        //the player is captured upon entering the trigger zone
        captured = true;
        //buffered = false;
        pivot = collision.transform;

        /*
        //initial parameter of centripetal motion before buffering
        iniDirCen = (pivot.transform.position - player.transform.position).normalized;
        iniVeloCen = Mathf.Abs(Vector2.Dot(rb.velocity, iniDirCen));

        forceBuf = -(mass * iniVeloCen) / (BTIME);
        */
    }
}

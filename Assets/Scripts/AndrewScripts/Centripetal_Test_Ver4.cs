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
        if (captured)
        {
            Vector2 dirCen, dirTan;
            Vector2 veloPlayer;
            float veloCen;
            float veloTan;
            float distance;

            float forceCen;
            float forceBuf;

            float speedLevel = 0.2f;

            distance = Vector2.Distance(pivot.transform.position, player.transform.position);

            dirCen = (pivot.transform.position - player.transform.position).normalized;
            dirTan.x = -dirCen.y;
            dirTan.y = dirCen.x;

            veloPlayer = rb.velocity;
            veloTan = Vector2.Dot(veloPlayer, dirTan);
            veloCen = Vector2.Dot(veloPlayer, dirCen);

            forceCen = 0.95f * (mass * veloTan * veloTan) / (distance);
            //Added a calibration factor of 0.95
            //If above 0.95, the motion will curve inward
            //If below 0.95, the motion will curve outward

            if (veloTan > 1000f)
                speedLevel = 0.1f;

            forceBuf = -(mass * veloCen)/speedLevel;
            forceCen += forceBuf;
            rb.AddForce(dirCen * forceCen);
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

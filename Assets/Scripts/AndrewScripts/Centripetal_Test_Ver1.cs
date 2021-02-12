using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centripetal_Test_Ver1 : MonoBehaviour
{
    //player components / constant attributes
    private Rigidbody2D rb;
    private float mass;

    //initial push parameters
    private Vector2 iniDir = new Vector2(1f, 1f).normalized;
    private float iniMag = 100f;

    //position helpers
    [SerializeField] private Transform player;
    private Transform pivot;

    //buffer helpers
    private bool captured = false;
    private bool buffered = false;
    private float bufferTimer;
    private const float BTIME = 0.3f;
    
    //player relative/dynamic attributes
    Vector2 dirCen, dirTan;
    Vector2 veloPlayer;
    float veloCen;
    float veloTan;
    float distance;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mass = rb.mass;

        bufferTimer = BTIME;
    }

    void Start()
    {
        rb.AddForce(iniDir * iniMag, ForceMode2D.Force);
    }

    // Update is called once per frame
    void Update()
    {
        //timer for buffer zone
        if (captured && !buffered)
        {
            bufferTimer -= Time.deltaTime;
            if (bufferTimer <= 0)
            {
                buffered = true;
                bufferTimer = BTIME;
            }
        }
    }

    void FixedUpdate()
    {
        if (captured)
        {
            float forceCen;

            //two stages: the buffering stage and post-buffering stage
            if(!buffered)
            {   //buffering stage: use the initial parameter passed by the trigger to modify the velocity during buffer time zone
                float forceBuf;

                forceCen = (mass * veloTan * veloTan) / (distance);
                forceBuf = -(mass * veloCen) / (BTIME); //Adding a buffer force to cancel the centripetal direction's velocity
                forceCen += forceBuf;
                rb.AddForce(dirCen * forceCen);
            }
            else
            {   //post-buffering stage: after buffering, the motion should approach a perfect circle, continue centripetal motion as normal
                distance = Vector2.Distance(pivot.transform.position, player.transform.position);

                dirCen = (pivot.transform.position - player.transform.position).normalized;
                dirTan.x = -dirCen.y;
                dirTan.y = dirCen.x;

                veloPlayer = rb.velocity;
                veloTan = Mathf.Abs(Vector2.Dot(veloPlayer, dirTan));
                veloCen = Mathf.Abs(Vector2.Dot(veloPlayer, dirCen));

                forceCen = (mass * veloTan * veloTan) / (distance);
                rb.AddForce(dirCen * forceCen);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //the player is captured upon entering the trigger zone
        captured = true;
        //buffered = false;
        pivot = collision.transform;

        //initial parameter of centripetal motion before buffering

        distance = Vector2.Distance(pivot.transform.position, player.transform.position);

        dirCen = (pivot.transform.position - player.transform.position).normalized;
        dirTan.x = -dirCen.y;
        dirTan.y = dirCen.x;

        veloPlayer = rb.velocity;
        veloTan = Mathf.Abs(Vector2.Dot(veloPlayer, dirTan));
        veloCen = Mathf.Abs(Vector2.Dot(veloPlayer, dirCen));
    }
}

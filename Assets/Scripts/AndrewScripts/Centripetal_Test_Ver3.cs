using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centripetal_Test_Ver3 : MonoBehaviour
{
    //player components / constant attributes
    private Rigidbody2D rb;
    private ConstantForce2D cf;
    private float mass;

    //initial push parameters
    [SerializeField] private float iniMag;
    private Vector2 iniDir = new Vector2(1f, 1f).normalized;

    //position helpers
    [SerializeField] private Transform player;
    private Transform pivot;

    //buffer helpers
    private bool captured = false;
    private bool buffered = false;
    private float bufferTimer;
    private const float BTIME = 0.20f;

    //private float forceBuf;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cf = GetComponent<ConstantForce2D>();
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
            Vector2 dirCen, dirTan;
            Vector2 veloPlayer;
            //float veloCen;
            float veloTan;
            float distance;

            float forceCen;

            distance = Vector2.Distance(pivot.transform.position, player.transform.position);

            dirCen = (pivot.transform.position - player.transform.position).normalized;
            dirTan.x = -dirCen.y;
            dirTan.y = dirCen.x;

            veloPlayer = rb.velocity;
            veloTan = Mathf.Abs(Vector2.Dot(veloPlayer, dirTan));
            //veloCen = Mathf.Abs(Vector2.Dot(veloPlayer, dirCen));

            forceCen = (mass * veloTan * veloTan) / (distance);
            if (buffered)
            {
                //forceCen += forceBuf;
                cf.force = Vector2.zero;
            }
            rb.AddForce(dirCen * forceCen);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 iniDirCen;
        float iniVeloCen;
        float forceBuf;

        //the player is captured upon entering the trigger zone
        captured = true;
        //buffered = false;
        pivot = collision.transform;

        //initial parameter of centripetal motion before buffering
        iniDirCen = (pivot.transform.position - player.transform.position).normalized;
        iniVeloCen = Mathf.Abs(Vector2.Dot(rb.velocity, iniDirCen));

        forceBuf = -(mass * iniVeloCen) / (BTIME);
        cf.force = forceBuf * iniDirCen;
    }
}

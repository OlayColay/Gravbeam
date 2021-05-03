using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashArrow : MonoBehaviour
{
    [SerializeField] private float velocity = 1.0f; // Velocity to give player while the arrow is active
    [SerializeField] private float length = 1.0f; // How long an arrow is active without another interupting
    [SerializeField] private bool setPositionToCenter = false; // If the player is moved to the arrow's center on first frame

    private Rigidbody2D other;
    private float timeLeft;
    private Vector2 velocityVec;

    void Start()
    {
        velocityVec = transform.right * velocity;
    }

    void OnTriggerEnter2D(Collider2D o)
    {
        other = o.GetComponent<Rigidbody2D>();

        if(o.tag == "Player")
        {
            if (setPositionToCenter)
            {
                other.position = transform.position;
            }

            Globals.curDashArrowVel = velocityVec;
            timeLeft = length;

            GetComponent<AudioSource>().Play(0);

            if (o.GetComponent<PlatformerCharacter2D>() != null)
            {
                o.GetComponent<PlatformerCharacter2D>().ResetWallJumpAbility();
            }
        }
    }

    private void Update()
    {
        if (timeLeft > 0)
        {
            // Debug.Log(Globals.curDashArrowVel);
            other.velocity = Globals.curDashArrowVel;
            timeLeft -= Time.deltaTime;
            Globals.canControl = (timeLeft <= 0);
        }
    }
}

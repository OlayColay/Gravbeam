using System.Collections.Generic;
using UnityEngine;
using PathCreation;

// Moves along a path at constant speed.
// Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
public class Minecart : MonoBehaviour
{
    public PathCreator pathCreator;
    public EndOfPathInstruction endOfPathInstruction;
    public float speed = 5;
    public bool riding = false;

    private float distanceTravelled;
    private bool disableMounting = false;
    private bool permanentlyDisableMounting = false;
    private Vector3 lastPoint;

    void Start() 
    {
        if (pathCreator != null)
        {
            // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
            pathCreator.pathUpdated += OnPathChanged;
        }
    }

    void Update()
    {
        if (pathCreator != null && !permanentlyDisableMounting && riding)
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            transform.RotateAround(transform.position, transform.up, -90f);

            if (lastPoint == transform.position)
            {
                if (transform.childCount > 1) 
                {
                    transform.GetChild(1).GetComponent<PlatformerCharacter2D>().Jump();
                }
                permanentlyDisableMounting = true;
            }
            else
            {
                lastPoint = transform.position;
            }
        }
    }

    // If the path changes during the game, update the distance travelled so that the follower's position on the new path
    // is as close as possible to its position on the old path
    void OnPathChanged() 
    {
        distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player" && !disableMounting && !permanentlyDisableMounting)
        {
            riding = true;
            disableMounting = true;
            other.transform.SetParent(transform);
            other.transform.localPosition = Vector2.zero;
            other.transform.localEulerAngles = new Vector3(0f, other.transform.localEulerAngles.y, 0f);
            other.attachedRigidbody.bodyType = RigidbodyType2D.Kinematic;
            other.attachedRigidbody.velocity = Vector2.zero;
            other.GetComponent<PlatformerCharacter2D>().isRiding = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.parent != transform)
        {
            OnTriggerEnter2D(other);
        }
    }

    public IEnumerator<WaitForSeconds> Dismount()
    {
        yield return new WaitForSeconds(0.5f);

        disableMounting = false;
    }
}
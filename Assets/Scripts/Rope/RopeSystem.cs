using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class RopeSystem : MonoBehaviour
{
    public LineRenderer ropeRenderer;
    public LayerMask ropeLayerMask;
    public float climbSpeed = 3f;
    public GameObject ropeHingeAnchor;
    public Transform ropeRendererStart;
    public DistanceJoint2D ropeJoint;
    public Transform crosshair;
    public SpriteRenderer crosshairSprite;
    public PlatformerCharacter2D playerMovement;
    private bool ropeAttached;
    private Vector2 playerPosition;
    public List<Vector2> ropePositions = new List<Vector2>();
    private float ropeMaxCastDistance = 20f;
    private Rigidbody2D ropeHingeAnchorRb;
    private bool distanceSet;
    private bool isColliding;
    private Dictionary<Vector2, int> wrapPointsLookup = new Dictionary<Vector2, int>();
    private SpriteRenderer ropeHingeAnchorSprite;

    void Awake()
    {
        ropeJoint.enabled = false;
        playerPosition = transform.position;
        ropeHingeAnchorRb = ropeHingeAnchor.GetComponent<Rigidbody2D>();
        ropeHingeAnchorSprite = ropeHingeAnchor.GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Figures out the closest Polygon collider vertex to a specified Raycast2D hit point in order to assist in 'rope wrapping'
    /// </summary>
    /// <param name="hit">The raycast2d hit</param>
    /// <param name="polyCollider">the reference polygon collider 2D</param>
    /// <returns></returns>
    private Vector2 GetClosestColliderPointFromRaycastHit(RaycastHit2D hit, PolygonCollider2D polyCollider)
    {
        // Transform polygoncolliderpoints to world space (default is local)
        var distanceDictionary = polyCollider.points.ToDictionary<Vector2, float, Vector2>(
            position => Vector2.Distance(hit.point, polyCollider.transform.TransformPoint(position)),
            position => polyCollider.transform.TransformPoint(position));

        var orderedDictionary = distanceDictionary.OrderBy(e => e.Key);
        return orderedDictionary.Any() ? orderedDictionary.First().Value : Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        float aimAngle = 0f;
        Vector2 aimDirection = Vector2.zero;

        if (Gamepad.current == null)
        {
            var worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
            var facingDirection = worldMousePosition - transform.position;
            aimAngle = Mathf.Atan2(facingDirection.y, facingDirection.x);
            if (aimAngle < 0f)
            {
                aimAngle = Mathf.PI * 2 + aimAngle;
            }

            aimDirection = Quaternion.Euler(0, 0, aimAngle * Mathf.Rad2Deg) * Vector2.right;
        }
        else if (Gamepad.current.rightStick.ReadValue() != Vector2.zero)
        {
            aimDirection = Gamepad.current.rightStick.ReadValue();
            aimAngle = Vector2.Angle(Vector2.right, aimDirection);
        }

        playerPosition = transform.Find("WallCheck").position;

        if (!ropeAttached)
        {
            SetCrosshairPosition(aimAngle);
        }
        else
        {
            playerMovement.ropeHook = ropePositions.Last();
            crosshairSprite.enabled = false;

            // If the player hits the ground, wall, or ceiling, detach the rope
            if (playerMovement.isGrounded || playerMovement.isWalled)
            {
                ResetRope();
            }

            // Wrap rope around points of colliders if there are raycast collisions between player position and their closest current wrap around collider / angle point.
            if (ropePositions.Count > 0)
            {
                var lastRopePoint = ropePositions.Last();
                var playerToCurrentNextHit = Physics2D.Raycast(playerPosition, (lastRopePoint - playerPosition).normalized, Vector2.Distance(playerPosition, lastRopePoint) - 0.1f, ropeLayerMask);
                if (playerToCurrentNextHit)
                {
                    ResetRope();
                    //    var colliderWithVertices = playerToCurrentNextHit.collider as PolygonCollider2D;
                    //    if (colliderWithVertices != null)
                    //    {
                    //        var closestPointToHit = GetClosestColliderPointFromRaycastHit(playerToCurrentNextHit, colliderWithVertices);
                    //        if (wrapPointsLookup.ContainsKey(closestPointToHit))
                    //        {
                    //            // Reset the rope if it wraps around an 'already wrapped' position.
                    //            ResetRope();
                    //            return;
                    //        }

                    //        ropePositions.Add(closestPointToHit);
                    //        wrapPointsLookup.Add(closestPointToHit, 0);
                    //        distanceSet = false;
                    // }
                }
            }
        }

        UpdateRopePositions();
        HandleRopeLength();
        HandleInput(aimDirection);
        HandleRopeUnwrap();
    }

    /// <summary>
    /// Handles input within the RopeSystem component
    /// </summary>
    /// <param name="aimDirection">The current direction for aiming based on mouse position</param>
    private void HandleInput(Vector2 aimDirection)
    {
        if (Input.GetMouseButton(0) || (Gamepad.current != null && Gamepad.current.rightStick.IsPressed()))
        {
            if (ropeAttached) return;
            ropeRenderer.enabled = true;

            var hit = Physics2D.Raycast(playerPosition, aimDirection, ropeMaxCastDistance, ropeLayerMask);
            if (hit.collider != null)
            {
                playerMovement.isSwinging = true;
                ropeAttached = true;
                if (!ropePositions.Contains(hit.point))
                {
                    // Jump slightly to distance the player a little from the ground after grappling to something.
                    if (playerMovement.isGrounded)
                    {
                        playerMovement.Jump();
                    }
                    ropePositions.Add(hit.point);
                    wrapPointsLookup.Add(hit.point, 0);
                    ropeJoint.distance = Vector2.Distance(playerPosition, hit.point);
                    ropeJoint.enabled = true;
                    ropeHingeAnchorSprite.enabled = true;
                }
            }
            else
            {
                ropeRenderer.enabled = false;
                ropeAttached = false;
                ropeJoint.enabled = false;
            }
        }
        else if (ropeAttached && (Input.GetMouseButton(1) || playerMovement.controls.Gravity.Jump.triggered))
        {
            ResetRope();
        }
    }

    /// <summary>
    /// Resets the rope in terms of gameplay, visual, and supporting variable values.
    /// </summary>
    private void ResetRope()
    {
        ropeJoint.enabled = false;
        ropeAttached = false;
        playerMovement.isSwinging = false;
        ropeRenderer.positionCount = 2;
        ropeRenderer.SetPosition(0, ropeRendererStart.position);
        ropeRenderer.SetPosition(1, ropeRendererStart.position);
        ropePositions.Clear();
        wrapPointsLookup.Clear();
        ropeHingeAnchorSprite.enabled = false;
    }

    /// <summary>
    /// Move the aiming crosshair based on aim angle
    /// </summary>
    /// <param name="aimAngle">The mouse aiming angle</param>
    private void SetCrosshairPosition(float aimAngle)
    {
        if (!crosshairSprite.enabled)
        {
            crosshairSprite.enabled = true;
        }

        var x = transform.position.x + 1f * Mathf.Cos(aimAngle);
        var y = transform.position.y + 1f * Mathf.Sin(aimAngle);

        var crossHairPosition = new Vector3(x, y, 0);
        crosshair.transform.position = crossHairPosition;
    }

    /// <summary>
    /// Retracts or extends the 'rope'
    /// </summary>
    private void HandleRopeLength()
    {
        if (((Gamepad.current != null && Gamepad.current.leftStick.y.ReadValue() > 0.5f) || Input.GetAxis("Vertical") > 0.5f) && ropeAttached)
        {
            ropeJoint.distance -= Time.deltaTime * climbSpeed;
        }
        else if (((Gamepad.current != null && Gamepad.current.leftStick.y.ReadValue() < -0.5f) || Input.GetAxis("Vertical") < -0.5f) && ropeAttached)
        {
            ropeJoint.distance += Time.deltaTime * climbSpeed;
        }
    }

    /// <summary>
    /// Handles updating of the rope hinge and anchor points based on objects the rope can wrap around. These must be PolygonCollider2D physics objects.
    /// </summary>
    private void UpdateRopePositions()
    {
        if (ropeAttached)
        {
            ropeRenderer.positionCount = ropePositions.Count + 1;

            for (var i = ropeRenderer.positionCount - 1; i >= 0; i--)
            {
                if (i != ropeRenderer.positionCount - 1) // if not the Last point of line renderer
                {
                    ropeRenderer.SetPosition(i, ropePositions[i]);

                    // Set the rope anchor to the 2nd to last rope position (where the current hinge/anchor should be) or if only 1 rope position then set that one to anchor point
                    if (i == ropePositions.Count - 1 || ropePositions.Count == 1)
                    {
                        if (ropePositions.Count == 1)
                        {
                            var ropePosition = ropePositions[ropePositions.Count - 1];
                            ropeHingeAnchorRb.transform.position = ropePosition;
                            if (!distanceSet)
                            {
                                ropeJoint.distance = Vector2.Distance(transform.position, ropePosition);
                                distanceSet = true;
                            }
                        }
                        else
                        {
                            var ropePosition = ropePositions[ropePositions.Count - 1];
                            ropeHingeAnchorRb.transform.position = ropePosition;
                            if (!distanceSet)
                            {
                                ropeJoint.distance = Vector2.Distance(transform.position, ropePosition);
                                distanceSet = true;
                            }
                        }
                    }
                    else if (i - 1 == ropePositions.IndexOf(ropePositions.Last()))
                    {
                        // if the line renderer position we're on is meant for the current anchor/hinge point...
                        var ropePosition = ropePositions.Last();
                        ropeHingeAnchorRb.transform.position = ropePosition;
                        if (!distanceSet)
                        {
                            ropeJoint.distance = Vector2.Distance(transform.position, ropePosition);
                            distanceSet = true;
                        }
                    }
                }
                else
                {
                    // Player position
                    ropeRenderer.SetPosition(i, ropeRendererStart.position);
                }
            }
        }
    }

    private void HandleRopeUnwrap()
    {
        if (ropePositions.Count <= 1)
        {
            return;
        }

        // Hinge = next point up from the player position
        // Anchor = next point up from the Hinge
        // Hinge Angle = Angle between anchor and hinge
        // Player Angle = Angle between anchor and player

        // 1
        var anchorIndex = ropePositions.Count - 2;
        // 2
        var hingeIndex = ropePositions.Count - 1;
        // 3
        var anchorPosition = ropePositions[anchorIndex];
        // 4
        var hingePosition = ropePositions[hingeIndex];
        // 5
        var hingeDir = hingePosition - anchorPosition;
        // 6
        var hingeAngle = Vector2.Angle(anchorPosition, hingeDir);
        // 7
        var playerDir = playerPosition - anchorPosition;
        // 8
        var playerAngle = Vector2.Angle(anchorPosition, playerDir);

        if (!wrapPointsLookup.ContainsKey(hingePosition))
        {
            Debug.LogError("We were not tracking hingePosition (" + hingePosition + ") in the look up dictionary.");
            return;
        }

        if (playerAngle < hingeAngle)
        {
            // 1
            if (wrapPointsLookup[hingePosition] == 1)
            {
                UnwrapRopePosition(anchorIndex, hingeIndex);
                return;
            }

            // 2
            wrapPointsLookup[hingePosition] = -1;
        }
        else
        {
            // 3
            if (wrapPointsLookup[hingePosition] == -1)
            {
                UnwrapRopePosition(anchorIndex, hingeIndex);
                return;
            }

            // 4
            wrapPointsLookup[hingePosition] = 1;
        }
    }

    private void UnwrapRopePosition(int anchorIndex, int hingeIndex)
    {
        // 1
        var newAnchorPosition = ropePositions[anchorIndex];
        wrapPointsLookup.Remove(ropePositions[hingeIndex]);
        ropePositions.RemoveAt(hingeIndex);

        // 2
        ropeHingeAnchorRb.transform.position = newAnchorPosition;
        distanceSet = false;

        // Set new rope distance joint distance for anchor position if not yet set.
        if (distanceSet)
        {
            return;
        }
        ropeJoint.distance = Vector2.Distance(transform.position, newAnchorPosition);
        distanceSet = true;
    }

    void OnTriggerStay2D(Collider2D colliderStay)
    {
        isColliding = true;
    }

    private void OnTriggerExit2D(Collider2D colliderOnExit)
    {
        isColliding = false;
    }
}

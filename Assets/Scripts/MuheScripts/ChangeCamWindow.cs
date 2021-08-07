using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used to change the camera's "window." Probably doesn't work yet
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
public class ChangeCamWindow : MonoBehaviour {

    // Transition parameters
    [Tooltip("The total time taken to change windows")]
    public float transitionTime = 1f;
    [Tooltip("Curve the motion of the camera between windows")]
    public AnimationCurve transitionSpeedVariation = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

    // bool followAlongX = true;
    // bool followAlongY = true;

    // Camera player tracking stuff
    [Tooltip("Amount of damping of the player tracking routine")]
    public float damping = 1;
    [Tooltip("The amount by which camera leads player during movement")]
    public float lookAheadFactor = 3;
    [Tooltip("Speed at which the camera returns back when player stops")]
    public float lookAheadReturnSpeed = 0.5f;
    [Tooltip("Minimum speed above which camera starts to lead player")]
    public float lookAheadMoveThreshold = 0.1f;

    private float m_OffsetZ;
    private Vector3 m_LastTargetPosition;
    private Vector3 m_CurrentVelocity;
    private Vector3 m_LookAheadPos;
    private BoxCollider2D cameraBox;
    private Bounds curBound;

    // Window details
    Vector2 windowCenterPos;
    float windowInitialSizeY;
    float windowFinalSizeY;

    // Relevant only for player following
    Vector2 windowMinConstraint;
    Vector2 windowMaxConstraint;

    // transforms
    Transform cameraTransform;
    Transform playerTransform;

    Camera cam;

    bool moveDone = true;
    //UnityStandardAssets._2D.Camera2DFollow playerFollow;

    IEnumerator currentCoroutine;

    // Start is called before the first frame update
    void Start() {
        cameraTransform = transform;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        cameraBox = GetComponent<BoxCollider2D>();
        cam = GetComponent<Camera>();
        
        // Standard assets camera tracking code
        m_LastTargetPosition = playerTransform.position;
        m_OffsetZ = (transform.position - playerTransform.position).z;
        transform.SetParent(null);
    }

    // Update is called once per frame
    void Update() {
        // TODO Work in progress

        if (moveDone && GameObject.FindGameObjectWithTag("CamBound"))
        {
            curBound = GameObject.FindGameObjectWithTag("CamBound").GetComponent<BoxCollider2D>().bounds;

            AspectRatioChange();

            // only update lookahead pos if accelerating or changed direction
            float xMoveDelta = (playerTransform.position - m_LastTargetPosition).x;

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget) {
                m_LookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
            }
            else {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
            }

            Vector3 aheadTargetPos = playerTransform.position + m_LookAheadPos + Vector3.forward * m_OffsetZ;
            aheadTargetPos = new Vector3(Mathf.Clamp(
                                                aheadTargetPos.x, 
                                                curBound.min.x + cameraBox.size.x / 2, 
                                                curBound.max.x - cameraBox.size.x / 2),
                                            Mathf.Clamp(
                                                aheadTargetPos.y, 
                                                curBound.min.y + cameraBox.size.y / 2, 
                                                curBound.max.y - cameraBox.size.y / 2),
                                            transform.position.z);
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

            transform.position = newPos;

            m_LastTargetPosition = playerTransform.position;
        }
    }

    void AspectRatioChange()
    {
        if (curBound.max.x - curBound.min.x < (2 * windowFinalSizeY * cam.aspect) - 0.01f)
        {
            // Debug.Log("Camera size is too large horizontally!");
            windowFinalSizeY = (curBound.max.x - curBound.min.x) / 2 / cam.aspect;
        }
        if (curBound.max.y - curBound.min.y < (2 * windowFinalSizeY) - 0.01f)
        {
            // Debug.Log("Camera size is too large vertically!");
            windowFinalSizeY = (curBound.max.y - curBound.min.y) / 2;
        }

        cameraBox.size = 2 * (new Vector2(cam.aspect * windowFinalSizeY, windowFinalSizeY));
    }

    /// <summary>
    /// Call this function to change the camera window
    /// </summary>
    /// <param name="followAlongX">Whether the camera follows the player's x position</param>
    /// <param name="followAlongY">Whether the camera follows the player's y position</param>
    /// <param name="windowCenterPos">The position (Vector2) of the center of the window</param>
    /// <param name="windowSizeY">The height of the window (aspect ratio 16:9)</param>
    /// <param name="camBoundsMin">The minimum x and y coordinates of the center of the camera</param>
    /// <param name="camBoundsMax">The maximum x and y coordinates of the center of the camera</param>
    public void changeWindow(/*bool followAlongX, bool followAlongY, Vector2 windowCenterPos, */float windowSizeY/*, Vector2 camBoundsMin, Vector2 camBoundsMax*/) {
        // TODO Work in progress
        // moveDone = false;
        // this.followAlongX = followAlongX;
        // this.followAlongY = followAlongY;
        // this.windowCenterPos = windowCenterPos;

        windowInitialSizeY = cam.orthographicSize;
        windowFinalSizeY = windowSizeY / 2;

        //windowMinConstraint = camBoundsMin;
        //windowMaxConstraint = camBoundsMax;

        StartCoroutine(moveToNewWindow());
    }

    IEnumerator moveToNewWindow() {
        // Vector2 camPos = cameraTransform.position;

        float timer = 0f;

        while (timer < transitionTime) {
            // Vector2 tempCamPos = Vector2.Lerp(camPos, windowCenterPos, transitionSpeedVariation.Evaluate(timer / transitionTime));
            // cameraTransform.position = new Vector3(tempCamPos.x, tempCamPos.y, cameraTransform.position.z);
            cam.orthographicSize = Mathf.Lerp(windowInitialSizeY, windowFinalSizeY, transitionSpeedVariation.Evaluate(timer / transitionTime));
            
            timer += Time.deltaTime;
            yield return null;
        }

        // moveDone = true;
        yield return null;
    }
}

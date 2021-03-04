using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Use this to set properties of the GravBeam like length
/// and whether it is free or hooked.
/// </summary>
//[ExecuteAlways]
[RequireComponent(typeof(ParticleSystem))]
public class BeamInterface : MonoBehaviour {
    [Tooltip("The length of the beam, as shown by the gizmo")]
    [SerializeField]
    private float length = 10f;
    [Tooltip("Whether the beam is hooked onto a surface")]
    public bool isHooked = false;
    [Tooltip("Speed of the beam particles when hooked")]
    public float hookedSpeed;
    [Tooltip("Speed of the beam particles when free")]
    public float freeSpeed;

    public Gradient freeColor;

    public Gradient hookedColor;

    //public AnimationCurve sizeOverTime;

    ParticleSystem beam;
    bool wasHooked;
    float lengthBuf;

    float transverseScale;
    float longScale;
    float scaleFactor;

    // Start is called before the first frame update
    void Awake() {
        beam = GetComponent<ParticleSystem>();
        wasHooked = isHooked;
        lengthBuf = length;

        transverseScale = transform.localScale.y;
        longScale = transform.localScale.z;

        scaleFactor = longScale / transverseScale;
    }

    void OnDrawGizmosSelected() {
        Gizmos.DrawLine(transform.position, transform.position + length * transform.forward);
    }

    // Update is called once per frame
    void Update() {

        transverseScale = transform.localScale.y;
        

        ParticleSystem.MainModule mainParams = beam.main;
        ParticleSystem.NoiseModule noise = beam.noise;
        ParticleSystem.TrailModule trail = beam.trails;
        ParticleSystem.VelocityOverLifetimeModule velocity = beam.velocityOverLifetime;

        ParticleSystem.MinMaxCurve lifetime = mainParams.startLifetime;
        ParticleSystem.MinMaxCurve speed = mainParams.startSpeed;
        ParticleSystem.MinMaxGradient color = trail.colorOverLifetime;

        if (isHooked && !wasHooked) {
            beam.Stop();
            beam.Clear();

            speed.constant = hookedSpeed;
            noise.enabled = false;
            trail.dieWithParticles = false;
            velocity.enabled = true;
            color.gradient = hookedColor;
            lifetime.constant = lengthBuf / hookedSpeed;
            mainParams.startSpeed = speed;
            wasHooked = true;
            mainParams.startLifetime = lifetime;
            beam.Play();
        }
        else if (!isHooked && wasHooked) {
            beam.Stop();
            beam.Clear();

            speed.constant = freeSpeed;
            noise.enabled = true;
            trail.dieWithParticles = true;
            velocity.enabled = false;
            color.gradient = freeColor;
            lifetime.constant = (lengthBuf + 1.5f) / freeSpeed;
            mainParams.startSpeed = speed;
            wasHooked = false;
            mainParams.startLifetime = lifetime;
            beam.Play();
        }

        //if(lengthBuf != length) {
        //    lifetime.constant = (11.5f) / speed.constant;
        //    mainParams.startLifetime = lifetime;
        //}

        //Debug.Log(transform.localScale.z * length);

        //transform.localScale.Set(transform.localScale.x, transform.localScale.y, transform.localScale.z * length / lengthBuf);
        
        trail.colorOverLifetime = color;

        
    }

    public void SetLength(float length) {

        float xScale = 1;
        float yScale = 1;
        if (length < 0.1f)
        {
            length = 0.1f;
            beam.Stop();

            xScale = 0.00001f;
            yScale = 0.00001f;
        }

        this.length = length;
        Debug.Log(length / lengthBuf);
        transform.localScale = new Vector3(xScale, yScale, length / lengthBuf);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Use this to set properties of the GravBeam like length (under development)
/// and whether it is free or hooked (under development).
/// </summary>
[ExecuteAlways]
[RequireComponent(typeof(ParticleSystem))]
public class BeamInterface : MonoBehaviour {
    [Tooltip("The length of the beam, as shown by the gizmo")]
    public float length = 5f;
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

    // Start is called before the first frame update
    void Start() {
        beam = GetComponent<ParticleSystem>();
        wasHooked = isHooked;
        lengthBuf = length;
    }

    void OnDrawGizmosSelected() {
        Gizmos.DrawLine(transform.position, transform.position + length * transform.forward);
    }

    // Update is called once per frame
    void Update() {
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
            lifetime.constant = length / hookedSpeed;
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
            lifetime.constant = (length + 1.5f) / freeSpeed;
            mainParams.startSpeed = speed;
            wasHooked = false;
            mainParams.startLifetime = lifetime;
            beam.Play();
        }

        if(lengthBuf != length) {
            lifetime.constant = (length + 1.5f) / speed.constant;
            mainParams.startLifetime = lifetime;
        }

        trail.colorOverLifetime = color;

        
    }
}

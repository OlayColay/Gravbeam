using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Use this to set properties of the GravBeam like length (under development)
/// and whether it is free or hooked (under development).
/// </summary>
[ExecuteInEditMode]
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

    ParticleSystem beam;

    // Start is called before the first frame update
    void Start() {
        beam = GetComponent<ParticleSystem>();
    }

    void OnDrawGizmos() {
        Gizmos.DrawLine(transform.position, transform.position + length * transform.forward);
    }

    // Update is called once per frame
    void Update() {
        ParticleSystem.MainModule mainParams = beam.main;
        ParticleSystem.NoiseModule noise = beam.noise;
        ParticleSystem.TrailModule trail = beam.trails;

        ParticleSystem.MinMaxCurve lifetime = mainParams.startLifetime;
        ParticleSystem.MinMaxCurve speed = mainParams.startSpeed;

        if (isHooked) {
            speed = hookedSpeed;
            noise.enabled = false;
            trail.dieWithParticles = false;

            ParticleSystem.MinMaxGradient color = trail.colorOverLifetime;
            color.gradient = hookedColor;
            trail.colorOverLifetime = color;
        }
        else {
            speed = freeSpeed;
            noise.enabled = true;
            trail.dieWithParticles = true;

            ParticleSystem.MinMaxGradient color = trail.colorOverLifetime;
            color.gradient = freeColor;
            trail.colorOverLifetime = color;
        }

        lifetime.constant = length / speed.constant;

        mainParams.startLifetime = lifetime;
        mainParams.startSpeed = speed;



        mainParams.startLifetime = lifetime;
        mainParams.startSpeed = speed;

    }
}

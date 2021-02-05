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
    public float length = 5f;
    public bool isHooked = false;
    public float hookedSpeed;
    public float freeSpeed;

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

        ParticleSystem.MinMaxCurve lifetime = mainParams.startLifetime;
        ParticleSystem.MinMaxCurve speed = mainParams.startSpeed;
        lifetime.constant = length / speed.constant;

        mainParams.startLifetime = lifetime;
        mainParams.startSpeed = speed;

        ParticleSystem.NoiseModule noise = beam.noise;

        if (isHooked) {
            speed = hookedSpeed;
            noise.enabled = false;
            
        }
        else {
            speed = freeSpeed;
            noise.enabled = true;
        }

        mainParams.startLifetime = lifetime;
        mainParams.startSpeed = speed;

    }
}

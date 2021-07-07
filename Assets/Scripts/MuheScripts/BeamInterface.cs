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
    [Tooltip("The color of the beam when not pulling on a surface")]
    public Gradient freeColor;
    [Tooltip("The color of the beam when pulling on a surface")]
    public Gradient hookedColor;

    // The particle system interface
    ParticleSystem beam;

    // Whether beam was hooked before this update cycle
    bool wasHooked;

    // The length reference for unit z-scale of the beam
    float lengthUnit;

    // Start is called before the first frame update
    void Awake() {
        beam = GetComponent<ParticleSystem>();
        wasHooked = isHooked;
        // Debug.Log(length);
        lengthUnit = 8.7f;
    }

    void OnDrawGizmosSelected() {
        Gizmos.DrawLine(transform.position, transform.position + length * transform.forward);
    }

    // Update is called once per frame
    void Update() {
        // Various tabs of the particle system module
        ParticleSystem.MainModule mainParams = beam.main;
        ParticleSystem.NoiseModule noise = beam.noise;
        ParticleSystem.TrailModule trail = beam.trails;
        ParticleSystem.VelocityOverLifetimeModule velocity = beam.velocityOverLifetime;

        // Various parts of the main module
        ParticleSystem.MinMaxCurve lifetime = mainParams.startLifetime;
        ParticleSystem.MinMaxCurve speed = mainParams.startSpeed;

        // Various parts of the trail module
        ParticleSystem.MinMaxGradient color = trail.colorOverLifetime;

        // Switch beams
        if (isHooked && !wasHooked) {
            beam.Stop();
            beam.Clear();

            speed.constant = hookedSpeed;                   // Set speed of beam particles
            noise.enabled = false;                          // Disable noise
            trail.dieWithParticles = false;                 // Give beam a thick look
            velocity.enabled = true;                        // Do things with the velocity, like spiraling
            color.gradient = hookedColor;                   // Set color of beam
            lifetime.constant = lengthUnit / hookedSpeed;   // Calculate lifetime to give the beam its unit z-scale length
            mainParams.startSpeed = speed;                  // Put the speed back into the module
            wasHooked = true;                               // Beam was hooked in this update
            mainParams.startLifetime = lifetime;            // Put the lifetime back into the module
            beam.Play();                                    // Play the beam particle simulation
        }
        else if (!isHooked && wasHooked) {
            beam.Stop();
            beam.Clear();

            speed.constant = freeSpeed;                             // Set speed of beam particles
            noise.enabled = true;                                   // Enable noise
            trail.dieWithParticles = true;                          // Give beam a thin look
            velocity.enabled = false;                               // Deactivate velocity stuff
            color.gradient = freeColor;                             // Set color of beam
            lifetime.constant = (lengthUnit + 1.5f) / freeSpeed;    // Calculate lifetime to give the beam its unit z-scale length
            mainParams.startSpeed = speed;                          // Put the speed back into the module
            wasHooked = false;                                      // Beam was unhooked in this update
            mainParams.startLifetime = lifetime;                    // Put the lifetime back into the module
            beam.Play();                                            // Play the beam particle simulation
        }
        
        trail.colorOverLifetime = color;    // Put the color back into the module
    }

    /// <summary>
    /// Sets the length of the GravBeam
    /// </summary>
    /// <param name="length">The length of the gravbeam</param>
    public void SetLength(float length) {


        float xScale = 1;
        float yScale = 1;

        // If length gets too close to zero, set length so that scale doesn't become zero
        if (length < 0.1f) {
            length = 0.1f;
            //beam.Stop();

            xScale = 0.00001f;
            yScale = 0.00001f;
        }
        if(lengthUnit < 0.1f)
        {
            lengthUnit = 8.7f;
        }

        this.length = length;

        transform.localScale = new Vector3(xScale, yScale, length / lengthUnit);
    }
}

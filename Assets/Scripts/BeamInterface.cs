using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Use this to set properties of the GravBeam like length (under development)
/// and whether it is free or hooked (under development).
/// </summary>
[RequireComponent(typeof(ParticleSystem))]
public class BeamInterface : MonoBehaviour {
    public float length;
    public bool isHooked;

    ParticleSystem beam;

    // Start is called before the first frame update
    void Start() {
        beam = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update() {
        
    }
}

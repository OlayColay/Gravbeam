using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamVent : MonoBehaviour
{
    [Tooltip("Force of the steam vent when it's active")]
    [SerializeField] private float force = 10f;
    
    [Tooltip("How long the steam vent is active for")]
    [SerializeField] private float timeActive = 0.5f;
    
    [Tooltip("How long the steam vent is inactive for")]
    [SerializeField] private float timeInactive = 1f;

    private Rigidbody2D affected;
    private bool loaded = false;
    private bool active = true;
    private bool vertical;
    private float timer;
    void Start()
    {
        vertical = (transform.rotation.z == 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            affected = other.GetComponent<Rigidbody2D>();
            loaded = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject == affected.gameObject)
        {
            affected = null;
            loaded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(active && loaded) 
        {
            affected.velocity = new Vector2(vertical ? affected.velocity.x : 0, 0);    
            affected.AddForce(new Vector2(vertical ? 0 : force, vertical ? force : 0), ForceMode2D.Impulse);
        }

        timer += Time.deltaTime;

        if (active && timer >= timeActive)
        {
            active = false;
            timer = 0;
            GetComponent<ParticleSystem>().Stop();
        }
        else if (!active && timer >= timeInactive)
        {
            active = true;
            timer = 0;
            GetComponent<ParticleSystem>().Play();
        }
    }
}

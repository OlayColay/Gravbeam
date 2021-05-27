using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

[RequireComponent(typeof(SpriteRenderer))]

public class LoadingScreen : MonoBehaviour
{
    public bool triggerFadeIn = false;
    public bool triggerFadeOut = false;

    [SerializeField] private bool startOpaque = true;
    [SerializeField] private float startingOpaqueToTransparentLag = 1f;
    
    [SerializeField] private bool isGravity = true;
    
    private SpriteRenderer sprite;
    private Color opaque;
    private Color transparent;
    private float lerpTime = 0f;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        opaque = Color.black;
        transparent = Color.clear;
        player = GameObject.FindGameObjectWithTag("Player");

        if (startOpaque)
        {
            sprite.color = opaque;
            if (startingOpaqueToTransparentLag > 0f)
            {
               if (isGravity)
               {
               StartCoroutine(WaitForFadeOutLag(startingOpaqueToTransparentLag));
               }
               else
               {
               StartCoroutine(WaitForFadeOutLagNoGrav(startingOpaqueToTransparentLag));
               }
            }
        }
        else
        {
            sprite.color = transparent;
        }
    }

    void Update()
    {
        if (triggerFadeIn)
        {
            sprite.color = Color.Lerp(transparent, opaque, lerpTime);
            lerpTime += Time.deltaTime;
            if (lerpTime >= 1f)
            {
                triggerFadeIn = false;
                lerpTime = 0f;
            }
        }
        else if (triggerFadeOut)
        {
            sprite.color = Color.Lerp(opaque, transparent, lerpTime);
            lerpTime += Time.deltaTime;
            if (lerpTime >= 1f)
            {
                triggerFadeOut = false;
                lerpTime = 0f;
            }
        }
    }

    private IEnumerator WaitForFadeOutLag(float lag)
    {        
        player.GetComponent<PlatformerCharacter2D>().controls.Disable();
        yield return new WaitForSecondsRealtime(lag);
        
        triggerFadeOut = true;
        player.GetComponent<PlatformerCharacter2D>().controls.Enable();
    }
    
    private IEnumerator WaitForFadeOutLagNoGrav(float lag)
    {        
//        player.GetComponent<BeamScript>().controls.Disable();
        yield return new WaitForSecondsRealtime(lag);
        
        triggerFadeOut = true;
//        player.GetComponent<BeamScript>().controls.Enable();
    }
    
    
}

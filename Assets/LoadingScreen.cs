using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class LoadingScreen : MonoBehaviour
{
    public bool triggerFadeIn = false;
    public bool triggerFadeOut = false;

    [SerializeField] private bool startOpaque = true;
    private SpriteRenderer sprite;
    private Color opaque;
    private Color transparent;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        opaque = Color.black;
        transparent = Color.clear;

        if (startOpaque)
        {
            sprite.color = opaque;
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
            sprite.color = Color.Lerp(transparent, opaque, Mathf.PingPong(Time.time, 1));
            if (sprite.color == opaque)
            {
                triggerFadeIn = false;
            }
        }
        else if (triggerFadeOut)
        {
            sprite.color = Color.Lerp(opaque, transparent, Mathf.PingPong(Time.time, 1));
            if (sprite.color == transparent)
            {
                triggerFadeOut = false;
            }
        }
    }
}

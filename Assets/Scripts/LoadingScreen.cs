using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private bool startOpaque = true;
    [SerializeField] private float startingOpaqueToTransparentLag = 1f;
    
    private SpriteRenderer sprite;
    private PlatformerCharacter2D player;
    private BeamScript ZeroGPlayer;
    private PlayerControls controls;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlatformerCharacter2D>();

        if (player != null)
        {
            controls = player.controls;
        }
        else
        {
            ZeroGPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<BeamScript>();
            controls = ZeroGPlayer.controls;
        }

        if (startOpaque)
        {
            sprite.color = Color.black;
            FadeOut(startingOpaqueToTransparentLag);
        }
        else
        {
            sprite.color = Color.clear;
        }
    }

    public void FadeIn(float time = 1f)
    {
        controls.Disable();
        sprite.DOFade(1f, time);
    }

    public void FadeOut(float time = 1f)
    {
        sprite.DOFade(0f, time).SetDelay(0.5f).OnComplete(() => controls.Enable());
    }
}

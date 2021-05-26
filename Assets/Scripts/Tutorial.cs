using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CircleCollider2D), typeof(SpriteRenderer))]
public class Tutorial : MonoBehaviour
{
    private SpriteRenderer sprite;

    private void Awake() 
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            sprite.DOFade(1f, 1f);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            sprite.DOFade(0f, 1f);
        }
    }
}
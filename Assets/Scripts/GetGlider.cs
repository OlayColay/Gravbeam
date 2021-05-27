using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class GetGlider : MonoBehaviour
{
    private void Start() 
    {
        if (PlayerPrefs.GetInt("gotGlider", 0) == 1)
        {
            FindObjectOfType<PlatformerCharacter2D>().hasGlider = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlatformerCharacter2D>().hasGlider = true;
            PlayerPrefs.SetInt("gotGlider", 1);
            Destroy(gameObject);
        }
    }
}

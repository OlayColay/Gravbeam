using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animation), typeof(Rigidbody2D))]
public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private float timeBeforeFall = 1.0f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<Animation>().Play();
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(timeBeforeFall);
        // Debug.Log("Fall!");
        GetComponent<Rigidbody2D>().isKinematic = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashArrow : MonoBehaviour
{
    private GameObject center;
    private Collider2D other;
    public float force = 10.0f;
    public bool disableControls = false;
    public float disableLength = 1.0f;
    private bool canFire = true;
    void Start()
    {
        center = this.gameObject.transform.GetChild(0).gameObject;
    }
    void OnTriggerEnter2D(Collider2D o)
    {
        Debug.Log("triggered");
        other = o;

        if(other.tag == "Player" && canFire)
        {
            if(other.tag == "Player" && disableControls)
            {
                // other.GetComponent<DroneCharacterController>().canControl = false;
                StartCoroutine("Wait");
            }
            //canFire = false;

            other.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            other.GetComponent<Rigidbody2D>().position = center.transform.position;

            other.GetComponent<Rigidbody2D>().AddForce(center.transform.right * force * 1000);

            GetComponent<AudioSource>().Play(0);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(disableLength);
        
        canFire = true;
        if(other.tag == "Player")
        {
            // other.GetComponent<DroneCharacterController>().canControl = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGoal : MonoBehaviour
{
    [Tooltip("The build index of the next level's scene. These can be found/edited in build settings")]
    [SerializeField] private int nextLevelNumber;

    void OnDrawGizmos()
    {
        GetComponent<BoxCollider2D>().offset = Vector2.zero;

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, GetComponent<BoxCollider2D>().size);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerPrefs.SetInt("currentLevel", nextLevelNumber);
            
            // Debug.Log("Latest Level was " + PlayerPrefs.GetInt("latestLevel", 0));
            if (nextLevelNumber > PlayerPrefs.GetInt("latestLevel", 0))
            {
                PlayerPrefs.SetInt("latestLevel", nextLevelNumber);
            }
            // Debug.Log("Latest Level is now " + PlayerPrefs.GetInt("latestLevel", 0));

            SceneManager.LoadScene(nextLevelNumber, LoadSceneMode.Single);
        }
    }
}

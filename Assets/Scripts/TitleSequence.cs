using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[RequireComponent(typeof(BoxCollider2D))]
public class TitleSequence : MonoBehaviour
{
    [SerializeField] private Transform oldTerrain;
    [SerializeField] private Transform newTerrain;
    [SerializeField] private Transform oldBackground;
    [SerializeField] private Transform newBackground;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        GetComponent<BoxCollider2D>().enabled = false;
        newTerrain.gameObject.SetActive(true);
        newBackground.gameObject.SetActive(true);

        for(int i = 0; i < oldTerrain.childCount; i++)
        {
            SpriteShapeRenderer oldColor = oldTerrain.GetChild(i).GetComponent<SpriteShapeRenderer>();
            // SpriteShapeRenderer newColor = newTerrain.GetChild(i).GetComponent<SpriteShapeRenderer>();
            StartCoroutine(FadeColors(oldColor/*, newColor*/));
        }
        
        for(int i = 0; i < oldBackground.childCount; i++)
        {
            Transform bgLayerOld = oldBackground.GetChild(i);
            Transform bgLayerNew = newBackground.GetChild(i);
            if (i == 0)
            {
                StartCoroutine(FadeColorsLayer1(bgLayerOld.GetComponent<SpriteRenderer>(), bgLayerNew.GetComponent<SpriteRenderer>()));
            }
            else
            {
                StartCoroutine(FadeColors(bgLayerOld.GetComponent<SpriteRenderer>(), bgLayerNew.GetComponent<SpriteRenderer>()));
            }

            for(int j = 0; j < bgLayerOld.childCount; j++)
            {
                SpriteRenderer oldColor = bgLayerOld.GetChild(j).GetComponent<SpriteRenderer>();
                SpriteRenderer newColor = bgLayerNew.GetChild(j).GetComponent<SpriteRenderer>();
                if (i == 0)
                {
                    StartCoroutine(FadeColorsLayer1(oldColor, newColor));
                }
                else
                {
                    StartCoroutine(FadeColors(oldColor, newColor));
                }
            }
        }
    }

    private IEnumerator FadeColors(SpriteShapeRenderer oldColor/*, SpriteShapeRenderer newColor*/)
    {
        for (float i = 0f; i <= 10f; i += Time.deltaTime)
        {
            // set color with i as alpha
            oldColor.color = new Color(1, 1, 1, 1 - i/10);
            // newColor.color = new Color(1, 1, 1, i/10);
            yield return null;
        }
    }
    private IEnumerator FadeColors(SpriteRenderer oldColor, SpriteRenderer newColor)
    {
        for (float i = 0f; i <= 10f; i += Time.deltaTime)
        {
            // set color with i as alpha
            oldColor.color = new Color(1, 1, 1, 1 - i/10);
            newColor.color = new Color(1, 1, 1, i/10);
            yield return null;
        }
    }

    // Different so that layer 1 doesn't appear transparent during transition
    private IEnumerator FadeColorsLayer1(SpriteRenderer oldColor, SpriteRenderer newColor)
    {
        for (float i = 0f; i <= 10f; i += Time.deltaTime)
        {
            // set color with i as alpha
            oldColor.color = new Color(1, 1, 1, 1 - i/10);
            newColor.color = new Color(1, 1, 1, i/3);
            yield return null;
        }

        oldTerrain.gameObject.SetActive(false);
        oldBackground.gameObject.SetActive(false);
    }
}

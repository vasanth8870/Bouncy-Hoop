using System.Collections;
using UnityEngine;

public class YAxisLerpLeftBasket : MonoBehaviour
{
    private float startYleftbas = 0.0f; 
    private float endYleftbas = 0.3f; 
    private float durationleftbas = 0.1f; 
    private float elapsedTimeleftbas = 0.0f; 
    private bool isLerpingleftbas = false; 

    public GameObject Hoppieleftbas;

    public void YLerpleftbas()
    {
        // Start lerping when the space bar is pressed


        StartLerpleftbas ();
        

        // Perform lerp if in progress
        if (isLerpingleftbas)
        {
            PerformLerpleftbas();
        }
    }

    void StartLerpleftbas ()
    {
        elapsedTimeleftbas = 0.0f;
        isLerpingleftbas = true;
    }

    void PerformLerpleftbas()
    {
        elapsedTimeleftbas += Time.deltaTime;

        // Calculate the current y position using Mathf.Lerp
        float currentY = Mathf.Lerp(startYleftbas, endYleftbas, elapsedTimeleftbas / durationleftbas);

        // Update the GameObject's position
        Vector3 position = Hoppieleftbas.transform.position;
        position.y = currentY;
        Hoppieleftbas.transform.position = position;
        
        // Stop lerping after the duration
        if (elapsedTimeleftbas >= durationleftbas)
        {
            isLerpingleftbas = false;
            
        }
        StartCoroutine(ReturnY());
    }

    private IEnumerator ReturnY()
    {
        yield return new WaitForSeconds(0.1f);
        float returny = Mathf.Lerp(endYleftbas, startYleftbas, elapsedTimeleftbas / durationleftbas);
        Vector3 returnpos = Hoppieleftbas.transform.position;
        returnpos.y = returny;
        Hoppieleftbas.transform.position = returnpos;
    }
}
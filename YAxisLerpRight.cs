using System.Collections;
using UnityEngine;

public class YAxisLerpRightBasket : MonoBehaviour
{
    private float startYrightbas = 0.0f; 
    private float endYrightbas = 0.3f; 
    private float durationrightbas = 0.1f; 
    private float elapsedTimerightbas = 0.0f; 
    private bool isLerpingrightbas = false; 

    public GameObject Hoppierightbas;

    public void YLerprightbas()
    {
        // Start lerping when the space bar is pressed

        StartLerprightbas ();
        

        // Perform lerp if in progress
        if (isLerpingrightbas)
        {
            PerformLerprightbas();
        }
    }

    void StartLerprightbas ()
    {
        elapsedTimerightbas = 0.0f;
        isLerpingrightbas = true;
    }

    void PerformLerprightbas()
    {
        elapsedTimerightbas += Time.deltaTime;

        // Calculate the current y position using Mathf.Lerp
        float currentY = Mathf.Lerp(startYrightbas, endYrightbas, elapsedTimerightbas / durationrightbas);

        // Update the GameObject's position
        Vector3 position = Hoppierightbas.transform.position;
        position.y = currentY;
        Hoppierightbas.transform.position = position;
        
        // Stop lerping after the duration
        if (elapsedTimerightbas >= durationrightbas)
        {
            isLerpingrightbas = false;
            
        }
        StartCoroutine(ReturnY());
    }

    private IEnumerator ReturnY()
    {
        yield return new WaitForSeconds(0.1f);
        float returny = Mathf.Lerp(endYrightbas, startYrightbas, elapsedTimerightbas / durationrightbas);
        Vector3 returnpos = Hoppierightbas.transform.position;
        returnpos.y = returny;
        Hoppierightbas.transform.position = returnpos;
    }
}
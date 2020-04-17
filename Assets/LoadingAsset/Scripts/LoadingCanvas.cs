using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingCanvas : MonoBehaviour
{
    public bool startOn = false;
    public float animDuration = 0.5f;
    public Text loadingText;
    
    CanvasGroup canvasGroup;

    bool isShowing;
    bool isAnimating;
    float alphaInit;
    float alphaFinal;
    float time;

    float dotStep = 0;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        isShowing = startOn;
        if (startOn)
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1;
        }
        else
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0;
        }
            
    }

    private void Update()
    {   
        if (!isAnimating) {
            return;
        }
        
        float progress = (Time.time - time) / animDuration;
        if(progress >= 1)
        {
            progress = 1;
            isAnimating = false;
        }
        float newAlpha = Mathf.Lerp(alphaInit, alphaFinal, progress);
        canvasGroup.alpha = newAlpha;

    }

    public void Show()
    {
        if (isShowing)
        {
            return;
        }
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1;

        isShowing = true;
        alphaInit = 0;
        alphaFinal = 1;
        time = Time.time;
        isAnimating = true;

        StartCoroutine( DotAnimation() );
    }

    public void Hide()
    {
        if (!isShowing)
        {
            return;
        }
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0;

        isShowing = false;
        alphaInit = 1;
        alphaFinal = 0;
        time = Time.time;
        isAnimating = true;
    }

    public IEnumerator DotAnimation()
    {
        while(isShowing)
        {
            string dots = "";
            switch (dotStep)
            {
                case 0:
                    dots = "      ";
                    break;
                case 1:
                    dots = " .    ";
                    break;
                case 2:
                    dots = " . .  ";
                    break;
                case 3:
                    dots = " . . .";
                    break;
            }

            loadingText.text = "C a r r e g a n d o" + dots;
            yield return new WaitForSeconds(0.5f);

            dotStep++;
            if (dotStep == 4)
            {
                dotStep = 0;
            }
        }  
    }
}

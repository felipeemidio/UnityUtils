using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(Animator))]
public class SideDrawer : MonoBehaviour
{
    public bool startOn = false;
    public RectTransform sideDrawer;

    private CanvasGroup canvasGroup;
    private Animator animator;
    public bool open;
    public bool isAnimating = false;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        animator = GetComponent<Animator>();
        open = startOn;
        animator.SetBool("open", open);
    }

    // Start is called before the first frame update
    void Start()
    {
        
        if (startOn)
        {
            Show();
        }
        else
        {
            TurnOffCanvas();
        }
        isAnimating = false;
    }

    public void ChangeIsAnimating()
    {
        isAnimating = !isAnimating;
    }

    public void Show()
    {
        if (open || isAnimating) return;

        open = true;
        animator.SetBool("open", open);
    }

    public void TurnOnCanvas()
    {
        if (!open) return;

        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1;
    }

    public void Hide()
    {
        if (!open || isAnimating) return;

        open = false;
        animator.SetBool("open", open);
    }

    public void TurnOffCanvas()
    {
        if (open) return;

        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0;
    }
}

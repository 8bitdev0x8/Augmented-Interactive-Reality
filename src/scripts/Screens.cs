using UnityEngine;
[RequireComponent(typeof(CanvasGroup))]
public class Screens : MonoBehaviour
{
    CanvasGroup canvasGroup;

    protected virtual void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

    }

    protected void SetScreen(bool open)
    {
        canvasGroup.interactable = open;
        canvasGroup.blocksRaycasts = open;
        canvasGroup.alpha = open ? 1 : 0;
    }
}

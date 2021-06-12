using UnityEngine;
using UnityEngine.Events;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] UnityEvent clickEvent;

    void OnMouseUpAsButton()
    {
        clickEvent?.Invoke();
    }

}

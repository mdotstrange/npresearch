using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableUI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector2 initialPosition;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public enum ImageType { Start, Follow, Target} // Add your image types here

    public ImageType imageType;



    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = gameObject.AddComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        initialPosition = rectTransform.anchoredPosition - eventData.position;
        canvasGroup.blocksRaycasts = false; // This allows for detection of other UI elements behind the current one.
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = initialPosition + eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
    }

   

}

using UnityEngine;
using UnityEngine.EventSystems;

public class SliderClick : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    private Transform objectTransform;
    private Vector3 initialPosition;

    private void Awake()
    {
        objectTransform = transform;
        initialPosition = objectTransform.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        objectTransform.position += (Vector3)eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        SnapToInitialPosition();
    }

    private void SnapToInitialPosition()
    {
        objectTransform.position = initialPosition;
    }
}

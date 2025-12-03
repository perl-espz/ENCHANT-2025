using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PuzzlePiece : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform originalParent;
    public int correctSlotIndex;

    private Canvas canvas;

    private void Start()
    {
        canvas = Object.FindFirstObjectByType<Canvas>();
        originalParent = transform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        transform.SetParent(canvas.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        GameObject objectUnder = eventData.pointerCurrentRaycast.gameObject;

        // Si sueltas sobre un Slot
        if (objectUnder != null && objectUnder.CompareTag("PuzzleSlot"))
        {
            transform.SetParent(objectUnder.transform);
            transform.localPosition = Vector3.zero;

            // Guardar slot actual
            PuzzleSlot slot = objectUnder.GetComponent<PuzzleSlot>();
            slot.currentPiece = this;
        }
        else
        {
            // Regresa a su lugar original si no cae en slot
            transform.SetParent(originalParent);
            transform.localPosition = Vector3.zero;
        }
    }
}

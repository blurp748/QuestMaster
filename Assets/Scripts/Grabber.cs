using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Grabber : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTrans;
    private CanvasGroup canvasGroup;
    private GameObject duplicate;

    private void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        duplicate = GameObject.Instantiate(this.gameObject);
        duplicate.transform.SetParent(this.gameObject.transform.parent,false);
        duplicate.active = true;
        Debug.Log("begin drag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        Vector2 position = this.gameObject.transform.position;
        this.gameObject.transform.SetParent(canvas.transform.GetChild(0),false);
        this.gameObject.transform.position = position; 
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("on drag");
        rectTrans.anchoredPosition += eventData.delta /canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end drag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        Destroy(eventData.pointerDrag);
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("click");
    }
}

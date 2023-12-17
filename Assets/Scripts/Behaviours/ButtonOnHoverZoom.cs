using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonOnHoverZoom : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    Vector3 realScale;
    RectTransform rectTransform;
    public float ZoomScale;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        realScale = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        rectTransform.localScale = new Vector3(ZoomScale, ZoomScale, 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.localScale = realScale;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        rectTransform.localScale = realScale;
    }
}

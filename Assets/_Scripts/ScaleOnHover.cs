using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScaleOnHover : MonoBehaviour, 
    IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] float _hoverScaleFactor = 1.5f;

    RectTransform _rectTransform;
    Vector3 _originalScale;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        _originalScale = _rectTransform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _rectTransform.localScale = _originalScale * _hoverScaleFactor;
        //Debug.Log("Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _rectTransform.localScale = _originalScale;
        //Debug.Log("Exit");
    }
}

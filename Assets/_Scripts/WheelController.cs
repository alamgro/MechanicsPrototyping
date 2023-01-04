using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelController : MonoBehaviour
{
    [SerializeField] int _segmentsAmount = 1;
    [SerializeField] float _initialAngle = 0f;
    [SerializeField] float _distanceFromCenter = 300f;
    [SerializeField] RectTransform _prefabRune;

    float _segmentDegrees = 0f;
    float _circleDegrees = 360f;

    private void Start()
    {
        UpdateSegmentsUI();
    }

    public void UpdateSegmentsUI()
    {
        DeleteAllRunes();

        if(_segmentsAmount < 1)
            _segmentsAmount = 1;

        _segmentDegrees = _circleDegrees / _segmentsAmount;
        float currentAngle = _initialAngle;
        Vector3 direction;

        for (int i = 0; i < _segmentsAmount; i++)
        {
            direction = new Vector3(Mathf.Cos(Mathf.Deg2Rad * currentAngle), Mathf.Sin(Mathf.Deg2Rad * currentAngle), 0f);
            currentAngle += _segmentDegrees;

            RectTransform runeRectTransform = Instantiate(_prefabRune, transform);
            runeRectTransform.localPosition = direction * _distanceFromCenter;
            if (i == 0)
                runeRectTransform.GetComponentInChildren<Image>().color = Color.red;

            //Debug.Log($"Direction: {direction}");
        }
    }

    private void DeleteAllRunes()
    {
        foreach (Transform rune in transform)
        {
            Destroy(rune.gameObject);
        }
    }
}

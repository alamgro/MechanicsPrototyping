using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelController : MonoBehaviour
{
    [Tooltip("The number of segments in the wheel.")]
    [SerializeField] int _segmentsAmount = 1;
    [Tooltip("The angle of the first item")]
    [SerializeField] float _initialAngle = 0f;
    [Tooltip("The distance from the center (radius).")]
    [SerializeField] float _distanceFromCenter = 300f;
    [SerializeField] RectTransform _prefabRune;

    // The degrees per segment acording to the number of segments in the circle.
    float _segmentDegrees = 0f;
    readonly float CIRCLE_DEGREES = 360f;

    private void Start()
    {
        UpdateSegmentsUI();
    }

    public void UpdateSegmentsUI()
    {
        // Delete all existent runes.
        DeleteAllRunes();

        if(_segmentsAmount < 1)
            _segmentsAmount = 1;

        // Get the degrees amount per segment
        _segmentDegrees = CIRCLE_DEGREES / _segmentsAmount;

        float currentAngle = _initialAngle;
        Vector3 direction;

        for (int i = 0; i < _segmentsAmount; i++)
        {
            // Calculate the direction given an angle.
            direction = new Vector3(Mathf.Cos(Mathf.Deg2Rad * currentAngle), Mathf.Sin(Mathf.Deg2Rad * currentAngle), 0f);
            // Add the corresponding degrees to the Angle Counter.
            currentAngle += _segmentDegrees;

            // Instantiate object.
            RectTransform runeRectTransform = Instantiate(_prefabRune, transform);
            // Set the correct position of the object.
            runeRectTransform.localPosition = direction * _distanceFromCenter;

            // This is just to know which one is the first object.
            if (i == 0)
                runeRectTransform.GetComponentInChildren<Image>().color = Color.red;
        }
    }

    // Destroy all rune gameobjects
    private void DeleteAllRunes()
    {
        foreach (Transform rune in transform)
        {
            Destroy(rune.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Tutorial: https://www.youtube.com/watch?v=uSnZuBhOA2U
public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {
    Image backgroundImage;
    Image joystickImage;

    [HideInInspector]
    public float yThreshold = 1.0f;
    public Vector2 input;

    private void Start() {
        backgroundImage = GetComponent<Image>();
        joystickImage = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnDrag(PointerEventData ped) {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(backgroundImage.rectTransform, ped.position, ped. pressEventCamera, out pos)) {
            // Get position of click
            pos.x = (pos.x / backgroundImage.rectTransform.sizeDelta.x);
            pos.y = (pos.y / backgroundImage.rectTransform.sizeDelta.y);

            // Input will be between -1 and 1
            input = new Vector2(Mathf.Clamp(pos.x * 2, -1.0F, 1.0F), pos.y);

            // Move image
            int transformY = 0;
            if (input.y > yThreshold) {
                transformY = 50;
            }

            joystickImage.rectTransform.anchoredPosition = new Vector3(Mathf.Clamp(input.x * (backgroundImage.rectTransform.sizeDelta.x / 2), -250F, 250F), transformY);
        }
    }

    public virtual void OnPointerDown(PointerEventData ped) {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped) {
        input = Vector2.zero;
        joystickImage.rectTransform.anchoredPosition = Vector3.zero;
    }
}

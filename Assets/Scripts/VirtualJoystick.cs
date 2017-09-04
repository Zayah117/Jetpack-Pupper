using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Tutorial: https://www.youtube.com/watch?v=uSnZuBhOA2U
public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {
    private Image backgroundImage;
    private Image joystickImage;

    public float input;
    public float fireThreshold = 1.20f;
    public bool fireEnabled;

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
            input = Mathf.Clamp(pos.x * 2, -1.0F, 1.0F);

            // Move image
            int transformY = 0;
            fireEnabled = false;

            if (pos.y > fireThreshold) {
                transformY = 50;
                fireEnabled = true;
            }

            joystickImage.rectTransform.anchoredPosition = new Vector3(Mathf.Clamp(input * (backgroundImage.rectTransform.sizeDelta.x / 2), -250F, 250F), transformY);
        }
    }

    public virtual void OnPointerDown(PointerEventData ped) {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped) {
        input = 0;
        fireEnabled = false;
        joystickImage.rectTransform.anchoredPosition = Vector3.zero;
    }
}

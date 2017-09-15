using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Tutorial: https://www.youtube.com/watch?v=uSnZuBhOA2U
public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {
    public GameObject player;
    public Sprite defaultBar;
    public Sprite shootingBar;
    public Sprite defaultKnob;
    public Sprite shootingKnob;
    public Sprite redBar;
    public Sprite redKnob;
    public float yThreshold = 0.5f;

    Image backgroundImage;
    Image joystickImage;
    Image lightningImage;

    [HideInInspector]
    public Vector2 input;

    private void Start() {
        backgroundImage = GetComponent<Image>();
        joystickImage = transform.GetChild(1).GetComponent<Image>();
        lightningImage = transform.GetChild(2).GetComponent<Image>();
        lightningImage.enabled = false;
    }

    public virtual void OnDrag(PointerEventData ped) {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(backgroundImage.rectTransform, ped.position, ped. pressEventCamera, out pos)) {
            // Get position of click
            pos.x = (pos.x / backgroundImage.rectTransform.sizeDelta.x);
            pos.y = (pos.y / backgroundImage.rectTransform.sizeDelta.y);

            // Input will be between -1 and 1
            input = new Vector2(Mathf.Clamp(pos.x * 2, -1.0F, 1.0F), pos.y);

            // Move knob image and change background
            int transformY = 0;
            if (input.y > yThreshold) {
                transformY = 25;
                if (player.GetComponent<PupperController>().ammo <= 0) {
                    SetHud(redBar, redKnob, false);
                } else {
                    SetHud(shootingBar, shootingKnob, true);
                }
            } else {
                SetHud(defaultBar, defaultKnob, false);
            }

            joystickImage.rectTransform.anchoredPosition = new Vector3(Mathf.Clamp(input.x * (backgroundImage.rectTransform.sizeDelta.x / 2), -250F, 250F), transformY);
        }
    }

    public virtual void OnPointerUp(PointerEventData ped) {
        input = Vector2.zero;
        joystickImage.rectTransform.anchoredPosition = Vector3.zero;
        SetHud(defaultBar, defaultKnob, false);
    }

    public virtual void OnPointerDown(PointerEventData ped) {
        OnDrag(ped);
    }

    void SetHud(Sprite bar, Sprite knob, bool lightning) {
        backgroundImage.sprite = bar;
        joystickImage.sprite = knob;
        lightningImage.enabled = lightning;
    }
}

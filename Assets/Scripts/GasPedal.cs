using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GasPedal : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Sprite gasPedalPressedSprite;
    [SerializeField] Sprite gasPedalNotPressedSprite;

    public bool isPressing = false;
    public float accelerationDirection = 0;

    public static GasPedal Instance;

    private Image gasPedalImage;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        gasPedalImage = GetComponent<Image>();
        gasPedalImage.sprite = gasPedalNotPressedSprite;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressing = true;
        accelerationDirection = GearManager.Instance.GetDirection();
        gasPedalImage.sprite = gasPedalPressedSprite;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressing = false;
        accelerationDirection = 0;
        gasPedalImage.sprite = gasPedalNotPressedSprite;
    }
}

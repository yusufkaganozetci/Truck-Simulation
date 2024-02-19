using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BrakePedal : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Sprite brakePedalPressedSprite;
    [SerializeField] Sprite brakePedalNotPressedSprite;

    public static BrakePedal Instance;

    public bool isPressing = false;

    private Image brakePedalImage;
    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        brakePedalImage = GetComponent<Image>();
        brakePedalImage.sprite = brakePedalNotPressedSprite;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressing = true;
        brakePedalImage.sprite = brakePedalPressedSprite;
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressing = false;
        brakePedalImage.sprite = brakePedalNotPressedSprite;
    }
}

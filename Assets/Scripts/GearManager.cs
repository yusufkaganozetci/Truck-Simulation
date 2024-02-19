using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public enum GearType
{
    Drive,//D
    Reverse,//R
}

[Serializable]
public class Gear
{
    public GearType type;
    public Image gearBackground;
    public int accelerationDirection;

    public void ChangeGearBackgroundColor(Color color)
    {
        gearBackground.color = color;
    }
}

public class GearHelper
{
    public Gear GetGearByType(Gear[] gears, GearType type)
    {
        Gear gear = null;
        for(int i = 0; i < gears.Length; i++)
        {
            if (gears[i].type == type)
            {
                gear = gears[i];
                break;
            }
        }
        return gear;
    }
}

public class GearManager : MonoBehaviour
{
    [SerializeField] Gear[] gears;
    [SerializeField] Color gearChosenColor;
    [SerializeField] Color gearNotChosenColor;

    private Gear currentGear;
    private GearHelper gearHelper = new GearHelper();

    public static GearManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        currentGear = gears[0];
        currentGear.ChangeGearBackgroundColor(gearChosenColor);
    }

    public void ChangeGear(int type)
    {
        currentGear.ChangeGearBackgroundColor(gearNotChosenColor);
        currentGear = gearHelper.GetGearByType(gears, (GearType)type);
        currentGear.ChangeGearBackgroundColor(gearChosenColor);
    }

    public int GetDirection()
    {
        return currentGear.accelerationDirection;
    }
    
}
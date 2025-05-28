using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleImageChanger : MonoBehaviour
{
    public Toggle toggle;
    public Image targetImage; 
    public Sprite onSprite;   
    public Sprite offSprite;  

    void Start()
    {
        toggle.onValueChanged.AddListener(UpdateImage);
        UpdateImage(toggle.isOn);
    }

    void UpdateImage(bool isOn)
    {
        targetImage.sprite = isOn ? onSprite : offSprite;
    }
}

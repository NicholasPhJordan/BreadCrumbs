using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonColorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Text _text;

    //changes the text to red when button is hovering over button
    public void OnPointerEnter(PointerEventData eventData)
    {
        _text.color = Color.red; //Or however you do your color
    }

    //changes the text back to white when the mouse isn't hovering over button
    public void OnPointerExit(PointerEventData eventData)
    {
        _text.color = Color.white; //Or however you do your color 
    }
}

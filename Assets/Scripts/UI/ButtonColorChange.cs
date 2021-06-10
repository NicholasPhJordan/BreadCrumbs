using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonColorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Text _text;
    public void OnPointerEnter(PointerEventData eventData)
    {
        _text.color = Color.red; //Or however you do your color
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _text.color = Color.white; //Or however you do your color 
    }
}

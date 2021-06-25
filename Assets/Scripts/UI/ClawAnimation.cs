using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClawAnimation : MonoBehaviour
{
    [SerializeField]
    private Image _claw;

    // Start is called before the first frame update
    void Start()
    {
        _claw = GetComponent<Image>();
    }

    public static void OnAttack()
    {
        _claw.color = new Color(_claw.color.r, _claw.color.g, _claw.color.b, 1f);
    }
}

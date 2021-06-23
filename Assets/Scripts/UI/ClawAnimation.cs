using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClawAnimation : MonoBehaviour
{
    [SerializeField]
    private Image _claw;

    private int _alpha;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnAttack()
    {
        _claw.color.a = Mathf.Lerp(0, 255, 30);
    }
}

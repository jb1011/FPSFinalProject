using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIControllerLevel3 : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _killThemAll;

    private float timer = 3.5f;

    void Start()
    {
        _killThemAll.enabled = true;
    }

    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            _killThemAll.enabled = false;
        }
    }
}

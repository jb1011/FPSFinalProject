using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillScore : MonoBehaviour
{
    private TextMeshProUGUI _textKill;

    [SerializeField]
    private IntVariable _KillCount;
    // Start is called before the first frame update
    void Start()
    {
        _textKill = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _textKill.text = _KillCount.Value.ToString();
    }
}

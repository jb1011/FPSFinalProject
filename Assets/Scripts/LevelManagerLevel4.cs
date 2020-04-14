using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerLevel4 : MonoBehaviour
{
    [SerializeField]
    private IntVariable _killScore;

    [SerializeField]
    private GameObject _miniBoss;
    // Start is called before the first frame update
    void Start()
    {
        _killScore.Value = 0;
        _miniBoss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(_killScore.Value == 1)
        {
            _miniBoss.SetActive(true);
        }
    }
}

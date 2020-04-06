using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreLevel2 : MonoBehaviour
{
    [SerializeField]
    private IntVariable _score;

    private TextMeshProUGUI _scoreText;

    public float CountInterval = 0.1f, timer=0;
    int i = 0;


    private void Start()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
        _score.Value = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime * 20f;
        if(i<_score.Value && timer >= CountInterval)
        {
            i++;
            _scoreText.text = "Score : " + i.ToString();
            timer = 0;
        }
        //_scoreText.text = "Score : " + _score.Value;
    }

}

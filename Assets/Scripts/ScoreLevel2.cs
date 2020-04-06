using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreLevel2 : MonoBehaviour
{
    [SerializeField]
    private FloatVariable _score;

    private TextMeshProUGUI _scoreText;

    private void Start()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
        _score.Value = 0;
    }

    private void Update()
    {
        _scoreText.text = "Score" + _score.Value;
    }

}

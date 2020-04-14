using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Level3Manager : MonoBehaviour
{
    [SerializeField]
    private IntVariable _killCount;

    [SerializeField]
    private GameObject _collider;

    [SerializeField]
    private GameObject _moreCars;

    [SerializeField]
    private AudioSource _levelUp;

    [SerializeField]
    private AudioSource _growl;

    private bool _growlPlayed = false;

    private bool _hasPlayed;

    [SerializeField]
    private GameObject _boss;

    [SerializeField]
    private TextMeshProUGUI _jump;

    [SerializeField]
    private TextMeshProUGUI _cantGo;

    [SerializeField]
    private TextMeshProUGUI _congrats;

    private float timer = 6f;

    private float _secondTimer = 8f;

    private float _thirdTimer = 4f;

    [SerializeField]
    private GameObject _runeEffect;

    [SerializeField]
    private Transform _spawnerRune;
    private void Start()
    {
        _hasPlayed = false;
        _collider.SetActive(true);
        _boss.SetActive(false);
        _moreCars.SetActive(false);
        _jump.enabled = false;
        _killCount.Value = 0;
        _congrats.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(_killCount.Value == 12 && !_hasPlayed)
        {
            _levelUp.Play();
            _collider.SetActive(false);
            _hasPlayed = true;
            _cantGo.enabled = false;
        }

        if(_killCount.Value == 20 && !_growlPlayed)
        {
            Instantiate(_runeEffect, _spawnerRune);
            _boss.SetActive(true);
            _growl.Play();
            _growlPlayed = true;
        }

        if(_killCount.Value >= 22)
        {
            _moreCars.SetActive(true);
            
            
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                if(_secondTimer > 0)
                {
                    _jump.enabled = true;
                    _secondTimer -= Time.deltaTime;
                }
                else
                {
                    _jump.enabled = false;
                }
            }           
        }

        if(_killCount.Value == 23 && _thirdTimer > 0)
        {
            _congrats.enabled = true;
            _thirdTimer -= Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene("Scene04");
        }


    }
}

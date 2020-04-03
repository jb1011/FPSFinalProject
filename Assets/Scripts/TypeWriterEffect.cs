using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{
    private float delay = 0.1f;

    [SerializeField]
    private string fullText1;

    [SerializeField]
    private string fullText2;

    [SerializeField]
    private string fullText3;

    [SerializeField]
    private TextMeshProUGUI _whereToWrite1;

    [SerializeField]
    private TextMeshProUGUI _whereToWrite2;

    [SerializeField]
    private TextMeshProUGUI _whereToWrite3;

    private bool _text1;

    private string currentText = "";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ShowText");
        StartCoroutine(LoadScene());
    }

    public IEnumerator ShowText()
    {
        yield return new WaitForSeconds(5f);
        for(int i = 0; i < fullText1.Length; i++)
        {
            currentText = fullText1.Substring(0, i);
            _whereToWrite1.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < fullText2.Length; i++)
        {
            currentText = fullText2.Substring(0, i);
            _whereToWrite2.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        //yield return new WaitForSeconds(3f);
        for (int i = 0; i < fullText3.Length; i++)
        {
            currentText = fullText3.Substring(0, i);
            _whereToWrite3.text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }

    public IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(21f);
        SceneManager.LoadScene("Scene01");
    }
}

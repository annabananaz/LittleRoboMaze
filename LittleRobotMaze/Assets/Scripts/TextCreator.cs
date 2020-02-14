using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextCreator : MonoBehaviour
{
    public GameObject letterPrefab;
    public string text;
    // Start is called before the first frame update
    void Start()
    {
        createLetterText(text, letterPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createLetterText(string textIn, GameObject textPrefab) {
        for (int i = 0; i < textIn.Length; i++)
        {
            string bufferText = "";
            for (int letterCount = 0; letterCount < i; letterCount++) {
                bufferText += "   ";
            }

            GameObject letter = Instantiate(textPrefab, gameObject.transform);
            letter.GetComponent<TextMeshPro>().text = bufferText + textIn.Substring(i, 1);
        }
    }
}

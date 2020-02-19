using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBubbleScript : MonoBehaviour {

    public GameObject textBubblePrefab;
    public float height = 3;

    public void ShowBubble(string text, float duration) {
        StartCoroutine(ShowBubbleEnumerator(text, duration));
    }

    private IEnumerator ShowBubbleEnumerator(string text, float duration) {
        Transform camera = GameObject.Find("Main Camera").transform;
        Transform player = gameObject.transform;
        GameObject textBubbleObj = Instantiate(textBubblePrefab, player.position, Quaternion.identity);

        Vector3 endHeight = player.position + Vector3.up * height;

        textBubbleObj.transform.LookAt(camera.position);
        textBubbleObj.transform.Rotate(0, 180, 0);
        TextMeshPro tmp = textBubbleObj.GetComponent<TextMeshPro>();
        tmp.text = text;

        // Pop up
        while (Vector3.Distance(textBubbleObj.transform.position, endHeight) > 0.01f) {
            Vector3 moveTo = Vector3.Lerp(textBubbleObj.transform.position, endHeight, 0.01f);
            textBubbleObj.transform.position = moveTo;
            yield return new WaitForSeconds(0.0001f);
        }
        
        
        // Wait until expired
        yield return new WaitForSeconds(duration);
        if (duration > 0)
            Destroy(textBubbleObj);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBubbleScript : MonoBehaviour {

    public GameObject textBubblePrefab;

    public void ShowBubble(string text, float duration) {
        StartCoroutine(ShowBubbleEnumerator(text, duration));
    }

    private IEnumerator ShowBubbleEnumerator(string text, float duration) {
        Transform camera = GameObject.Find("Main Camera").transform;
        Transform player = gameObject.transform;
        GameObject textBubbleObj = Instantiate(textBubblePrefab, player.position + Vector3.up * 3, Quaternion.identity);
        textBubbleObj.transform.LookAt(camera.position);
        textBubbleObj.transform.Rotate(0, 180, 0);
        TextMeshPro tmp = textBubbleObj.GetComponent<TextMeshPro>();
        tmp.text = text;
        yield return new WaitForSeconds(duration);
        if (duration > 0)
            Destroy(textBubbleObj);
    }
}

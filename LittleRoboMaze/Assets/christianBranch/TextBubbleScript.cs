using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBubbleScript : MonoBehaviour {

    public void ShowBubble(string text, float duration) {
        Transform camera = GameObject.Find("Main Camera").transform;
        GameObject textBubble = new GameObject("Text Bubble");
        textBubble.transform.LookAt(camera);

    }

}

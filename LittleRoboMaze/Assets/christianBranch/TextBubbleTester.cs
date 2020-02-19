using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBubbleTester : MonoBehaviour {
    void Start() {
        TextBubbleScript tb = GameObject.Find("Player").GetComponent<TextBubbleScript>();
        tb.height = 5;
        tb.ShowBubble("Hello, World", 5);
    }
}

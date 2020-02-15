using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBubbleTester : MonoBehaviour {
    void Start() {
        GameObject.Find("Player").GetComponent<TextBubbleScript>().ShowBubble("Hello, World", 5);
    }
}

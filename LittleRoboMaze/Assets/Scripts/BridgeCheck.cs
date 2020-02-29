using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeCheck : MonoBehaviour
{
    bool open = true;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool getState()
    {
        return open;
    }

    public void changeState()
    {
        open = !open;
        if(open)
        {
          GetComponent<MeshRenderer>().sharedMaterial.color = Color.blue;
        }
        else
        {
           GetComponent<MeshRenderer>().sharedMaterial.color = Color.yellow;
        }
    }

    void OnTriggerEnter(Collider s)
    {
        if (s.gameObject.tag == "Player")
        {
            Debug.Log("hit");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticalCheck : MonoBehaviour
{
    //makes a list to hold different kinds of obisticals
    public List<GameObject> obsticals = new List<GameObject>();
    public List<Vector3> obsticalsPos = new List<Vector3>();
    public List<int> obsticalType = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        
        for(int i = 0; i < obsticalsPos.Count; i++)
        {
            GameObject obstical = Instantiate(obsticals[obsticalType[i]], gameObject.transform);
            obstical.transform.position = obsticalsPos[i];
        }
        Debug.Log("done");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeBridgeState()
    {
        for (int i = 0; i < obsticals.Count; i++)
        {
            if (obsticalType[i] == 0)
            {
                obsticals[i].GetComponent<BridgeCheck>().changeState();
            }
        }
    }

    public bool getBridgeState()
    {
        return false;
    }
}


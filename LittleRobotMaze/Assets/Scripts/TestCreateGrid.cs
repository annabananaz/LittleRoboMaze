using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCreateGrid : MonoBehaviour
{
    // creates 10x10 grid
    // Start is called before the first frame update
    public List<GameObject> blocks = new List<GameObject>();
    void Start()
    {
        int piece = 0;
        int offset = 0;

        int y = -1;
        for (int i = -5; i < 5; i++) {
            piece = offset;
            for (int j = -5; j < 5; j++)
            {
                GameObject block = Instantiate(blocks[piece],gameObject.transform);
                block.transform.position = new Vector3(i, y, j);
                piece = (piece + 1) % blocks.Count;
            }

            offset = (offset + 1) % blocks.Count;
        }
    }

}

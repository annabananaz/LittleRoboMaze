using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllMoveManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects = new List<GameObject>();
    
    bool moveValid = true;
    public bool running = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveValid = true;
        for (int i = 0; i < objects.Count; i++) {
            GameObject obj = objects[i];
            if (obj.tag == "Player") {
                if (obj.GetComponent<PlayerControl>().moving == true) {
                    moveValid = false;
                }
            }

            if (obj.tag == "Enemy")
            {
                if (obj.GetComponent<EnemyScript>().moving == true)
                {
                    moveValid = false;
                }
            }
        }


        if (moveValid && running)
        {
            moveAll();
        }
    }

    private void moveAll() {
        for (int i = 0; i < objects.Count; i++)
        {
            GameObject obj = objects[i];
            if (obj.tag == "Player")
            {
                obj.GetComponent<PlayerControl>().NextMove();
                
            }

            if (obj.tag == "Enemy")
            {
                obj.GetComponent<EnemyScript>().NextMove();
            }
        }
    }
}

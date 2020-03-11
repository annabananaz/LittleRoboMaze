using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllMoveManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects = new List<GameObject>();
    
    bool moveValid = true;
<<<<<<< Updated upstream
    public bool running = false;
=======
    public int runAttempts;
    public static bool running = false;
    private string sceneName;
>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
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

        if(UIScript.runCount >= runAttempts)
        {
            SceneManager.LoadScene(sceneName);
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

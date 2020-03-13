using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllMoveManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects = new List<GameObject>();

    bool moveValid = true;
    public int maxRunAttempts;
    public static bool running = false;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        running = false;
        print(UIScript.runCount);
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

        CheckRunCount();
    }

    private void moveAll() {
        count++;
        if (count % 3 == 0)
        {
            GameObject go = GameObject.Find("Obsticals");
            ObsticalCheck other = (ObsticalCheck)go.GetComponent(typeof(ObsticalCheck));
            other.changeBridgeState();
        }

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

    // RESETS THE SCENE IF THE MAX RUN COUNT IS EXCEEDED
    public void CheckRunCount()
    {
        print("Resetting in AMM");
        Scene currentSceneName = SceneManager.GetActiveScene();
        if (UIScript.runCount > maxRunAttempts)
        {
            SceneManager.LoadScene(currentSceneName.name);
        }
    }
}

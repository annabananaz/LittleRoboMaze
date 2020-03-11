using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public static List<string> moves = new List<string>();
    Vector3 targetPos;
    public bool moving = false;
    //public ObsticalCheck other;
    Vector3 startPos;
    public static bool reachedGoal;
    Vector3 down;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        reachedGoal = false;

        down = transform.TransformDirection(Vector3.down);
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            if (gameObject.transform.position != targetPos)
            {
                MovePlayerTo(targetPos, 0.05f);
            }
            else
            {
                moving = false;
            }
        }

        if (reachedGoal)
        {
            print("A winner is you!");
            reachedGoal = true;
        }

        //checks if player is still on level
        Debug.DrawRay(transform.position, down, Color.red);
        if (!Physics.Raycast(transform.position, down, 1))
        {
            Debug.Log("You done fell to your doom.");
            ResetScene();
        }
    }
    

    public void NextMove()
    {
        if (moves.Count != 0)
        {
            // if queue is not empty and not moving
            if (moves[0] == "for")
            {
                ForLoopReplace(moves);
            }

            targetPos = FindTargetPos(moves[0]);
            moves.RemoveAt(0);
            moving = true;

            //checks if was last move
            if (moves.Count == 0)
            {
                AllMoveManager.running = false;
            }
        }
    }

    void MovePlayerTo(Vector3 movePos, float lerpSpd) {
        //check distance between points to clamp
        if (Vector3.Distance(gameObject.transform.position, movePos) < 0.01f)
        {
            gameObject.transform.position = movePos;
            return;
        }

        //lerp position
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, movePos, lerpSpd);
    }

    Vector3 FindTargetPos(string move) {
        // returns a vector of new position

        Vector3 newTargetPos = gameObject.transform.position;

        switch (move)
        {
            case "forward":
                newTargetPos += new Vector3(1,0,0);
                break;
            case "back":
                newTargetPos -= new Vector3(1, 0, 0);
                break;
            case "right":
                newTargetPos -= new Vector3(0, 0, 1);
                break;
            case "left":
                newTargetPos += new Vector3(0, 0, 1);
                break;
        }

        return newTargetPos;
    }

    void ForLoopReplace(List<string> movesList) {
        // replaces for loop in list to perform for loop

        movesList.RemoveAt(0);
        int count = int.Parse(moves[0]);
        movesList.RemoveAt(0);

        List<string> insertMoveList = new List<string>();

        while (moves[0] != "done") {
            insertMoveList.Add(moves[0]);
            movesList.RemoveAt(0);
        }
        movesList.RemoveAt(0);

        for (int i = 0; i < count; i++) {
            movesList.InsertRange(0,insertMoveList);
        }
    }

    public void SetList(List<string> newList) {
        moves = new List<string>(newList);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Endpoint"))
        {
            print("GOOOOOOOOAAAAAAAAAL");
            reachedGoal = true;
        }
        else
        {
            reachedGoal = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(collision.gameObject.name + " says: 'Ha! You fell right into my trap!'");
            ResetScene();
        }
    }

    // RESETS THE SCENE IF ANY BAD THINGS HAPPEN TO THE PLAYER
    public void ResetScene()
    {
        print("Resetting in PC");
        Scene currentSceneName = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentSceneName.name);
    }
}

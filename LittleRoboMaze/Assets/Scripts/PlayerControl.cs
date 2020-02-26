using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static List<string> moves = new List<string>();
    Vector3 targetPos;
    public bool moving = false;

    // Start is called before the first frame update
    void Start()
    {
        //to test
        //moves.Add("forward");
        //moves.Add("forward");
        //moves.Add("left");

        // how to add for loop
        //moves.Add("for"); // for
        //moves.Add("4"); // # of times to loop
        //moves.Add("back"); // actions
        //moves.Add("left");
        //moves.Add("done"); // done
        ////

        //moves.Add("right");
        //moves.Add("right");
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
    }

    public void NextMove() {
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
}

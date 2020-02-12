using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    List<string> moves = new List<string>();
    Vector3 targetPos;
    bool moving = false;

    // Start is called before the first frame update
    void Start()
    {
        //to test
        moves.Add("forward");
        moves.Add("forward");
        moves.Add("left");
        moves.Add("back");
        moves.Add("right");
        moves.Add("right");
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            if (gameObject.transform.position != targetPos) {
                movePlayerTo(targetPos);
            }
            else
            {
                moving = false;
            }
        }
        else if(moves.Count != 0)
        {
            // if queue is not empty and not moving
            targetPos = findTargetPos(moves[0]);
            moves.Remove(moves[0]);
            moving = true;
        }
    }

    void movePlayerTo(Vector3 movePos) {
        float lerpSpd = 0.05f;

        //check distance between points to clamp
        if (Vector3.Distance(gameObject.transform.position, movePos) < 0.01f) {
            gameObject.transform.position = movePos;
            return;
        }

        //lerp position
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, movePos, lerpSpd);

    }

    // returns a vector of new position
    Vector3 findTargetPos(string move) {
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
                newTargetPos += new Vector3(0, 0, 1);
                break;
            case "left":
                newTargetPos -= new Vector3(0, 0, 1);
                break;
        }

        return newTargetPos;
    }
}

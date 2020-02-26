using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : EnemyObserver
{
    public List<string> moveTemplate;   //loop of moves in a specific order
    public List<string> movesToMake;    //next moves of enemy
    public int moveIndex;               //index of current move
    public int dist;                    //distance of moving (optional)
    Vector3 targetPos;                  //target position of current move
    public bool moving;                        //shows if enemy is currently moving

    // Start is called before the first frame update
    void Start()
    {
        moving = false;
        moveIndex=0;
        //onNotify(9);
    }

    // Update is called once per frame
    void Update()
    {
        //if the player is currently on a move
        if (moving)
        {
            //check if move is completed, otherwise continue moving
            if (gameObject.transform.position != targetPos) {
                makeMove(targetPos,0.05f);
            }
            //if move is completed, player stops moving
            else
            {
                moving = false;
            }
        }

        if (movesToMake.Count < 4) {
            onNotify(4);
        }
    }

    public void NextMove() {
        //if there are moves left, make a move
        if (movesToMake.Count > 0)
        {
            targetPos = FindTargetPos(movesToMake[0]);
            movesToMake.RemoveAt(0);
            moving = true;
        }
    }

    //function to add x moves to enemy, can be called if moves added to player
    public override void onNotify(int moveCount){
        for(int i=0;i<moveCount;i++){
            addMove();
        }
    }

    //function to add a new move to the moves list
    void addMove(){

        //adds new move to list of moves to make
        movesToMake.Add(moveTemplate[moveIndex]);

        //changes the index for next move
        moveIndex=(moveIndex==(moveTemplate.Count-1))?0:moveIndex+1;
    }

    //function to find new target position
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
                newTargetPos += new Vector3(0, 0, 1);
                break;
            case "left":
                newTargetPos -= new Vector3(0, 0, 1);
                break;
            case "diagonal forward right":
                newTargetPos += new Vector3(1, 0, 1);
                break;
            case "diagonal backward right":
                newTargetPos -= new Vector3(1, 0, 1);
                break;
            case "diagonal forward left":
                newTargetPos += new Vector3(-1, 0, 1);
                break;
            case "diagonal backward left":
                newTargetPos -= new Vector3(-1, 0, 1);
                break;
        }

        return newTargetPos;
    }

    //movement function
    void makeMove(Vector3 movePos,float lerpSpd){

        //check distance between points to clamp
        if (Vector3.Distance(gameObject.transform.position, movePos) < 0.01f)
        {
            gameObject.transform.position = movePos;
            return;
        }

        //lerp position
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, movePos, lerpSpd);
    }

    
}

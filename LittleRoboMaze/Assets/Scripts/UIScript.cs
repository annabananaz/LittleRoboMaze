using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Button forwardButton;
    public Button backButton;
    public Button leftButton;
    public Button rightButton;
    public Button forButton;
    public Button doneButton;
    public Button runButton;


    void Start()
    {

        forwardButton = forwardButton.GetComponent<Button>();
        backButton = backButton.GetComponent<Button>();
        leftButton = leftButton.GetComponent<Button>();
        rightButton = rightButton.GetComponent<Button>();
        forButton = forButton.GetComponent<Button>();
        doneButton = doneButton.GetComponent<Button>();
        runButton = runButton.GetComponent<Button>();

        forwardButton.onClick.AddListener(ForwardClicked);
        backButton.onClick.AddListener(BackClicked);
        leftButton.onClick.AddListener(LeftClicked);
        rightButton.onClick.AddListener(RightClicked);
        forButton.onClick.AddListener(ForClicked);
        doneButton.onClick.AddListener(DoneClicked);
        runButton.onClick.AddListener(RunClicked);

        doneButton.interactable = false;
    }

    void ForwardClicked()
    {
        Debug.Log("FORWARD clicked");
        PlayerControl.moves.Add("forward");
    }

    void BackClicked()
    {
        Debug.Log("BACK clicked");
        PlayerControl.moves.Add("back");
    }

    void LeftClicked()
    {
        Debug.Log("LEFT clicked");
        PlayerControl.moves.Add("left");
    }

    void RightClicked()
    {
        Debug.Log("RIGHT clicked");
        PlayerControl.moves.Add("right");

    }

    void ForClicked()
    {
        Debug.Log("FOR clicked");
        PlayerControl.moves.Add("for");
        forButton.interactable = false;
        doneButton.interactable = true;
        runButton.interactable = false;
    }

    void DoneClicked()
    {
        Debug.Log("DONE clicked");
        PlayerControl.moves.Add("done");
        forButton.interactable = true;
        doneButton.interactable = false;
        runButton.interactable = true;
    }

    void RunClicked()
    {
        Debug.Log("RUN clicked");
        PlayerControl.moving = true;

        //send list to playercontrol
        //let gamecontroller know to run
    }
}

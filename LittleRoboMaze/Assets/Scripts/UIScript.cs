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

    private Text commandList;
    private string commandListStr;
    private bool forActivated;

    private int numCommands;

    void Start()
    {

        numCommands = 0;

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
        commandList = FindObjectOfType<ScrollRect>().content.GetComponent<Text>();

        commandListStr = "";
        forActivated = false;

        doneButton.interactable = false;
    }

    private void Update()
    {
        commandList.text = commandListStr;
    }

    void ForwardClicked()
    {
        Debug.Log("FORWARD clicked");
        PlayerControl.moves.Add("forward");
        numCommands++;
        commandListStr += numCommands + ".\tMove forward\n";
    }

    void BackClicked()
    {
        Debug.Log("BACK clicked");
        PlayerControl.moves.Add("back");
        numCommands++;
        commandListStr += numCommands + ".\tMove back\n";
    }

    void LeftClicked()
    {
        Debug.Log("LEFT clicked");
        PlayerControl.moves.Add("left");
        numCommands++;
        commandListStr += numCommands + ".\tMove left\n";
    }

    void RightClicked()
    {
        Debug.Log("RIGHT clicked");
        PlayerControl.moves.Add("right");
        numCommands++;
        commandListStr += numCommands  + ".\tMove right\n";

    }

    void ForClicked()
    {
        Debug.Log("FOR clicked");
        PlayerControl.moves.Add("for");
        forButton.interactable = false;
        doneButton.interactable = true;
        runButton.interactable = false;
        commandListStr += "For{\n";
    }

    void DoneClicked()
    {
        Debug.Log("DONE clicked");
        PlayerControl.moves.Add("done");
        forButton.interactable = true;
        doneButton.interactable = false;
        runButton.interactable = true;
        commandListStr += "}\n";
    }

    void RunClicked()
    {
        Debug.Log("RUN clicked");
        PlayerControl.moving = true;

        //send list to playercontrol
        //let gamecontroller know to run
    }
}

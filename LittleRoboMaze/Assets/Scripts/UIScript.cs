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

    public Button clearButton;

    private Text commandListObject;
    private string commandListStr;
    private bool forActivated;

    private int numCommands;

    private List<string> commandList;

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
        clearButton = clearButton.GetComponent<Button>();

        forwardButton.onClick.AddListener(ForwardClicked);
        backButton.onClick.AddListener(BackClicked);
        leftButton.onClick.AddListener(LeftClicked);
        rightButton.onClick.AddListener(RightClicked);
        forButton.onClick.AddListener(ForClicked);
        doneButton.onClick.AddListener(DoneClicked);
        runButton.onClick.AddListener(RunClicked);
        clearButton.onClick.AddListener(ClearList);

        commandListObject = FindObjectOfType<ScrollRect>().content.GetComponent<Text>();

        commandListStr = "";
        forActivated = false;

        doneButton.interactable = false;


        commandList = new List<string>();
    }

    private void Update()
    {
        commandListObject.text = commandListStr;

        if (forActivated)
        {
            forButton.interactable = false;
            doneButton.interactable = true;
            runButton.interactable = false;
        }
        else
        {
            forButton.interactable = true;
            doneButton.interactable = false;
            runButton.interactable = true;
        }
    }

    void ForwardClicked()
    {
        Debug.Log("FORWARD clicked");
        PlayerControl.moves.Add("forward");
        numCommands++;
        commandListStr += numCommands + ".\tMove forward\n";
        commandList.Add("forward");
    }

    void BackClicked()
    {
        Debug.Log("BACK clicked");
        PlayerControl.moves.Add("back");
        numCommands++;
        commandListStr += numCommands + ".\tMove back\n";
        commandList.Add("back");
    }

    void LeftClicked()
    {
        Debug.Log("LEFT clicked");
        PlayerControl.moves.Add("left");
        numCommands++;
        commandListStr += numCommands + ".\tMove left\n";
        commandList.Add("left");
    }

    void RightClicked()
    {
        Debug.Log("RIGHT clicked");
        PlayerControl.moves.Add("right");
        numCommands++;
        commandListStr += numCommands  + ".\tMove right\n";
        commandList.Add("right");
    }

    void ForClicked()
    {
        Debug.Log("FOR clicked");
        PlayerControl.moves.Add("for");
        //forButton.interactable = false;
        //doneButton.interactable = true;
        //runButton.interactable = false;
        forActivated = true;
        commandListStr += "For{\n";
        commandList.Add("for");
    }

    void DoneClicked()
    {
        Debug.Log("DONE clicked");
        PlayerControl.moves.Add("done");
        //forButton.interactable = true;
        //doneButton.interactable = false;
        //runButton.interactable = true;
        forActivated = false;
        commandListStr += "}\n";
        commandList.Add("done");
    }

    void RunClicked()
    {
        Debug.Log("RUN clicked");
        //PlayerControl.moving = true;

        //send list to gameController
    }

    void ClearList()
    {
        commandListStr = "";
        numCommands  = 0;

        if (forActivated) { forActivated = false; }

        commandList.Clear();
    }
}

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
    public InputField loopNumberField;
    public Text alerText;
    public Button doneButton;
    public Button runButton;

    public Button clearButton;

    private Text commandListObject;
    private string commandListStr;
    private bool forActivated;

    private int numCommands;
    private bool intTaken;

    public GameObject player;
    public GameObject gameManager;
    public static int runCount;

    private List<string> commandList;

    void Start()
    {
        runCount = 0;
        numCommands = 0;

        forwardButton = forwardButton.GetComponent<Button>();
        backButton = backButton.GetComponent<Button>();
        leftButton = leftButton.GetComponent<Button>();
        rightButton = rightButton.GetComponent<Button>();
        forButton = forButton.GetComponent<Button>();
        loopNumberField = loopNumberField.GetComponent<InputField>();
        doneButton = doneButton.GetComponent<Button>();
        runButton = runButton.GetComponent<Button>();
        clearButton = clearButton.GetComponent<Button>();

        forwardButton.onClick.AddListener(ForwardClicked);
        backButton.onClick.AddListener(BackClicked);
        leftButton.onClick.AddListener(LeftClicked);
        rightButton.onClick.AddListener(RightClicked);
        forButton.onClick.AddListener(ForClicked);
        loopNumberField.onValueChanged.AddListener(delegate { GetLoopNumber(); });
        doneButton.onClick.AddListener(DoneClicked);
        runButton.onClick.AddListener(RunClicked);
        clearButton.onClick.AddListener(ClearList);

        commandListObject = FindObjectOfType<ScrollRect>().content.GetComponent<Text>();

        commandListStr = "";
        forActivated = false;
        intTaken = false;
        doneButton.interactable = false;
        alerText.enabled = false;


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
            loopNumberField.interactable = false;
        }
        else
        {
            forButton.interactable = true;
            doneButton.interactable = false;
            runButton.interactable = true;
            loopNumberField.interactable = true;
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
        if (intTaken)
        {
            Debug.Log("FOR clicked");
            PlayerControl.moves.Add("for");
            PlayerControl.moves.Add(loopNumberField.text.ToString());
            forActivated = true;
            commandListStr += "For(" + loopNumberField.text.ToString() + "){\n";
            commandList.Add("for");
            commandList.Add(loopNumberField.text.ToString());
        }
        else
        {
            Debug.Log("For loop requires number");
            alerText.enabled = true;
        }
    }

    void GetLoopNumber()
    {
        try
        {
            int loopnumber = int.Parse(loopNumberField.text.ToString());
            Debug.Log(loopnumber);
            intTaken = true;
            alerText.enabled = false;
        }
        catch
        {
            Debug.Log("Wrong input");
            intTaken = false;
            alerText.enabled = true;
        }
    }

    void DoneClicked()
    {
        Debug.Log("DONE clicked");
        PlayerControl.moves.Add("done");
        //forButton.interactable = true;
        //doneButton.interactable = false;
        //runButton.interactable = true;
        forActivated = false;
        intTaken = false;
        commandListStr += "}\n";
        commandList.Add("done");
    }

    void RunClicked()
    {
        Debug.Log("RUN clicked");
        //PlayerControl.moving = true;
        player.GetComponent<PlayerControl>().SetList(commandList);
        gameManager.GetComponent<AllMoveManager>().running = true;
        runCount++;
        loopNumberField.text = "";
        alerText.enabled = false;
    }

    void ClearList()
    {
        commandListStr = "";
        numCommands  = 0;

        if (forActivated) { forActivated = false; }

        commandList.Clear();
    }
}

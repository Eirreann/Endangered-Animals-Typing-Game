using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveText : MonoBehaviour
{
    private GameManager gameManager;
    private InputField thisInput;
    private Text placeholderText;

    [SerializeField]
    private ObjectiveObj thisObj;
    [SerializeField]
    private GameObject placeholderObj;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        thisInput = gameObject.GetComponent<InputField>();
        placeholderText = placeholderObj.GetComponent<Text>();

        placeholderText.text = thisObj.textSolution;
    }

    private void Update()
    {
        char[] typedSolution = thisInput.text.ToCharArray();
        char[] realSolution = placeholderText.text.ToCharArray();

        if (thisObj.stolen)
        {
            gameObject.SetActive(false);
            gameManager.gamePaused = false;
        }

        if (Input.anyKeyDown)
        {
            //for (int i = 0; i < typedSolution.Length; i++)
            //{
            //    if (typedSolution[i] != realSolution[i])
            //    {
            //        int charIndex = thisInput.text.IndexOf(typedSolution[i].ToString());
            //        thisInput.text = thisInput.text.Replace(thisInput.text[charIndex].ToString(), "<color=red>" + thisInput.text[charIndex].ToString() + "</color>");
            //    }
            //}
        }

    }

    public void ObjectiveSolution(string solutionText)
    {
        solutionText = thisObj.textSolution;

        if(solutionText == thisInput.text)
        {
            thisObj.solved = true;
            gameObject.SetActive(false);
            gameManager.gamePaused = false;
        }
        else
        {
            thisInput.ActivateInputField();
            thisInput.Select();
            thisInput.text = "";
        }
    }
}

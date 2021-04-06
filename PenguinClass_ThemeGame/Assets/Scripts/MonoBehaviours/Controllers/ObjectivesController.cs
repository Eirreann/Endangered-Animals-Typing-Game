using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivesController : MonoBehaviour
{
    public ObjectiveObj[] objectives;
    public Transform[] solvedLocations;
    private List<ObjectiveObj> listSolvedObjs;
    private List<ObjectiveObj> listLostObjs;
    [SerializeField]
    private GameObject winText;
    [SerializeField]
    private GameObject loseText;

    [HideInInspector]
    public bool gameOver = false;
    [HideInInspector]
    public GameObject gameOverText;

    private int resolvedObjCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        listSolvedObjs = new List<ObjectiveObj>();
        listLostObjs = new List<ObjectiveObj>();
    }

    // Update is called once per frame
    void Update()
    {
        if(resolvedObjCount >= objectives.Length && !gameOver)
        {
            CheckWinConditions();
            Invoke("WinCondition", 3f);
            gameOver = true;
        }
    }

    public void AddResolvedObject(ObjectiveObj thisObj, bool isSolved)
    {
        if (isSolved)
        {
            if (!listSolvedObjs.Contains(thisObj))
            {
                resolvedObjCount += 1;
                listSolvedObjs.Add(thisObj);
            }
        }
        else if (!isSolved)
        {
            if (!listLostObjs.Contains(thisObj))
            {
                resolvedObjCount += 1;
                listLostObjs.Add(thisObj);
            }
        }
        else
        {
            return;
        }

        //Debug.Log("resolved objectives: " + resolvedObjCount);
    }

    public void CheckWinConditions()
    {
        int solvedObjs = 0;
        int lostObjs = 0;

        foreach (ObjectiveObj objective in objectives)
        {
            if (listSolvedObjs.Contains(objective))
                solvedObjs++;
            else if (listLostObjs.Contains(objective))
                lostObjs++;
        }

        gameOverText = (solvedObjs >= lostObjs) ? winText : loseText;
    }

    private void WinCondition()
    {
        gameOverText.SetActive(true);
    }
}

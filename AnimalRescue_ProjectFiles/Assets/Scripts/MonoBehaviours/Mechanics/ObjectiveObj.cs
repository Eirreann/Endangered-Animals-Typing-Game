using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveObj : MonoBehaviour
{
    public GameObject targetText;
    public Transform solvedLoc;
    public bool solved = false;
    public bool stolen = false;
    private bool stored = false;
    public string textSolution;

    public GameObject nextObj;
    public GameObject solvedText;
    public GameObject lostText;

    private Collider2D col;
    [HideInInspector] public SpriteRenderer spr;
    //private float fadeAmount = 0.75f;

    private ObjectivesController objController;
    private EnemyController enemy;
    static private int stolenLocNum = 0;
    static private int solvedLocNum = 0;

    [HideInInspector]
    public bool isAssessed = false;

    private void Start()
    {
        col = GetComponent<Collider2D>();
        spr = GetComponent<SpriteRenderer>();
        objController = GetComponentInParent<ObjectivesController>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>();

        if(FindObjIndex(this) < objController.objectives.Length - 1)
            nextObj = objController.objectives[FindObjIndex(this) + 1].gameObject;
        else
            nextObj = objController.objectives[0].gameObject;
    }

    private void Update()
    {
        if (solved && !stored)
        {
            if(enemy.targetObj == this.gameObject)
                UpdateEnemy(nextObj);

            MoveObject(true);
            objController.AddResolvedObject(this, true);
            DisplayText(true);
            solvedLocNum++;

            col.enabled = false;
            //spr.color = new Color(spr.color.r, spr.color.g, spr.color.b);
            stored = true;
        }
        else if (stolen && !stored)
        {
            if (enemy.targetObj == this.gameObject)
                UpdateEnemy(nextObj);

            MoveObject(false);
            objController.AddResolvedObject(this, false);
            DisplayText(false);
            stolenLocNum++;

            col.enabled = false;
            //spr.color = new Color(spr.color.a, spr.color.g/2, spr.color.b/2, fadeAmount);
            stored = true;
        }

        if (objController.gameOver)
        {
            stolenLocNum = 0;
            solvedLocNum = 0;
        }
    }

    private void DisplayText(bool status)
    {
        if (status)
        {
            solvedText.SetActive(true);
            objController.ScoreText.color = Color.green;
            Invoke("SolvedText", 3f);
        }
                
        else if (!status)
        {
            lostText.SetActive(true);
            objController.ScoreText.color = Color.red;
            Invoke("LostText", 3f);
        }
    }

    private void UpdateEnemy(GameObject targetObj)
    {
        ObjectiveObj targetObjScript = targetObj.GetComponent<ObjectiveObj>();

        if (targetObjScript.stored)
        {
            for(var i = FindObjIndex(targetObjScript); i < objController.objectives.Length; i++)
            {
                if (!objController.objectives[i].stored)
                {
                    enemy.ResetEnemy(objController.objectives[i].gameObject);
                    return;
                }
            }
        }
        else
        {
            enemy.ResetEnemy(targetObj);
        }
    }

    private void MoveObject(bool solved)
    {
        if (solved)
        {
            transform.position = objController.solvedLocations[solvedLocNum].position;
            transform.localScale = objController.solvedLocations[solvedLocNum].localScale;
            transform.parent = objController.solvedLocations[solvedLocNum];
        }
        else if (!solved)
        {
            transform.position = enemy.stolenLocations[stolenLocNum].position;
            transform.localScale = enemy.stolenLocations[stolenLocNum].localScale;
            transform.parent = enemy.stolenLocations[stolenLocNum];
        }
    }

    private int FindObjIndex(ObjectiveObj target)
    {
        for (int i = 0; i < objController.objectives.Length; i++)
        {
            if (objController.objectives[i] == target)
            {
                return i;
            }
        }

        return -1;
    }

    private void SolvedText()
    {
        solvedText.SetActive(false);
        objController.ScoreText.color = Color.white;
        
    }

    private void LostText()
    {
        lostText.SetActive(false);
        objController.ScoreText.color = Color.white;
    }
}

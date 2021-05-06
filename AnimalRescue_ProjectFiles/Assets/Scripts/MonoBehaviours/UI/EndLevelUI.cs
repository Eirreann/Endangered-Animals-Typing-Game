using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndLevelUI : MonoBehaviour
{
    private EnemyController _enemyController;
    private ObjectivesController _objController;

    public GameObject SolvedAnimalsPanel;
    private GameObject[] _solvedAnimals;

    public GameObject LostAnimalsPanel;
    private GameObject[] _lostAnimals;

    public void AssessPerformance()
    {
        _enemyController = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>();
        _objController = GetComponent<ObjectivesController>();

        _solvedAnimals = GameObject.FindGameObjectsWithTag("SolvedAnimal");
        _lostAnimals = GameObject.FindGameObjectsWithTag("LostAnimal");

        CheckLists(_solvedAnimals, _objController.listSolvedObjs, false);
        //for (int i = 0; i < _solvedAnimals.Length; i++)
        //{
        //    if (i < _objController.listSolvedObjs.Count && !_objController.listSolvedObjs[i].isAssessed)
        //    {
        //        ChangeSpriteInfo(_solvedAnimals[i], _objController.listSolvedObjs[i]);
        //    }
        //    else if (i >= _objController.listSolvedObjs.Count)
        //    {
        //        _solvedAnimals[i].SetActive(false);
        //    }
        //}

        CheckLists(_lostAnimals, _objController.listLostObjs, true);
        //for (int i = 0; i < _lostAnimals.Length; i++)
        //{
        //    if (i < _objController.listLostObjs.Count && !_objController.listLostObjs[i].isAssessed)
        //    {
        //        ChangeSpriteInfo(_lostAnimals[i], _objController.listLostObjs[i]);
        //    }
        //    else if (i >= _objController.listLostObjs.Count)
        //    {
        //        _lostAnimals[i].SetActive(false);
        //    }
        //}
    }

    private void CheckLists(GameObject[] array, List<ObjectiveObj> objectives, bool colourTrigger)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (i < objectives.Count && !objectives[i].isAssessed)
            {
                ChangeSpriteInfo(array[i], objectives[i], colourTrigger);
            }
            else if (i >= objectives.Count)
            {
                array[i].SetActive(false);
            }
        }
    }

    private void ChangeSpriteInfo(GameObject target, ObjectiveObj subject, bool changeColour)
    {
        target.GetComponent<Image>().sprite = subject.spr.sprite;
        target.GetComponentInChildren<TextMeshProUGUI>().text = subject.textSolution;

        if (changeColour)
        {
            target.GetComponent<Image>().color = Color.red;
            //target.GetComponentInChildren<TextMeshProUGUI>().color = Color.red;
        }
    }

}

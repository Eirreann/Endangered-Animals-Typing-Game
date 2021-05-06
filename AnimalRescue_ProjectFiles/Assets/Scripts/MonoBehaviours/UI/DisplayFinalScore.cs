using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayFinalScore : MonoBehaviour
{
    private ObjectivesController _objectivesController;
    public Text FinalScoreText;

    private void Start()
    {
        _objectivesController = GameObject.FindGameObjectWithTag("ObjectivesController").GetComponent<ObjectivesController>();
    }

    // Update is called once per frame
    void Update()
    {
        FinalScoreText.text = _objectivesController.Score.ToString();

        if (_objectivesController.Score >= _objectivesController.listSolvedObjs.Count / 2)
            FinalScoreText.color = Color.green;
        else if(_objectivesController.Score < _objectivesController.listSolvedObjs.Count / 2)
            FinalScoreText.color = Color.yellow;
        else if(_objectivesController.Score < 0)
            FinalScoreText.color = Color.red;
    }
}

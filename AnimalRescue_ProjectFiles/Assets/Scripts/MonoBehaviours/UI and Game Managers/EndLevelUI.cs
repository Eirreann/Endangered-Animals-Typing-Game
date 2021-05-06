using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelUI : MonoBehaviour
{
    public EnemyController EnemyController;
    private ObjectivesController _objController;

    public GameObject SolvedAnimalsPanel;
    private GameObject[] _solvedAnimals;

    public GameObject LostAnimalsPanel;
    private GameObject[] _lostAnimals;

    // Start is called before the first frame update
    void Start()
    {
        _objController = GetComponent<ObjectivesController>();

        
    }

    
}

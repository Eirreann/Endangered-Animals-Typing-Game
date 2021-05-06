using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateAvatars : MonoBehaviour
{
    [SerializeField]
    private GameObject[] avatarButtons;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject button in avatarButtons)
        {
            Image bImg = button.GetComponent<Image>();
            Text bText = button.GetComponentInChildren<Text>();


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

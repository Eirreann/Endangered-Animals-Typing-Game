using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private GameManager gameManager;

    private Sprite thisButtonAvatar;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        thisButtonAvatar = GetComponent<Image>().sprite;
    }

    public void StartGameWithAvatar()
    {
        gameManager.playerAvatar = thisButtonAvatar;

        SceneManager.LoadScene("01_LevelOne");
    }
}

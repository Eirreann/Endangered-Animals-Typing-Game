using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    [Range(0, 2)]
    private float enemySpd = 1f;

    public GameObject targetObj;
    public GameObject winText;
    public Transform[] stolenLocations;

    private SpriteRenderer enemySpr;
    private CircleCollider2D enemyColl;
    private Animator enemyAnim;

    private Vector3 startingPos;
    private Vector3 startingRot;
    private GameManager gameManager;
    private ObjectivesController objController;

    private void Start()
    {
        startingPos = transform.position;
        startingRot = transform.rotation.eulerAngles;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        objController = GameObject.FindGameObjectWithTag("ObjectivesController").GetComponent<ObjectivesController>();
        enemySpr = GetComponentInChildren<SpriteRenderer>();
        enemyColl = GetComponent<CircleCollider2D>();
        enemyAnim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (transform.position != targetObj.transform.position && !objController.gameOver)
        {
            //transform.position = Vector3.Lerp(transform.position, targetObj.transform.position, enemySpd/1000f);
            transform.position = Vector3.MoveTowards(transform.position, targetObj.transform.position, enemySpd * Time.deltaTime);
        }  
        else if(objController.gameOver)
        {
            GameOverEnemy();
        }
    }

    public void ResetEnemy(GameObject newTarget)
    {
        targetObj = newTarget;
    }

    private void GameOverEnemy()
    {
        enemySpr.enabled = false;
        enemyColl.enabled = false;
        enemyAnim.enabled = false;

        transform.position = startingPos;
        transform.rotation = Quaternion.Euler(startingRot);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == targetObj)
        {
            collision.GetComponent<ObjectiveObj>().stolen = true;
        }
        else
        {
            return;
        }
    }
}

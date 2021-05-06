using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    private SpriteRenderer playerSprite;
    private Rigidbody2D rb;

    //private bool moveHorizontal = false;
    //private bool moveVertical = false;

    [SerializeField]
    private float moveSpd = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        playerSprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        if(gameManager != null)
            playerSprite.sprite = gameManager.playerAvatar;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        if(!gameManager.gamePaused)
            transform.position += movement * moveSpd * Time.deltaTime;

        if (movement.x == 0)
            rb.velocity = new Vector2(0f, rb.velocity.y);
        else if(movement.y == 0)
            rb.velocity = new Vector2(rb.velocity.x, 0f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Objective"))
        {
            ObjectiveObj thisObj = collision.GetComponent<ObjectiveObj>();

            if (!thisObj.solved)
            {
                thisObj.targetText.SetActive(true);
                gameManager.gamePaused = true;

                if(thisObj.targetText.GetComponent<ObjectiveText>().enabled)
                {
                    InputField targetInput = thisObj.targetText.GetComponent<InputField>();
                    targetInput.Select();
                }
            }
        }
    }
}

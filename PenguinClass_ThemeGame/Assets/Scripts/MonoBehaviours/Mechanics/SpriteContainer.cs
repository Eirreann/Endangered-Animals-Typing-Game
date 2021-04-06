using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteContainer : MonoBehaviour
{
    public Sprite activatedSprite;
    [HideInInspector]
    public Sprite deactivatedSprite;

    private void Start()
    {
        deactivatedSprite = GetComponent<SpriteRenderer>().sprite;
    }
}

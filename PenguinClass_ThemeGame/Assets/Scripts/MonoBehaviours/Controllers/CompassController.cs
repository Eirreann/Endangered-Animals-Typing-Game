using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassController : MonoBehaviour
{
    [Header("Cardinal Directions")]
    public GameObject north;
    public GameObject south;
    public GameObject east;
    public GameObject west;
    [Space]
    [Header("Ordinal Directions")]
    public GameObject northEast;
    public GameObject northWest;
    public GameObject southEast;
    public GameObject southWest;

    private float inputOffset = 0.25f;

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        if (h > inputOffset)
            SwitchSprite(east, true);
        else if (h < -inputOffset)
            SwitchSprite(west, true);
        else
        {
            SwitchSprite(east, false);
            SwitchSprite(west, false);
        }

        if (v > inputOffset)
            SwitchSprite(north, true);
        else if (v < -inputOffset)
            SwitchSprite(south, true);
        else
        {
            SwitchSprite(north, false);
            SwitchSprite(south, false);
        }

        if (h > inputOffset && v > inputOffset)
        {
            SwitchSprite(northEast, true);
            SwitchSprite(north, false);
            SwitchSprite(east, false);
        }
        else if (h > inputOffset && v < -inputOffset)
        {
            SwitchSprite(southEast, true);
            SwitchSprite(south, false);
            SwitchSprite(east, false);
        }
        else if (h < -inputOffset && v > inputOffset)
        {
            SwitchSprite(northWest, true);
            SwitchSprite(north, false);
            SwitchSprite(west, false);
        }
        else if (h < -inputOffset && v < -inputOffset)
        {
            SwitchSprite(southWest, true);
            SwitchSprite(south, false);
            SwitchSprite(west, false);
        }
        else
        {
            SwitchSprite(northEast, false);
            SwitchSprite(southEast, false);
            SwitchSprite(northWest, false);
            SwitchSprite(southWest, false);
        }
    }

    private void SwitchSprite(GameObject direction, bool activated)
    {
        SpriteRenderer dirRend = direction.GetComponent<SpriteRenderer>();
        SpriteContainer dirCont = direction.GetComponent<SpriteContainer>();

        if (activated)
            dirRend.sprite = dirCont.activatedSprite;
        else
            dirRend.sprite = dirCont.deactivatedSprite;
    }
}

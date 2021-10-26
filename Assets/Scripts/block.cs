using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    //config parameters
    [SerializeField] int maxhits;
    [SerializeField] int hits; //for debug purposes
    [SerializeField] Sprite[] nextsprite;
    [SerializeField]AudioClip blkbrksound;
    [SerializeField] GameObject ptklFX;
    //cached ref
    Level level;
    gamestatus gamestat;

  
    private void Start()
    {
        countbreakableblocks();

    }

    private void countbreakableblocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "breakable block")
        {
            level.countblocks();
        }
        gamestat = FindObjectOfType<gamestatus>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "breakable block")
        {
            handlehit();
        }
    }

    private void handlehit()
    {
        hits++;
        if (hits >= maxhits)
        {
            destroyblock();
        }
        else
        {
            showdestroyedsprite();
        }
    }

    private void showdestroyedsprite()
    {
        GetComponent<SpriteRenderer>().sprite = nextsprite[hits - 1];
    }

    private void destroyblock()
    {
        Destroy(gameObject);
        triggerptkleffect();
        AudioSource.PlayClipAtPoint(blkbrksound, Camera.main.transform.position);
        level.blocksdestroyed();
        gamestat.addscore();

    }
    private void triggerptkleffect()
    {
        GameObject sparkles = Instantiate(ptklFX, transform.position, transform.rotation);
        Destroy(sparkles,2f);    
    }

}

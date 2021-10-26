using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int BreakableBlocks;
    ScreenLoader screenLoader;   //cached reference 
    private void Start()
    {
        screenLoader = FindObjectOfType<ScreenLoader>();
    }
    public void countblocks()
    {
        BreakableBlocks++;
    }
    public void blocksdestroyed()
    {
        BreakableBlocks--;
        if (BreakableBlocks <= 0) 
        {
            screenLoader.LoadNextScene();
        }
    }

}

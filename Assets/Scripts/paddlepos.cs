using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class paddlepos : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int screenwidunits;
    [SerializeField] float xmin;
    [SerializeField] float xmax;
    //cached references
    ball ballpos;
    gamestatus gamestat;
    void Start()
    {
        ballpos = FindObjectOfType<ball>();
        gamestat = FindObjectOfType<gamestatus>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlepos = new Vector2(transform.position.x, transform.position.y);
        paddlepos.x = Mathf.Clamp(Xpos(), xmin, xmax);
        transform.position = paddlepos;
    }
    private float Xpos()
    {
        if (!(!gamestat.isAutoplayenabled() || !ballpos.launched()))
        {
            return ballpos.transform.position.x;
        }
        else
        {
           return (Input.mousePosition.x / Screen.width * screenwidunits);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.GameCenter;

public class gamestatus : MonoBehaviour
{
    //config parameters
    [Range(0.1f,5f)][SerializeField] float gamespeed = 1f;
    [SerializeField] int pointsperblock =50;
    [SerializeField] int Score=0;
    [SerializeField] TextMeshProUGUI TMPscore;
    [SerializeField] bool Autoplay;
    public void Awake()
    {
        int scriptcount = FindObjectsOfType<gamestatus>().Length;
        if(scriptcount>1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void Start()
    {
        TMPscore.text = Score.ToString();
    }
    public void Update()
    {
        Time.timeScale = gamespeed;
    }

    public void addscore()
    {
        Score += pointsperblock;
        TMPscore.text = Score.ToString();
    }
    public void resetscore()
    {
        Destroy(gameObject);
    }
    public bool isAutoplayenabled()
    {
        return Autoplay;
    }


}

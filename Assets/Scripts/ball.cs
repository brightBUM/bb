
using TMPro;
using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField] paddlepos paddle1;
    bool hastarted = false;
    Vector2 paddletoballvector;
    [SerializeField] float xpush;
    [SerializeField] float ypush;
    [SerializeField] AudioClip[] ballsound;
    [SerializeField] float randomfactor = 0.2f;
    //cache reference
    AudioSource myaudiosource;
    Rigidbody2D myrigidbody;

    // Start is called before the first frame update

    void Start()
    {
        paddletoballvector = transform.position - paddle1.transform.position;
        myaudiosource = GetComponent<AudioSource>();
        myrigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hastarted != true)
        {
            lockballtopaddle();
            launchOnclick();
        }
       
    }

    private void launchOnclick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myrigidbody.velocity = new Vector2(xpush,ypush);
            hastarted = true;
        }
            
    }

    private void lockballtopaddle()
    {
        Vector2 paddlepos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = (paddlepos + paddletoballvector);
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocitytweak = new Vector2
            (Random.Range(0, randomfactor),
            Random.Range(0, randomfactor));
        if (hastarted)
        {
            myrigidbody.velocity += velocitytweak;
            AudioClip clip = ballsound[UnityEngine.Random.Range(0, ballsound.Length)];
            myaudiosource.PlayOneShot(clip);       
        }
    }
    public bool launched()
    {
        return hastarted;
    }
}

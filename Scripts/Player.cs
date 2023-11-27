using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Up;
    public KeyCode Down;

    public KeyCode attack;

    public Transform spwanpoint;
    public GameObject wave;
    public Rigidbody2D rigid;
    private Animator anim;
    private SpriteRenderer sprite;
 

    // Start is called before the first frame update
    void Start()
    {
       rigid = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
       
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(attack)) 
        { 
            GameObject waveattack = Instantiate(wave,spwanpoint.position,spwanpoint.rotation);
            waveattack.transform.position = transform.localScale;
            anim.SetTrigger("Attack");
        }
        Movement();
       
    }
    void Movement()
    {
        if (Input.GetKey(Left))
        {
            rigid.velocity = new Vector2(-speed, rigid.velocity.y);
            transform.localScale = new Vector3(-3, 3, 3);
        }
        else if (Input.GetKey(Right))
        {
            rigid.velocity = new Vector2(speed, rigid.velocity.y);
            transform.localScale = new Vector3(3,3,3);
        }
        else if (Input.GetKey(Up))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, speed);
        }
        else if (Input.GetKey(Down))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, -speed);
        }
        else
        {
            rigid.velocity = new Vector2(0f, 0f);
        }

        anim.SetFloat("Run", Mathf.Abs(rigid.velocity.x));
        anim.SetFloat("Walk", Mathf.Abs(rigid.velocity.y));
    }
   
}
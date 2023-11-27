using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blade : MonoBehaviour
{
    Rigidbody2D rigd;
    public float speed = 5f;
    public GameObject bladeeffect;


    // Start is called before the first frame update
    void Start()
    {
        rigd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigd.velocity = new Vector2(speed * transform.localScale.x, 0);
    }
    void Ontrigger2D(Collider2D other)
    {
        Instantiate(bladeeffect, transform.position, transform.rotation);
        Destroy(this.gameObject);
        
    }
}

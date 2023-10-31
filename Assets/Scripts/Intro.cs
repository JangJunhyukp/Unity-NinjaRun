using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public GameObject TitleUI;
    public GameObject targetPosition;
    private Rigidbody2D Rigid;
    public AudioClip jumpsound;
    
    // Start is called before the first frame update
    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
        Invoke("ani", 5f);
        Invoke("title", 5f);
        Invoke("sound", 5f);
        Invoke("Tsound", 7f);
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        if (targetPosition != null)
        {
            transform.position =
                Vector2.MoveTowards(gameObject.transform.position, targetPosition.transform.position, 1f * Time.deltaTime);
            
        }
    }

    public void ani()
    {
        Rigid.AddForce(new Vector2(0, 500f));
        GetComponent<Animator>().SetTrigger("Double");
    }

    public void title()
    {
        TitleUI.SetActive(true);
    }

    public void sound()
    {
        GetComponent<AudioSource>().PlayOneShot(jumpsound);
    }

    public void Tsound()
    {
        GetComponent<AudioSource>().Play();
    }
}

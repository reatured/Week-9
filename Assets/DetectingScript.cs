using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DetectingScript : MonoBehaviour
{
    public TextMeshProUGUI collisionDetect;
    public GameObject head, tail, expHead, expTail;
    public Animator anim;
    //public BoxCollider head, tail;
    // Start is called before the first frame update
    void Start()
    {
        collisionDetect.SetText("No Collision");
        head.SetActive(false);
        tail.SetActive(false);
        expHead.SetActive(false);
        expTail.SetActive(false);

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Head")
        {
            collisionDetect.SetText("Yes Collision, Head");
            Destroy(this.gameObject);
            expHead.SetActive(true);
            head.SetActive(true);

            anim.SetTrigger("Drive");
        }
        else if(other.name == "Tail")
        {

            collisionDetect.SetText("Yes Collision, Tail");
            Destroy(this.gameObject);
            expTail.SetActive(true);
            tail.SetActive(true);

            anim.SetTrigger("Drive");
        }

        Debug.Log("Collision happens");

        

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody rigidbody;
    float speed = 1400;
    bool left = false;

    Vector3 defaultvector;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        defaultvector = Vector3.zero;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "end")
        {
            Invoke("gameoverfunc", 2f);
        }
        if(other.tag=="diamond")
        {
            FindObjectOfType<Gamemanger>().increasscore();
            Destroy(other.gameObject);
        }
    }
    void gameoverfunc()
    {
        Time.timeScale = 0;
        FindObjectOfType<Gamemanger>().showwhitscreen();
    }
    void Update()
    {

        rigidbody.AddForce(defaultvector * Time.deltaTime *speed);
        if(Input.GetKeyDown(KeyCode.Space)&& !left)
        {

            defaultvector = Vector3.left;
            left = true;
        }
        else if(Input.GetKeyDown(KeyCode.Space)&& left)
        {
            defaultvector = Vector3.forward;
            left = false;
        }
    }
}

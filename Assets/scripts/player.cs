using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
   [SerializeField] GameObject particls;
    Rigidbody rigidbody;
    float speed = 1700;
    bool left = false;
    Gamemanger gamemanger;
    Vector3 defaultvector;
    bool isgameover;
    private void Start()
    {
        isgameover = false;
        rigidbody = GetComponent<Rigidbody>();
        defaultvector = Vector3.zero;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "end")
        {
            isgameover = true;
            Invoke("gameoverfunc", 1f);
            Time.timeScale = 0.5f;
        }
        if(other.tag=="diamond")
        {
            FindObjectOfType<Gamemanger>().increasscore();
            Destroy(other.gameObject);
            FindObjectOfType<AudioManger>().play("Diamond");
            GameObject currentparticle = Instantiate(particls, other.transform.position, Quaternion.identity);
            Destroy(currentparticle, 2f);
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
        if(defaultvector == Vector3.zero)
        {
            print("Sadfsghjh");
            Time.timeScale = 0;
        }
        else
        {
            if(!isgameover)
               Time.timeScale = 1;

        }
        
        if(Input.touchCount > 0&&Input.GetTouch(0).phase ==TouchPhase.Ended  && !left)
        {

            defaultvector = Vector3.left;
            
                  FindObjectOfType<AudioManger>().play("click");
            left = true;
        }
        else if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && left)
        {
            defaultvector = Vector3.forward;

            FindObjectOfType<AudioManger>().play("click");
            left = false;
        }
    }
}

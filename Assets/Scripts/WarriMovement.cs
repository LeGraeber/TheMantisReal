using UnityEngine;
using System.Collections;

public class WarriMovement : MonoBehaviour {

    public bool runsRight;
    public float warriSpeed;
    public Renderer rend;

    void Start()
    {
        if(gameObject.transform.position.x < 0)
        {
            runsRight = true;
        }
        else
        {
            runsRight = false;
        }

        warriSpeed = Random.Range(10, 30);
    }

    void Update()
    {
       
        WarriMovementChecker();
    }


    //die bewegung links und rechts
    void WarriMovementChecker()
    {
        if (runsRight== true)
        {
            rend.transform.Translate(Vector2.right * Time.deltaTime * warriSpeed);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (runsRight == false)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            rend.transform.Translate(Vector2.right * Time.deltaTime * warriSpeed);

        }

    }
    

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }

        
    }
}

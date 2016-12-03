using UnityEngine;
using System.Collections;

public class JumperMovement : MonoBehaviour {

    public int i = 1;

    // Use this for initialization
    void Start () {
        
	}

    // Update is called once per frame
    void Update()
    {

        if (i <= 100) { 
            transform.Translate(Vector2.up * Time.deltaTime*5);
            i++;

        }
        else if (i > 100 && i <200)
        {
            transform.Translate(Vector2.down * Time.deltaTime*5);
            i++;
        }
        else if(i == 200)
        {
            i = 1;
            i++;
        }
	}

    public void jumperDeath()
    {
        Destroy(gameObject);
    }
}

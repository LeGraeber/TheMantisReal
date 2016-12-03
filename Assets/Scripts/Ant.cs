using UnityEngine;
using System.Collections;

public class Ant : MonoBehaviour {

    public GameObject playerScript;
    public GameObject me;
    public Camera myCam;
	// Use this for initialization
	
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("hallos");
        playerScript.GetComponent<player>().killCounter++;
        
        Destroy(gameObject);
        myCam.GetComponent<CamFollow>().ShakeCamera(0.05f, 0.1f);

        if (playerScript.GetComponent<player>().killCounter % 20 == 0)
        {
            playerScript.GetComponent<player>().lives++;
        }
    }
	
	
}

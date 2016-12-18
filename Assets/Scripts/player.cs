using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class player : MonoBehaviour {

    public Renderer rend;
    public GameObject Player;
    public GameObject lvlManager;
    

    public Camera myCam;

    public int killCounter;

    public bool runsRight = true;
    public bool grounded = false;
    public float jumpForce = 2000;
    public float speed = 0.35f;
    public bool triggerActive = false;
    public bool triggerActive2 = false;
    public bool triggerActive3 = false;
    public bool triggerActive4 = false;

    public GameObject ground;

    public int lives = 2;

    // Update is called once per frame
    void Update()
    {
        runnerMovement();
        runnerMovementChecker(); 
    }
		
    //die bewegung links und rechts
    void runnerMovementChecker()
    {
        if (runsRight)
            {
                rend.transform.Translate(Vector2.right * Time.deltaTime * speed);
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else if (runsRight==false)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                rend.transform.Translate(Vector2.right * Time.deltaTime* speed);
                
            }
     
        
       
    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.name == "RightWall")
        {
            runsRight = false;

        }
        else if (coll.gameObject.name == "LeftWall")
        {
            runsRight = true;

        }
        else if (coll.gameObject.name == "Plant")
        {
            mantisDeath();
        }

        else if(coll.gameObject.name == "Antwarrior(Clone)")
        {
            mantisDeath();
        }

        else if(coll.gameObject.name == "Antjumper")
        {
            mantisDeath();
        }

       

        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Uparrow")
        {
            triggerActive = true;
          
        }

       else if(col.name == "Downarrow")
        {
            triggerActive2 = true;
        }

        else if ( col.name == "TriggerLadder")
        {
            ground.GetComponent<Collider2D>().enabled = false;
            
        }

        else if (col.name == "UpArrowBot")
        {
            triggerActive4 = true;
        }
        else if (col.name == "DownArrowBot")
        {
            triggerActive3 = true;
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "Uparrow")
        {
         triggerActive = false;
        }
        else if (col.name == "Downarrow")
        {
            triggerActive2 = false;
        }

        else if(col.name == "DownArrowBot")
        {
            triggerActive3 = false;
        }
        else if (col.name == "UpArrowBot")
        {
            triggerActive4 = false;
        }

    }


    void runnerMovement()
    {   //jump
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            Player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
        }

        //teleport in Level 2
        else if (triggerActive && (Input.GetKey("w")))
        {
            gameObject.transform.Translate(new Vector2(0, 43.5f));
            triggerActive = false;
            lvlManager.GetComponent<LevelManager>().LoadLevel2();
        }
        //teleport in Level 1
        else if (triggerActive2 && (Input.GetKey("s")))
        {
            gameObject.transform.Translate(new Vector2(0, -43.5f));
            triggerActive2 = false;
            lvlManager.GetComponent<LevelManager>().LoadLevel1();
        
        }

        else if (triggerActive3 && (Input.GetKey("s")))
        {
            gameObject.transform.Translate(new Vector2(0, -43.5f));
            triggerActive3 = false;
            lvlManager.GetComponent<LevelManager>().LoadLevel3();

        }
        else if (triggerActive4 && (Input.GetKey("w")))
        {
            gameObject.transform.Translate(new Vector2(0, 43.5f));
            triggerActive4 = false;
            lvlManager.GetComponent<LevelManager>().LoadLevel1();

        }

      





        /* if (runsRight)
              rend.transform.Translate(Vector2.up * Time.deltaTime * jumpForce);
          // Player.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, jumpForce));
          else if (!runsRight)
              Player.GetComponent<Rigidbody2D>().AddForce(Vector2.up*jumpForce);
      }*/

        else if (Input.GetKey("a"))
        {
           
            runsRight = false;
        }
        else if (Input.GetKey("d"))
        {
           
            runsRight = true;
        }

    }

    void mantisDeath()
    {
        lives = lives - 1;
        if (lives < 0)
        {
            SceneManager.LoadScene(0);
        }

        myCam.GetComponent<CamFollow>().ShakeCamera(0.05f, 0.4f);
    }


}

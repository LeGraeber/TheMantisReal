using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {

    

     public Transform target;
     public Camera myCam;
     public GameObject playerScript;

     public float minY;
     public float maxY;

     public float minX;
     public float maxX;

    public float shakeTimer;
    public float shakeAmount;
     // Use this for initialization
     void Start () {
         myCam = GetComponent<Camera>();

     }

     // Update is called once per frame



     void Update() {
      //  myCam.orthographicSize = (Screen.height / 100f) / 2f;

     

         if (target) { 
             if (playerScript.GetComponent<player>().runsRight)
             {
                 transform.position =  Vector3.Lerp(transform.position, target.position, 0.08f) + new Vector3(1.6f, 0.6f, -40);
             }
             else if (playerScript.GetComponent<player>().runsRight == false)
             {
                 transform.position = Vector3.Lerp(transform.position, target.position, 0.08f) + new Vector3(-1.6f, 0.6f, -40);
            //     transform.position = new Vector3(Mathf.Clamp(target.position.x - 10,minX, maxX), Mathf.Clamp(target.position.y + 10, minY, maxY), transform.position.z);
             }
         }
        //     transform.position = new Vector3(Mathf.Clamp(target.position.x - 10, minX, maxX), Mathf.Clamp(target.position.y + 10, minY, maxY), transform.position.z);
        if (shakeTimer >= 0)
        {
            Vector2 ShakePos = Random.insideUnitCircle;

            transform.position = new Vector3(transform.position.x + ShakePos.x, transform.position.y + ShakePos.y, transform.position.z);

            shakeTimer -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            ShakeCamera(0.05f, 0.1f);
        }
    }

    

    public void ShakeCamera(float shakePwr, float shakeDur)
    {
        shakeAmount = shakePwr;
        shakeTimer = shakeDur;
    }












    /*
    public GameObject playerScript;

    public Camera myCam;
    public Transform Player;
    public Vector2
   
        Margin,
        Smoothing;

    public BoxCollider2D Bounds;

    private Vector3
        _min,
        _max;

     public bool IsFollowing { get; set; }

    public void Start()
    {
        myCam = GetComponent<Camera>();

        _min = Bounds.bounds.min;
        _max = Bounds.bounds.max;

        IsFollowing = true;
    }

    public void Update()
    {
        if (playerScript.GetComponent<player>().runsRight)
        {
            var x = transform.position.x + 1;
            var y = transform.position.y;
            if (IsFollowing)
            {
                if (Mathf.Abs(x - Player.position.x) > Margin.x)
                {
                    x = Mathf.Lerp(x, Player.position.x, Smoothing.x * Time.deltaTime);
                }
                if (Mathf.Abs(y - Player.position.y) > Margin.y)
                {
                    y = Mathf.Lerp(y, Player.position.y, Smoothing.y * Time.deltaTime);

                }
            }

            var cameraHalfWidth = myCam.orthographicSize * ((float)Screen.width / Screen.height);

            x = Mathf.Clamp(x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
            y = Mathf.Clamp(y, _min.y + myCam.orthographicSize, _max.y - myCam.orthographicSize);

            transform.position = new Vector3(x, y, transform.position.z);

        }

        else if (!playerScript.GetComponent<player>().runsRight)
        {
            var x = transform.position.x - 1;
            var y = transform.position.y;

            if (IsFollowing)
            {
                if (Mathf.Abs(x - Player.position.x) > Margin.x)
                {
                    x = Mathf.Lerp(x, Player.position.x, Smoothing.x * Time.deltaTime);
                }
                if (Mathf.Abs(y - Player.position.y) > Margin.y)
                {
                    y = Mathf.Lerp(y, Player.position.y, Smoothing.y * Time.deltaTime);

                }
            }

            var cameraHalfWidth = myCam.orthographicSize * ((float)Screen.width / Screen.height);

            x = Mathf.Clamp(x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
            y = Mathf.Clamp(y, _min.y + myCam.orthographicSize, _max.y - myCam.orthographicSize);

            transform.position = new Vector3(x, y, transform.position.z);

        }
    }*/
}

        
   


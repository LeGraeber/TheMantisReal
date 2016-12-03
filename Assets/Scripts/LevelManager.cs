using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject prefab;
    public GameObject prefabWarri;
    public GameObject prefabJumper;

    public int anzAnts;


	// Use this for initialization
	void Start () {

        LoadLevel1();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

   
    void createAnts(float height)
    {
        for (int i = 0; i < anzAnts; i++)

            Instantiate(prefab, new Vector3(Random.Range(-70.0f, 70.0f), height, 0), Quaternion.identity);
    }
    

    void createWarri()
    {
        //creates Warriors
        Instantiate(prefabWarri, new Vector3(-110, 2.7f, -201), Quaternion.identity);
        Instantiate(prefabWarri, new Vector3(125, 2.7f, -201), Quaternion.identity);
    }


    void createJumper()
    {

    }

    public void LoadLevel1()
    {

        createWarri();
        createAnts(3.02f);  
    }

    public void LoadLevel2()
    {
        createAnts(43.62f);
        createJumper();
    }

    public void LoadLevel3()
    {
        createAnts(-39.68f);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Queue for the three draggable blocks at 
 * the bottom of the screen.
 */
public class queue : MonoBehaviour
{

    [SerializeField]
    private GameObject[] waypoints;
    public List<GameObject> currentBlocks;
    private GameObject b;
    public GameObject block;
    // Start is called before the first frame update
    void Start()
    {
       
        if(block != null)
        {
             createQueue();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /**
     * Creates three blocks in designated places 
     * using data from Data class
     */
    void createQueue()
    {
        for(int i=0; i < 3; i++)
        {
            Transform t = waypoints[i].transform;
           
            GameObject tempBox = Instantiate(block, t.position, Quaternion.identity);
            //tempBox.transform.localScale = new Vector3(0.5f, 0.5f);
            tempBox.GetComponent<block>().makeBlock(t.position.x, t.position.y);
            currentBlocks.Add(tempBox);
                
            
           
        }

        
    }


    

}

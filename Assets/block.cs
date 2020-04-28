using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{

    private bool placed;
    private bool selected;
    public GameObject tile;
    private float scaleX = 0.5f;
    private float scaleY = 0.5f;


    public int[,] array;

    // Start is called before the first frame update
    void Start()
    {
        placed = true;
        selected = false;
        this.transform.localScale = new Vector3(scaleX, scaleY);
      
    }

     
    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            if (Input.GetMouseButtonUp(0))
            {
                selected = false;
            }
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));

            this.transform.position = mousePosition;


        }
        
    }


    private void OnMouseDown()
    {
        selected = true;

    }
    public void makeBlock(float x, float y)
    {

        tile = data.getTileType();

        
        array = data.getArrayBlockType(Random.Range(1, 14));
        //array = data.getArrayBlockType(4);

        Debug.Log(array.GetLength(0));
        Debug.Log(array.GetLength(1));
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Debug.Log("testinig");
                if (array[i, j] == 1)
                {
                    GameObject g = Instantiate(tile, new Vector2(i * data.spriteWidth + x, j * data.spriteHeight + y), Quaternion.identity, this.transform);
                    
                }

            }
           
        }
        
    }
}

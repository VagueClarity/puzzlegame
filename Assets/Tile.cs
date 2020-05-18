
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Stores data of a single tile 
 * 
 */
public class SingleTile
{
    //Default color 73 81 93
    public int number; ///< Numerical value for each tile
    public GameObject tileObj; ///< Tile object 
    public int index; ///< Position of where the block is in the array
    //public Color color;

    
    public SingleTile(int number, GameObject tileObj, int index)
    {
        this.number = number;
        this.tileObj = tileObj;
        this.index = index;
    }
    
}

/**
 * Responsible for creating a gameboard on the screen
 * as well as any interaction with the game and the player itself
 */

public class Tile : MonoBehaviour
{

    [SerializeField]
    private GameObject defaultTile;
    public SingleTile[,] basePlate = new SingleTile[10,10];



    Ray ray;
    RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {
        
      
        Transform board = this.transform.Find("gameboard");

        if (board)
        {
            drawTile(board);
        
        }
        //drawTile();

    }

    // Update is called once per frame
    void Update()
    {
        /**
        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        
        Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition),new Vector2(0,0), Color.green);
        //if (hit && data.selected)
        //{
        //    int index = getIndex(hit.transform.gameObject);
        //    getTile(index).transform.GetComponent<defaultTile>().setColor(data.maroon);
        //    //Debug.Log(getTile(index));
        //}
        **/
    }

    /**
     * Draws the gridTile for the game
     */
    void drawTile(Transform T)
    {
        float scaleW = defaultTile.transform.localScale.x;
        float scaleH = defaultTile.transform.localScale.y;

        SpriteRenderer s = defaultTile.GetComponent<SpriteRenderer>();
        float width = s.sprite.bounds.size.x * scaleW;
        float height = s.sprite.bounds.size.y * scaleH;

        float offsetX = Screen.width / 10;
        float offsetY = Screen.height / 5;



        Vector3 v = Camera.main.ScreenToWorldPoint(new Vector3(offsetX, offsetY, 0));


        //Debug.Log("Width: " + offsetX + "height:" + offsetY);
        //Debug.Log("X: " + v.x + " Y " + v.y);

        int i = 0;
        for (int r = 0; r < basePlate.GetLength(0); r++)
        {
            for (int c = 0; c < basePlate.GetLength(1); c++)
            {
                GameObject g = Instantiate(defaultTile, new Vector2(c * width + v.x, r * -height - v.y), Quaternion.identity, T);
                SingleTile st = new SingleTile(Random.Range(0,10), g, i);
              
                basePlate[r, c] = st;
                i++;
            }
        }

     
    }

    
    void OnMouseUp()
    {
        //Check if it lands on something
        Debug.Log("check something");
    }

    private void OnMouseDown()
    {
        
    }

    /**
     * Gets the tile at a given index 
     */
    public GameObject getTile(int index)
    {
        //index = basePlate.GetLength(0) * r + c
        for (int r = 0; r < basePlate.GetLength(0); r++)
        {
            for (int c = 0; c < basePlate.GetLength(1); c++)
            {
                if (index == basePlate[r, c].index)
                {
                    return basePlate[r, c].tileObj;
                }
            }
        }

        return null;
    }




    public void changeShape(int[] array)
    {
        // Get Array shape and color the main tile when placed

    }

    /**
     * Returns the Tile Object given the index
     */
    public int getIndex(GameObject t)
    {
        int index = 0;
        for(int r = 0; r < basePlate.GetLength(0); r++)
        {
            for (int c = 0; c < basePlate.GetLength(1); c++)
            {
                if(t == basePlate[r, c].tileObj)
                {
                    index = basePlate.GetLength(0) * r + c;
                    return index;
                }
            }
        }

        return index;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        

    }


    void drawText()
    {
        
    }



}

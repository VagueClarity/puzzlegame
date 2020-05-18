using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;


/**
 * Block represents a collection of different tiles
 * Block visuals are randomly picked from the Data class
 */
public class block : MonoBehaviour
{

    private bool placed;
    public bool selected; ///< Checks if block is selected
    public GameObject tile;

    [SerializeField]
    private float scaleX = 0.5f; ///< custom scale for calculating offsets
    private float scaleY = 0.5f; ///< custom scale for calculating offsets


    protected float resetX; ///< position to reset to
    protected float resetY; ///< position to reset to

    public int[,] array; ///< For storing the returned block data from data class

    public int timer;

    protected RaycastHit2D hit;
    protected GameObject game;

    /// 
    void Start()
    {
        timer = 20;
        placed = true;
        selected = false;

        game = GameObject.Find("Game");
        this.transform.localScale = new Vector3(scaleX, scaleY);
      
    }

     
    /**
     * Follows the mouse when selected
     */
    void Update()
    {

        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
     
       
        // When clicked block follows mouse
        if (selected)
        {
            float offsetX =  this.transform.GetComponent<BoxCollider2D>().size.x * 6;
            float offsetY =  this.transform.GetComponent<BoxCollider2D>().size.y * 6;
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x + offsetX , Input.mousePosition.y + offsetY));

            this.transform.position = mousePosition;

            timer--;
        }


        if (hit && data.selected)
        {

            Debug.Log(hit.transform.gameObject);
            int index = game.GetComponent<Tile>().getIndex(hit.transform.gameObject);
            game.GetComponent<Tile>().getTile(index).transform.GetComponent<defaultTile>().setColor(data.maroon);
        }

        //else
        //{
        //    resetPosition();
        //}

        //if (Input.GetMouseButton(0) && timer < 0)
        //{

        //    selected = false;
        //    data.selected = false;
        //    timer = 20;
        //}

    }


    private void OnMouseDown()
    {
        selected = true;
        data.selected = true;

       
    }

    private void OnMouseUp()
    {
        selected = false;
        data.selected = false;
        //Check if it can be placed
        resetPosition();
    }

    /**
     * Makes the block at a given location.
     * Returns null
     */
    public void makeBlock(float x, float y)
    {

        resetX = x;
        resetY = y;
        tile = data.getTileType();

        
        array = data.getArrayBlockType(Random.Range(1, 14));
        //array = data.getArrayBlockType(4);

        
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
               
                if (array[i, j] == 1)
                {
                    GameObject g = Instantiate(tile, new Vector2(i * data.spriteWidth + x, j * data.spriteHeight + y), Quaternion.identity, this.transform);
                    
                }

            }
           
        }
        
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colliding");

        if (collision.collider.tag == "UIspot")
        {
            Debug.Log("Testing");
        }
    }

    /**
    * Resets position of the block
    * 
    */
    public void resetPosition()
    {
        this.transform.position = new Vector2(resetX, resetY);
    }
}

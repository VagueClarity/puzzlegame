using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Class for one singular Tile 
 * Controls the visuals of each tile 
 */
public class defaultTile : MonoBehaviour
{

    public SpriteRenderer sprite; ///< Sprite for current tile
    // Start is called before the first frame update
    void Start()
    {

        sprite = this.transform.GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnMouseEnter()
    //{
    //    //sprite.color = Color.red;
    //    if (data.selected)
    //    {
    //        sprite.color = Color.red;
    //        Debug.Log("Hovered Over");

    //    }

    //}


    /**
     * Sets the color of the current tile
     */
    public void setColor(Color c)
    {
        sprite.color = c;
    }


}

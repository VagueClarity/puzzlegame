
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SingleTile
{
    //Default color 73 81 93
    public int number;
    public GameObject tileObj;
    public Color color;

}


public class Tile : MonoBehaviour
{

    [SerializeField]
    private GameObject defaultTile;
    public SingleTile[,] basePlate = new SingleTile[10,10];
   

    // Start is called before the first frame update
    void Start()
    {
        
      
        Transform board = this.transform.Find("gameboard");

        if (board)
        {
            drawTile(board);
            //for (int r = 0; r < basePlate.GetLength(0); r++)
            //{
            //    for (int c = 0; c < basePlate.GetLength(1); c++)
            //    {
            //        Debug.Log(basePlate[r, c].tileObj.transform.position);
            //    }
            //}

        }
        //drawTile();

    }

    // Update is called once per frame
    void Update()
    {

    }

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

        for (int r = 0; r < basePlate.GetLength(0); r++)
        {
            for (int c = 0; c < basePlate.GetLength(1); c++)
            {
                GameObject g = Instantiate(defaultTile, new Vector2(c * width + v.x, r * -height - v.y), Quaternion.identity, T);
                SingleTile st = new SingleTile();
                st.tileObj = g;
                
                basePlate[r, c] = st;

            }
        }
    }



}

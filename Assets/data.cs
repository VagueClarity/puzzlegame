using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Main file to store all the data.
 */

public class data : MonoBehaviour
{


    public static GameObject defaultTile;
    public static float spriteWidth;
    public static float spriteHeight;
    public static bool selected;


    // Colored Prefabs
    // *Needs Refactoring*
    private static GameObject maroonPrefab;
    private static GameObject orangePrefab;
    private static GameObject pinkPrefab;
    private static GameObject purplePrefab;


    // Colors 
    public static Color maroon;
    public static Color orange;
    public static Color pink;
    public static Color purple;
    public static Color baseColor;


    

    public static GameObject[] tiles; ///< tile Color types

    public static int[,] dom1 = new int[1, 2] {{1,1}};
    public static int[,] dom2 = new int[2, 1] {{1}, {1}};
    public static int[,] trom1 = new int[1, 3] { {1,1,1} };
    public static int[,] trom2 = new int[2, 2] { { 1,1},{ 0,1} };
    public static int[,] tetro1 = new int[4, 1] { { 1 },{ 1 }, { 1 }, {1 } };
    public static int[,] tetro2 = new int[2, 2] { { 1, 1 }, { 1, 1 } };
    public static int[,] tetro3 = new int[2, 3] { { 1, 1, 1 }, { 0,0, 1 } };
    public static int[,] tetro4 = new int[2, 3] { { 1, 1, 0 }, { 1, 1, 0 } };
    public static int[,] tetro5 = new int[3, 2] { { 1,0 },{1,1 } ,{ 1,0} };
    public static int[,] penta1 = new int[1, 5] { { 1 , 1, 1 ,  1 ,  1}  };
    public static int[,] penta2 = new int[3, 3] { { 1, 0, 0 }, { 1, 1, 1 }, { 1, 0, 0 } };
    public static int[,] penta3 = new int[3, 3] { { 0, 1, 1 }, { 0, 0, 1 }, { 0, 1, 1 } };
    public static int[,] penta4 = new int[3, 3] { { 0, 0, 1 }, { 0, 0, 1 }, { 1, 1, 1 } };


    public void Awake()
    {

        defaultTile = (GameObject)Resources.Load("Prefabs/DefaultTile");
        maroonPrefab = (GameObject)Resources.Load("Prefabs/BlockMaroon");
        orangePrefab = (GameObject)Resources.Load("Prefabs/BlockOrange");
        pinkPrefab = (GameObject)Resources.Load("Prefabs/BlockPink");
        purplePrefab = (GameObject)Resources.Load("Prefabs/BlockPurple");

        tiles = new GameObject[] {maroonPrefab, orangePrefab, pinkPrefab, purplePrefab};

        maroon = maroonPrefab.transform.GetComponent<SpriteRenderer>().color;
        orange = orangePrefab.transform.GetComponent<SpriteRenderer>().color;
        pink = pinkPrefab.transform.GetComponent<SpriteRenderer>().color;
        purple = purplePrefab.transform.GetComponent<SpriteRenderer>().color;


        selected = false;

        if (defaultTile)
        {
            float scaleW = defaultTile.transform.localScale.x;
            float scaleH = defaultTile.transform.localScale.y;

            SpriteRenderer s = defaultTile.GetComponent<SpriteRenderer>();
            spriteWidth = s.sprite.bounds.size.x * scaleW;
            spriteHeight = s.sprite.bounds.size.y * scaleH;
        }

    }
    /**
     * Gets the Array Type block which has varying shapes in 2D array
     */
    public static int[,] getArrayBlockType(int i)
    {
        if (i == 1)
        {
            return dom1;
        }
        else if (i == 2)
        {
            return dom2;
        }
        else if (i == 3)
        {
            return trom1;
        }
        else if (i == 4){
            return trom2;
        }
        else if(i == 5)
        {
            return tetro1;
        }
        else if(i == 6)
        {
            return tetro2;

        }
        else if(i == 7)
        {
            return tetro3;
        }
        else if(i == 8)
        {
            return tetro4;
        }
        else if(i == 9)
        {
            return tetro5;
        }
        else if(i == 10)
        {
            return penta1;

        }
        else if (i == 11)
        {
            return penta2;

        }
        else if (i == 12)
        {
            return penta3;

        }
        else if (i == 13)
        {
            return penta4;

        }
        else
        {
            return null;
        }
    }
   
    /**
     * Returns the tile color type from 
     */
    public static GameObject getTileType()
    {
        int i = Random.Range(1, 4);
        
        return tiles[i];
    }
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class data : MonoBehaviour
{


    public static GameObject defaultTile;
    public static float spriteWidth;
    public static float spriteHeight;

    private static GameObject maroon;
    private static GameObject orange;
    private static GameObject pink;
    private static GameObject purple;


    public static GameObject[] tiles;

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
        maroon = (GameObject)Resources.Load("Prefabs/BlockMaroon");
        orange = (GameObject)Resources.Load("Prefabs/BlockOrange");
        pink = (GameObject)Resources.Load("Prefabs/BlockPink");
        purple = (GameObject)Resources.Load("Prefabs/BlockPurple");

        tiles = new GameObject[] { maroon, orange, pink, purple };



        if (defaultTile)
        {
            float scaleW = defaultTile.transform.localScale.x;
            float scaleH = defaultTile.transform.localScale.y;

            SpriteRenderer s = defaultTile.GetComponent<SpriteRenderer>();
            spriteWidth = s.sprite.bounds.size.x * scaleW;
            spriteHeight = s.sprite.bounds.size.y * scaleH;
        }

    }
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
    // Start is called before the first frame update

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

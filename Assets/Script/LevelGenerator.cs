using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private GameObject grid;
    private int outerconner = 0;
    private int outerwall = 0;
    private int innerconner = 0;
    private int empty = 0;
    private GameObject destroy;
    private GameObject destroy4;
    private GameObject destroy2;
    private GameObject destroy3;
    
    private int changing =0;
    private int changing0line = 0;
    private int changestright = 0;
    private int turnconner = 0;

    private int[,] Map =
    {

        {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
     };
    //0 ¡V Empty(do not instantiate anything)
    //1 - Outside corner(double lined corener piece in orginal game)
    //2 - Outside wall(double line in original game)
    //3 - Inside corner(single lined corener piece in orginal game)
    //4 - Inside wall(single line in orginal game)
    //5 - Standard pellet(see Visual Assets above)
    //6 - Power pellet(see Visual Assets above)
    //7 - A t junction piece for connecting with adjoining regions
    // Start is called before the first frame update
    void Start()
    {
        GameObject grid = GameObject.Find("Grid");
        grid.SetActive(false);


        for (int row = 0; row < Map.GetLength(0); row++)
        {
            outerconner = 0;
            outerwall = 0;
            turnconner = 0;
            innerconner = 0;
            empty = 0;
            for (int col = 0; col < Map.GetLength(1); col++)
            {
                if (Map[row, col] == 0)
                {
                    Instantiate(tilePrefabs[0], new Vector3(-14 + col, 13 - row, 0), Quaternion.identity);
                    empty = 1;
                }
                else if (Map[row, col] == 1)
                {
                    if(row != 0 && outerwall == 0)
                    {
                        Instantiate(tilePrefabs[1], new Vector3(-14 + col, 13 - row, 0), Quaternion.Euler(0, 0, 90));
                        Instantiate(tilePrefabs[1], new Vector3(13 - col, 13 - row, 0), Quaternion.Euler(0, 0, 180));
                        Instantiate(tilePrefabs[1], new Vector3(-14 + col, -15 + row, 0), Quaternion.identity);
                        Instantiate(tilePrefabs[1], new Vector3(13 - col, -15 + row, 0), Quaternion.Euler(0, 0, 270));
                        outerconner = 1;
                    }
                    else if(outerconner == 1 && outerwall == 1)
                    {
                        Instantiate(tilePrefabs[1], new Vector3(-14 + col, 13 - row, 0), Quaternion.Euler(0, 0, 270));
                        Instantiate(tilePrefabs[1], new Vector3(13 - col, 13 - row, 0), Quaternion.identity );
                        Instantiate(tilePrefabs[1], new Vector3(-14 + col, -15 + row, 0), Quaternion.Euler(0, 0, 180));
                        Instantiate(tilePrefabs[1], new Vector3(13 - col, -15 + row, 0), Quaternion.Euler(0, 0, 90));
                        outerconner = 1;
                    }
                    else if(outerconner ==0 && outerwall == 1)
                    {
                        Instantiate(tilePrefabs[1], new Vector3(-14 + col, 13 - row, 0), Quaternion.Euler(0, 0, 180));
                        Instantiate(tilePrefabs[1], new Vector3(13 - col, 13 - row, 0), Quaternion.Euler(0, 0, 90));
                        Instantiate(tilePrefabs[1], new Vector3(-14 + col, -15 + row, 0), Quaternion.Euler(0, 0, 270));
                        Instantiate(tilePrefabs[1], new Vector3(13 - col, -15 + row, 0), Quaternion.identity);
                        outerconner = 1;
                        Destroy(destroy);
                        Destroy(destroy2);
                        Destroy(destroy3);
                        Destroy(destroy4);
                        Instantiate(tilePrefabs[2], new Vector3(-14, 13 - row, 0), Quaternion.Euler(0, 0, -90));
                        Instantiate(tilePrefabs[2], new Vector3(13 , 13 - row, 0), Quaternion.Euler(0, 0, -90));
                        Instantiate(tilePrefabs[2], new Vector3(-14, -15 + row, 0), Quaternion.Euler(0, 0, -90));
                        Instantiate(tilePrefabs[2], new Vector3(13 , -15 + row, 0), Quaternion.Euler(0, 0, -90));
                    }
                    else
                    {
                        Instantiate(tilePrefabs[1], new Vector3(-14 + col, 13 - row, 0), Quaternion.identity);
                        Instantiate(tilePrefabs[1], new Vector3(13 - col, 13 - row, 0), Quaternion.Euler(0, 0, 270));
                        Instantiate(tilePrefabs[1], new Vector3(-14 + col, -15 + row, 0), Quaternion.Euler(0, 0, 90));
                        Instantiate(tilePrefabs[1], new Vector3(13 - col, -15 + row, 0), Quaternion.Euler(0, 0, 180));
                        outerconner = 1;
                        
                    }
                    

                }
                else if (Map[row, col] == 2)

                {
                    if (outerconner == 1)
                    {
                        Instantiate(tilePrefabs[2], new Vector3(-14 + col, 13 - row, 0), Quaternion.Euler(0, 0, -90));
                        Instantiate(tilePrefabs[2], new Vector3(13 - col, 13 - row, 0), Quaternion.Euler(0, 0, 90));
                        Instantiate(tilePrefabs[2], new Vector3(-14 + col, -15 + row, 0), Quaternion.Euler(0, 0, -90));
                        Instantiate(tilePrefabs[2], new Vector3(13 - col, -15 + row, 0), Quaternion.Euler(0, 0, -90));

                        outerwall = 1;
                    }
                    else if(row != 0 && outerconner == 0 && col != 0 && empty ==0)
                    {
                        Instantiate(tilePrefabs[2], new Vector3(-14 + col, 13 - row, 0), Quaternion.Euler(0, 0, -90));
                        Instantiate(tilePrefabs[2], new Vector3(13 - col, 13 - row, 0), Quaternion.Euler(0, 0, 90));
                        Instantiate(tilePrefabs[2], new Vector3(-14 + col, -15 + row, 0), Quaternion.Euler(0, 0, -90));
                        Instantiate(tilePrefabs[2], new Vector3(13 - col, -15 + row, 0), Quaternion.Euler(0, 0, -90));
                        outerwall = 1;
                    }
                    else
                    {
                        destroy = Instantiate(tilePrefabs[2], new Vector3(-14 + col, 13 - row, 0), Quaternion.identity);
                        destroy2 = Instantiate(tilePrefabs[2], new Vector3(13 - col, 13 - row, 0), Quaternion.identity);
                        destroy3 =Instantiate(tilePrefabs[2], new Vector3(-14 + col, -15 + row, 0), Quaternion.identity);
                        destroy4 = Instantiate(tilePrefabs[2], new Vector3(13 - col, -15 + row, 0), Quaternion.identity);
                    }

                    
                }
                else if (Map[row, col] == 3)
                {
                    if (Map[row - 1, col] == 3)
                    {
                        if (changing0line ==1 && Map[row, col - 1] != 5 && Map[row - 1, col + 1] != 4)
                        {
                            Instantiate(tilePrefabs[3], new Vector3(-14 + col, 13 - row, 0), Quaternion.Euler(0, 0, 180));
                            Instantiate(tilePrefabs[3], new Vector3(13 - col, 13 - row, 0), Quaternion.Euler(0, 0, 90));
                            Instantiate(tilePrefabs[3], new Vector3(-14 + col, -15 + row, 0), Quaternion.Euler(0, 0, 270));
                            Instantiate(tilePrefabs[3], new Vector3(13 - col, -15 + row, 0), Quaternion.identity);
                            changestright =1;

                        }
                        
                        else if (Map[row, col -1] != 4)
                        {
                            Instantiate(tilePrefabs[3], new Vector3(-14 + col, 13 - row, 0), Quaternion.Euler(0, 0, 90));
                            Instantiate(tilePrefabs[3], new Vector3(13 - col, 13 - row, 0), Quaternion.Euler(0, 0, 180));
                            Instantiate(tilePrefabs[3], new Vector3(-14 + col, -15 + row, 0), Quaternion.identity);
                            Instantiate(tilePrefabs[3], new Vector3(13 - col, -15 + row, 0), Quaternion.Euler(0, 0, 270));
                            changing0line = 1;
                           
                        }
                        if(Map[row, col - 1] == 5)
                        {
                            Instantiate(tilePrefabs[3], new Vector3(-14 + col, 13 - row, 0), Quaternion.Euler(0, 0, 90));
                            Instantiate(tilePrefabs[3], new Vector3(13 - col, 13 - row, 0), Quaternion.Euler(0, 0, 180));
                            Instantiate(tilePrefabs[3], new Vector3(-14 + col, -15 + row, 0), Quaternion.identity);
                            Instantiate(tilePrefabs[3], new Vector3(13 - col, -15 + row, 0), Quaternion.Euler(0, 0, 270));
                            innerconner = 1;
                        }
                        if(Map[row, col - 1] == 4 && Map[row-1, col + 1] == 4)
                        {
                            Instantiate(tilePrefabs[3], new Vector3(-14 + col, 13 - row, 0), Quaternion.identity);
                            Instantiate(tilePrefabs[3], new Vector3(13 - col, 13 - row, 0), Quaternion.Euler(0, 0, 270));
                            Instantiate(tilePrefabs[3], new Vector3(-14 + col, -15 + row, 0), Quaternion.Euler(0, 0, 90));
                            Instantiate(tilePrefabs[3], new Vector3(13 - col, -15 + row, 0), Quaternion.Euler(0, 0, 180));
                            innerconner = 1;
                            changing = 0;
                        }
                    }
                    else if(Map[row , col -1] == 0)
                    {
                        if (Map[row - 1, col] == 4)
                        {
                            Instantiate(tilePrefabs[3], new Vector3(-14 + col, 13 - row, 0), Quaternion.Euler(0, 0, 90));
                            Instantiate(tilePrefabs[3], new Vector3(13 - col, 13 - row, 0), Quaternion.Euler(0, 0, 180));
                            Instantiate(tilePrefabs[3], new Vector3(-14 + col, -15 + row, 0), Quaternion.identity);
                            Instantiate(tilePrefabs[3], new Vector3(13 - col, -15 + row, 0), Quaternion.Euler(0, 0, 270));
                        }
                        else if (Map[row - 1, col] == 0)
                        {
                            Instantiate(tilePrefabs[3], new Vector3(-14 + col, 13 - row, 0), Quaternion.identity);
                            Instantiate(tilePrefabs[3], new Vector3(13 - col, 13 - row, 0), Quaternion.Euler(0, 0, 270));
                            Instantiate(tilePrefabs[3], new Vector3(-14 + col, -15 + row, 0), Quaternion.Euler(0, 0, 90));
                            Instantiate(tilePrefabs[3], new Vector3(13 - col, -15 + row, 0), Quaternion.Euler(0, 0, 180));
                            innerconner = 1;
                            changing = 0;
                        }
                        
                    }
                    else if(Map[row-1 , col ] == 5)
                    {
                        if(Map[row, col -1] == 4)
                        {
                            Instantiate(tilePrefabs[3], new Vector3(-14 + col, 13 - row, 0), Quaternion.Euler(0, 0, 270));
                            Instantiate(tilePrefabs[3], new Vector3(13 - col, 13 - row, 0), Quaternion.identity);
                            Instantiate(tilePrefabs[3], new Vector3(-14 + col, -15 + row, 0), Quaternion.Euler(0, 0, 180));
                            Instantiate(tilePrefabs[3], new Vector3(13 - col, -15 + row, 0), Quaternion.Euler(0, 0, 90));
                            innerconner = 0;
                        }
                        else if (Map[row, col-1] == 5)
                        {
                            Instantiate(tilePrefabs[3], new Vector3(-14 + col, 13 - row, 0), Quaternion.identity);
                            Instantiate(tilePrefabs[3], new Vector3(13 - col, 13 - row, 0), Quaternion.Euler(0, 0, 270));
                            Instantiate(tilePrefabs[3], new Vector3(-14 + col, -15 + row, 0), Quaternion.Euler(0, 0, 90));
                            Instantiate(tilePrefabs[3], new Vector3(13 - col, -15 + row, 0), Quaternion.Euler(0, 0, 180));
                            innerconner = 1;
                            changing = 0;
                        }
                        else if(Map[row, col - 1] == 3)
                        {
                            Instantiate(tilePrefabs[3], new Vector3(-14 + col, 13 - row, 0), Quaternion.Euler(0, 0, 270));
                            Instantiate(tilePrefabs[3], new Vector3(13 - col, 13 - row, 0), Quaternion.identity);
                            Instantiate(tilePrefabs[3], new Vector3(-14 + col, -15 + row, 0), Quaternion.Euler(0, 0, 180));
                            Instantiate(tilePrefabs[3], new Vector3(13 - col, -15 + row, 0), Quaternion.Euler(0, 0, 90));
                            innerconner = 0;
                        }
                    }
                    else if (Map[row - 1, col] == 4)
                    {
                        if (Map[row , col -1] == 5 )
                        {
                            
                            Instantiate(tilePrefabs[3], new Vector3(-14 + col, 13 - row, 0), Quaternion.Euler(0, 0, 90));
                            Instantiate(tilePrefabs[3], new Vector3(13 - col, 13 - row, 0), Quaternion.Euler(0, 0, 180));
                            Instantiate(tilePrefabs[3], new Vector3(-14 + col, -15 + row, 0), Quaternion.identity);
                            Instantiate(tilePrefabs[3], new Vector3(13 - col, -15 + row, 0), Quaternion.Euler(0, 0, 270));
                            innerconner = 1;
                        }
                        else if (Map[row - 1, col - 1] == 0)
                        {
                            Instantiate(tilePrefabs[3], new Vector3(-14 + col, 13 - row, 0), Quaternion.Euler(0, 0, 180));
                            Instantiate(tilePrefabs[3], new Vector3(13 - col, 13 - row, 0), Quaternion.Euler(0, 0, 90));
                            Instantiate(tilePrefabs[3], new Vector3(-14 + col, -15 + row, 0), Quaternion.Euler(0, 0, 270));
                            Instantiate(tilePrefabs[3], new Vector3(13 - col, -15 + row, 0), Quaternion.identity);
                            innerconner = 1;
                        }
                        else if (Map[row , col -1] == 3)
                        {
                            Instantiate(tilePrefabs[3], new Vector3(-14 + col, 13 - row, 0), Quaternion.Euler(0, 0, 180));
                            Instantiate(tilePrefabs[3], new Vector3(13 - col, 13 - row, 0), Quaternion.Euler(0, 0, 90));
                            Instantiate(tilePrefabs[3], new Vector3(-14 + col, -15 + row, 0), Quaternion.Euler(0, 0, 270));
                            Instantiate(tilePrefabs[3], new Vector3(13 - col, -15 + row, 0), Quaternion.identity);
                            innerconner = 0;
                        }
                        else if (Map[row - 2, col] == 5)
                        {
                            Instantiate(tilePrefabs[3], new Vector3(-14 + col, 13 - row, 0), Quaternion.Euler(0, 0, 270));
                            Instantiate(tilePrefabs[3], new Vector3(13 - col, 13 - row, 0), Quaternion.identity);
                            Instantiate(tilePrefabs[3], new Vector3(-14 + col, -15 + row, 0), Quaternion.Euler(0, 0, 180));
                            Instantiate(tilePrefabs[3], new Vector3(13 - col, -15 + row, 0), Quaternion.Euler(0, 0, 90));
                            innerconner = 0;
                        }
                        else if ( Map[row, col - 1] == 4)
                        {
                            Instantiate(tilePrefabs[3], new Vector3(-14 + col, 13 - row, 0), Quaternion.Euler(0, 0, 90));
                            Instantiate(tilePrefabs[3], new Vector3(13 - col, 13 - row, 0), Quaternion.Euler(0, 0, 180));
                            Instantiate(tilePrefabs[3], new Vector3(-14 + col, -15 + row, 0), Quaternion.identity);
                            Instantiate(tilePrefabs[3], new Vector3(13 - col, -15 + row, 0), Quaternion.Euler(0, 0, 270));
                            innerconner = 1;
                        }
                        
                        
                    }
                    
                    
                   




                     else if (innerconner == 1 && changing == 0 && Map[row - 1, col] != 3)
                    {
                         
                        Instantiate(tilePrefabs[3], new Vector3(-14 + col, 13 - row, 0), Quaternion.Euler(0, 0, 270));
                        Instantiate(tilePrefabs[3], new Vector3(13 - col, 13 - row, 0), Quaternion.identity);
                        Instantiate(tilePrefabs[3], new Vector3(-14 + col, -15 + row, 0), Quaternion.Euler(0, 0, 180));
                        Instantiate(tilePrefabs[3], new Vector3(13 - col, -15 + row, 0), Quaternion.Euler(0, 0, 90));
                        innerconner = 0;
                    }
                    else if(col == 13)
                    {
                        Instantiate(tilePrefabs[3], new Vector3(-14 + col, 13 - row, 0), Quaternion.Euler(0, 0, 90));
                        Instantiate(tilePrefabs[3], new Vector3(13 - col, 13 - row, 0), Quaternion.Euler(0, 0, 180));
                        Instantiate(tilePrefabs[3], new Vector3(-14 + col, -15 + row, 0), Quaternion.identity);
                        Instantiate(tilePrefabs[3], new Vector3(13 - col, -15 + row, 0), Quaternion.Euler(0, 0, 270));
                        changing = 0;
                    }
                    else if (changing == 1 && innerconner == 2)
                    {
                        Instantiate(tilePrefabs[3], new Vector3(-14 + col, 13 - row, 0), Quaternion.Euler(0, 0, 180));
                        Instantiate(tilePrefabs[3], new Vector3(13 - col, 13 - row, 0), Quaternion.Euler(0, 0, 90));
                        Instantiate(tilePrefabs[3], new Vector3(-14 + col, -15 + row, 0), Quaternion.Euler(0, 0, 270));
                        Instantiate(tilePrefabs[3], new Vector3(13 - col, -15 + row, 0), Quaternion.identity);
                        innerconner = 0;
                    }
                    else if(changing == 1)
                    {
                        Instantiate(tilePrefabs[3], new Vector3(-14 + col, 13 - row, 0), Quaternion.Euler(0, 0, 90));
                        Instantiate(tilePrefabs[3], new Vector3(13 - col, 13 - row, 0), Quaternion.Euler(0, 0, 180));
                        Instantiate(tilePrefabs[3], new Vector3(-14 + col, -15 + row, 0), Quaternion.identity);
                        Instantiate(tilePrefabs[3], new Vector3(13 - col, -15 + row, 0), Quaternion.Euler(0, 0, 270));
                        innerconner = 2;
                    }
                    else if(Map[row - 1, col] != 3)
                    {
                        Instantiate(tilePrefabs[3], new Vector3(-14 + col, 13 - row, 0), Quaternion.identity);
                        Instantiate(tilePrefabs[3], new Vector3(13 - col, 13 - row, 0), Quaternion.Euler(0, 0, 270));
                        Instantiate(tilePrefabs[3], new Vector3(-14 + col, -15 + row, 0), Quaternion.Euler(0, 0, 90));
                        Instantiate(tilePrefabs[3], new Vector3(13 - col, -15 + row, 0), Quaternion.Euler(0, 0, 180));
                        innerconner = 1;
                        changing = 0;
                        
                    }

                    
                    
                }
                else if (Map[row, col] == 4)
                {
                    
                     if(Map[row - 1, col] == 3 && Map[row, col-1] == 4 )
                    {
                        Instantiate(tilePrefabs[4], new Vector3(-14 + col, 13 - row, 0), Quaternion.identity);
                        Instantiate(tilePrefabs[4], new Vector3(13 - col, 13 - row, 0), Quaternion.identity);
                        Instantiate(tilePrefabs[4], new Vector3(-14 + col, -15 + row, 0), Quaternion.identity);
                        Instantiate(tilePrefabs[4], new Vector3(13 - col, -15 + row, 0), Quaternion.identity);

                    }
                    else if (Map[row - 1, col] == 3 && Map[row, col - 1] == 5)
                    {
                        Instantiate(tilePrefabs[4], new Vector3(-14 + col, 13 - row, 0), Quaternion.identity);
                        Instantiate(tilePrefabs[4], new Vector3(13 - col, 13 - row, 0), Quaternion.identity);
                        Instantiate(tilePrefabs[4], new Vector3(-14 + col, -15 + row, 0), Quaternion.identity);
                        Instantiate(tilePrefabs[4], new Vector3(13 - col, -15 + row, 0), Quaternion.identity);

                    }

                    else if (innerconner == 1 || innerconner == 2 )
                    {
                         Instantiate(tilePrefabs[4], new Vector3(-14 + col, 13 - row, 0), Quaternion.Euler(0, 0, -90));
                        Instantiate(tilePrefabs[4], new Vector3(13 - col, 13 - row, 0), Quaternion.Euler(0, 0, -90));
                        Instantiate(tilePrefabs[4], new Vector3(-14 + col, -15 + row, 0), Quaternion.Euler(0, 0, -90));
                        Instantiate(tilePrefabs[4], new Vector3(13 - col, -15 + row, 0), Quaternion.Euler(0, 0, -90));
                        turnconner = 1;
                    }
                    else if (col == 13)
                    {
                       
                        Instantiate(tilePrefabs[4], new Vector3(-14 + col, 13 - row, 0), Quaternion.identity);
                        Instantiate(tilePrefabs[4], new Vector3(13 - col, 13 - row, 0), Quaternion.identity);
                        Instantiate(tilePrefabs[4], new Vector3(-14 + col, -15 + row, 0), Quaternion.identity);
                        Instantiate(tilePrefabs[4], new Vector3(13 - col, -15 + row, 0), Quaternion.identity);


                    }
                    else if (innerconner == 0 || changestright == 1)
                    {
                        Instantiate(tilePrefabs[4], new Vector3(-14 + col, 13 - row, 0), Quaternion.identity);
                        Instantiate(tilePrefabs[4], new Vector3(13 - col, 13 - row, 0), Quaternion.identity);
                        Instantiate(tilePrefabs[4], new Vector3(-14 + col, -15 + row, 0), Quaternion.identity);
                        Instantiate(tilePrefabs[4], new Vector3(13 - col, -15 + row, 0), Quaternion.identity);

                        changing = 1;
                    }
                    
                }
                else if (Map[row, col] == 5)
                {
                    Instantiate(tilePrefabs[5], new Vector3(-14 + col, 13 - row, 0), Quaternion.identity);
                    Instantiate(tilePrefabs[5], new Vector3(13 - col, 13 - row, 0), Quaternion.identity);
                    Instantiate(tilePrefabs[5], new Vector3(-14 + col, -15 + row, 0), Quaternion.identity);
                    Instantiate(tilePrefabs[5], new Vector3(13 - col, -15 + row, 0), Quaternion.identity);
                }
                else if (Map[row, col] == 6)
                {
                    Instantiate(tilePrefabs[6], new Vector3(-14 + col, 13 - row, 0), Quaternion.identity);
                    Instantiate(tilePrefabs[6], new Vector3(13 - col, 13 - row, 0), Quaternion.identity);
                    Instantiate(tilePrefabs[6], new Vector3(-14 + col, -15 + row, 0), Quaternion.identity);
                    Instantiate(tilePrefabs[6], new Vector3(13 - col, -15 + row, 0), Quaternion.identity);
                }
                else if (Map[row, col] == 7)
                {
                    Instantiate(tilePrefabs[7], new Vector3(-14 + col, 13 - row, 0), Quaternion.identity);
                    Instantiate(tilePrefabs[7], new Vector3(13 - col, 13 - row, 0), Quaternion.Euler(0, 180, 0));
                    Instantiate(tilePrefabs[7], new Vector3(-14 + col, -15 + row, 0), Quaternion.Euler(0, 180, 180));
                    Instantiate(tilePrefabs[7], new Vector3(13 - col, -15 + row, 0), Quaternion.Euler(0, 0, 180));
                }


            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

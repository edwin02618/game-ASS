using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs;
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
        for (int row = 0; row < Map.GetLength(0); row++)
        {
            for (int col = 0; col < Map.GetLength(1); col++)
            {
                if (Map[row, col] == 0)
                {
                    Instantiate(tilePrefabs[0], new Vector3(row, 0, col), Quaternion.identity);
                }
                else if (Map[row, col] == 1)
                {
                    Instantiate(tilePrefabs[1], new Vector3(row, 0, col), Quaternion.identity);
                }
                else if (Map[row, col] == 2)
                {
                    Instantiate(tilePrefabs[2], new Vector3(row, 0, col), Quaternion.identity);
                }
                else if (Map[row, col] == 3)
                {
                    Instantiate(tilePrefabs[3], new Vector3(row, 0, col), Quaternion.identity);
                }
                else if (Map[row, col] == 4)
                {
                    Instantiate(tilePrefabs[4], new Vector3(row, 0, col), Quaternion.identity);
                }
                else if (Map[row, col] == 5)
                {
                    Instantiate(tilePrefabs[5], new Vector3(row, 0, col), Quaternion.identity);
                }
                else if (Map[row, col] == 6)
                {
                    Instantiate(tilePrefabs[6], new Vector3(row, 0, col), Quaternion.identity);
                }
                else if (Map[row, col] == 7)
                {
                    Instantiate(tilePrefabs[7], new Vector3(row, 0, col), Quaternion.identity);
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

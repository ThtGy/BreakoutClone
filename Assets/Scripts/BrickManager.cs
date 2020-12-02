using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickManager : MonoBehaviour
{
    public int rows;
    public int columns;
    public float spacing;
    public GameObject brickPrefab;
    public Text winScreen;

    private List<GameObject> bricks = new List<GameObject>(); //keeps track of which bricks still exist

    // Start is called before the first frame update
    void Start()
    {
        ResetLevel();
    }

    // Update is called once per frame
    void Update()
    {
        //Show win screen when all bricks are gone
        if(GameObject.Find("Brick(Clone)") == null)
        {
            winScreen.gameObject.SetActive(true);
        }
    }

    //Removes any existing bricks and adds new bricks to display
    public void ResetLevel()
    {
        //remove all existing bricks and remove from list
        foreach(GameObject brick in bricks)
        {
            Destroy(brick);
        }
        bricks.Clear();

        //spawn specified rows and columns of bricks when called starting at BrickManager's position in editor
        for(int x = 0; x < columns; x++)
        {
            for(int y = 0; y < rows; y++)
            {
                Vector2 spawnPos = (Vector2)transform.position +
                    new Vector2(x * (brickPrefab.transform.localScale.x + spacing), 
                    -y * (brickPrefab.transform.localScale.y + spacing));
                GameObject brick = Instantiate(brickPrefab, spawnPos, Quaternion.identity);
                bricks.Add(brick);
            }
        }
    }
}

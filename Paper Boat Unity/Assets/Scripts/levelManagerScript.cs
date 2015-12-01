using UnityEngine;
using System.Collections;

public class levelManagerScript : MonoBehaviour {
    public GameObject[] levels;
    GameObject level;
    int i;
    float pos;
    public int randomNum;
    int spawnCount;

	void Start ()
    {
        pos = 0;
        for (i = 0; i <levels.Length; i++)
        {
            createNewLevel(pos, i);
            pos += 4;
        }
	}

    public void spawnNewLevel(string name, GameObject level, int arrayNum)
    {
        randomNum = Random.Range(0, 10);
        arrayNum = 0;
        spawnCount++;

        if (spawnCount > 2)
        {
            if (randomNum == 3)
            {
                arrayNum = 1;  
            }
            else if (randomNum == 7 || randomNum == 0)
            {
                arrayNum = 2;
            }
            spawnCount = 0;
        }

        createNewLevel(4 * (levels.Length - 1), arrayNum);
    }

    void createNewLevel(float position, int index)
    {
        level = Instantiate(levels[index], transform.position, Quaternion.identity) as GameObject;
        level.transform.parent = transform;
        level.transform.position = new Vector3(position, 0, 0);
    }
}

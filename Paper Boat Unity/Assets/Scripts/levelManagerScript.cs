using UnityEngine;
using System.Collections;

public class levelManagerScript : MonoBehaviour {
    public GameObject[] levels;
    GameObject level;
    public GameObject[] poolObj;
    int i;
    float pos;
    public int randomNum;
    int spawnCount;

    string[] names;
    int plainCount;
	void Start ()
    {
        poolObj = new GameObject[5];
        names = new string[3];
        pos = 20;

        for (i = 0; i < 5; i++)
        {
            if (i > 2)
            {
                InstantiateLevel(pos, 0);
            }
            else
            {
                InstantiateLevel(pos, i);
                names[i] = level.name;
            }
            poolObj[i] = level;
        }

        setLevels();
	}

    void Update()
    {
        for (i = 0; i < 5; i++)
        {
            if (poolObj[i].activeSelf)
            {
                poolObj[i].transform.position += new Vector3(-0.01f, 0, 0) * Time.timeScale;
                if (poolObj[i].transform.position.x < -3.99f)
                {
                    poolObj[i].SetActive(false);
                    poolObj[i].transform.position = new Vector3(20, 0, 0);
                    spawnNewLevel(poolObj[i].name);
                }
            }
        }
    }

    public void spawnNewLevel(string name)
    {
        randomNum = Random.Range(0, 10);
        string objName = names[0];
        spawnCount++;

        if (spawnCount > 2)
        {
            if (randomNum %3 == 0 && randomNum !=0)
            {
                objName = names[1];
            }
            else if (randomNum == 7 || randomNum == 0)
            {
                objName = names[2];
            }
            spawnCount = 0;
        }

        createNewLevel(objName);
    }

    void InstantiateLevel(float position, int index)
    {
        level = Instantiate(levels[index], transform.position, Quaternion.identity) as GameObject;
        level.transform.parent = transform;
        level.transform.position = new Vector3(position, 0, 0);
        level.SetActive(false);
    }

    void setLevels()
    {
        pos = 0;
        for (i = 0; i < 5; i++)
        {
            if (poolObj[i].name == names[0])
            {
                poolObj[i].SetActive(true);
                poolObj[i].transform.position = new Vector3(pos, 0, 0);
                pos += 4;
            }
        }        
    }

    void createNewLevel(string name)
    {
        foreach (GameObject gj in poolObj)
        {
            if (gj.name == name)
            {
                if (!gj.activeSelf)
                {
                    print(gj.name);
                    gj.SetActive(true);
                    gj.transform.position = new Vector3(4 * (levels.Length - 1), 0, 0);
                    break;
                }
            }     
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelParser : MonoBehaviour
{
    public string filename;

    public GameObject block1;

    public GameObject block2;

    public Transform parentTransform;
    // Start is called before the first frame update
    void Start()
    {
        RefreshParse();
    }


    private void FileParser()
    {
        string fileToParse = string.Format("{0}{1}{2}.txt", Application.dataPath, "/Resources/", filename);

        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            int row = 0;

            while ((line = sr.ReadLine()) != null)
            {
                int column = 0;
                char[] letters = line.ToCharArray();
                foreach (var letter in letters)
                {

                    SpawnPrefab(letter, new Vector3(column, -1, row));

                    column++;
                }

                row--;
            }

            sr.Close();
        }
    }

    private void SpawnPrefab(char spot, Vector3 positionToSpawn)
    {
        GameObject ToSpawn;

        switch (spot)
        {
            case 'x':
                ToSpawn = block1;
                Debug.Log("Spawn x");
                break;
            case 'o':
                ToSpawn = block2;
                Debug.Log("Spawn o");
                break;
            default: return;
                //ToSpawn = //Brick;       break;
        }

        ToSpawn = GameObject.Instantiate(ToSpawn, parentTransform);
        ToSpawn.transform.localPosition = positionToSpawn;
    }

    public void RefreshParse()
    {
        GameObject newParent = new GameObject();
        newParent.name = "Environment";
        newParent.transform.position = parentTransform.position;
        newParent.transform.parent = this.transform;

        if (parentTransform) Destroy(parentTransform.gameObject);

        parentTransform = newParent.transform;
        FileParser();
    }
}
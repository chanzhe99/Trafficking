using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using LevelEditor;
using System;

public class Level_SaveLoad : MonoBehaviour
{
    private List<SaveableLevelObject> saveLevelObjects_List = new List<SaveableLevelObject>();
    private List<SaveableLevelObject> saveStackableLevelObjects_List = new List<SaveableLevelObject>();
    private List<NodeObjectSaveable> saveNodeObjectsList = new List<NodeObjectSaveable>();

    public static string saveFolderName = "LevelObjects";

    public void SaveLevelButton()
    {
        SaveLevel("testLevel");
    }

    public void LoadLevelButton()
    {
        LoadLevel("testLevel");
    }

    static string SaveLocation(string LevelName)
    {
        string saveLocation = Application.persistentDataPath + "/" + saveFolderName + "/";

        if (!Directory.Exists(saveLocation))
        {
            Directory.CreateDirectory(saveLocation);
        }

        return saveLocation + LevelName;
    }

    void SaveLevel(string saveName)
    {
        Level_Object[] levelObjects = FindObjectsOfType<Level_Object>();
        saveLevelObjects_List.Clear();
        
        foreach (Level_Object lvlObj in levelObjects)
        {
            if (!lvlObj.isStackableObj)
            {
                saveLevelObjects_List.Add(lvlObj.GetSavableObject());
            }
            else
            {
                saveStackableLevelObjects_List.Add(lvlObj.GetSavableObject());
            }
        }

        NodeObject[] nodeObjects = FindObjectsOfType<NodeObject>();
        saveNodeObjectsList.Clear();

        foreach(NodeObject nodeObject in nodeObjects)
        {
            saveNodeObjectsList.Add(nodeObject.GetSaveable());
        }

        LevelSaveable levelSave = new LevelSaveable();
        levelSave.saveLevelObjects_List = saveLevelObjects_List;
        levelSave.saveStackableObjects_List = saveStackableLevelObjects_List;
        levelSave.saveNodeObjectsList = saveNodeObjectsList;

        string saveLocation = SaveLocation(saveName);

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(saveLocation, FileMode.Create, FileAccess.Write, FileShare.None);
        formatter.Serialize(stream, levelSave);
        stream.Close();

        Debug.Log(saveLocation);
    }

    bool LoadLevel(string saveName)
    {
        bool retVal = true;
        string saveFile = SaveLocation(saveName);

        if (!File.Exists(saveFile))
        {
            retVal = false;
        }
        else
        {
            IFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(saveFile, FileMode.Open);
            LevelSaveable save = (LevelSaveable)formatter.Deserialize(stream);
            stream.Close();
            LoadLevelActual(save);
        }
        return retVal;
    }

    void LoadLevelActual(LevelSaveable levelSaveable)
    {
        // Creates level objects from save file
        for (int i = 0; i < levelSaveable.saveLevelObjects_List.Count; i++)
        {
            SaveableLevelObject s_obj = levelSaveable.saveLevelObjects_List[i];
            Node nodeToPlace = GridBase.GetInstance().grid[s_obj.posX, s_obj.posZ];
            GameObject go = Instantiate(ResourcesManager.GetInstance().GetObjBase(s_obj.obj_ID).objPrefab, nodeToPlace.vis.transform.position,
                Quaternion.Euler(
                    s_obj.rotX,
                    s_obj.rotY,
                    s_obj.rotZ))
                    as GameObject;

            nodeToPlace.placedObj = go.GetComponent<Level_Object>();
            nodeToPlace.placedObj.gridPosX = nodeToPlace.nodePosX;
            nodeToPlace.placedObj.gridPosZ = nodeToPlace.nodePosZ;
            nodeToPlace.placedObj.worldRotation = nodeToPlace.placedObj.transform.localEulerAngles;
        }

        // Creates stackable level objects from save file
        for (int i = 0; i < levelSaveable.saveStackableObjects_List.Count; i++)
        {
            SaveableLevelObject s_obj = levelSaveable.saveStackableObjects_List[i];
            Node nodeToPlace = GridBase.GetInstance().grid[s_obj.posX, s_obj.posZ];
            GameObject go = Instantiate(ResourcesManager.GetInstance().GetStackObjBase(s_obj.obj_ID).objPrefab, nodeToPlace.vis.transform.position,
                Quaternion.Euler(
                    s_obj.rotX,
                    s_obj.rotY,
                    s_obj.rotZ))
                    as GameObject;

            Level_Object stack_obj = go.GetComponent<Level_Object>();
            stack_obj.gridPosX = nodeToPlace.nodePosX;
            stack_obj.gridPosZ = nodeToPlace.nodePosZ;

            nodeToPlace.stackedObjs.Add(stack_obj);
        }
    }

    [Serializable]
    public class LevelSaveable
    {
        public List<SaveableLevelObject> saveLevelObjects_List;
        public List<SaveableLevelObject> saveStackableObjects_List;
        public List<NodeObjectSaveable> saveNodeObjectsList;
    }
}
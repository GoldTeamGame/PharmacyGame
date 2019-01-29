/* 
 * Most Recent Author: Ross     
 * Version 1.50
 * Date: 1/28/2019
 * Description: Save and load functions on awake and app quit
 * 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    private bool isPaused = false;

    private void Awake()
    {
        LoadGame();
    }

    void OnApplicationQuit()
    {
        SaveGame();
    }


    public void Pause()
    {
        SaveGame();
        //menu.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0;
        isPaused = true;

    }

    public void Unpause()
    {

        //menu.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
        isPaused = false;
    }

    public bool IsGamePaused()
    {
        return isPaused;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }
    }

    public void SaveGame()
    {
        // 1
        Save save = CreateSaveGameObject();

        // 2
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();



        Debug.Log("Game Saved");
    }

    public void NewGame()
    {
        //g = 0;
        //p = 0;
        //Text_Gold.text = g.ToString();
        //Text_Platinum.text = p.ToString();


        //ClearCustomers();


        Unpause();
    }

    //private void ClearCustomers()
    //{
    //    foreach (GameObject target in targets)
    //    {
    //        target.GetComponent<Target>().DisableRobot();
    //    }
    //}



    public void LoadGame()
    {
        // 1
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {


            // 2
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            //// 3
            //for (int i = 0; i < save.CustomerPositions.Count; i++)
            //{
            //    int position = save.CustomerPositions[i];
            //    //Target target = targets[position].GetComponent<Target>();
            //    //target.ActivateRobot((RobotTypes)save.livingTargetsTypes[i]);
            //    //target.GetComponent<Target>().ResetDeathTimer();
            //}

            // 4
           

            Globals.setGold(save.g);
            Globals.setPlatinum(save.p);
            Globals_Customer.setCustomers(save.cd);
            Globals_Customer.currentNumberOfCustomers = save.cd.Count;
            Debug.Log("Game Loaded");
            Unpause();
        }
        else
        {
            Debug.Log("No game saved!");
        }
    }

    //public void SaveAsJSON()
    //{

    //    Save save = CreateSaveGameObject();
    //    string json = JsonUtility.ToJson(save);
    //    Save save2 = JsonUtility.FromJson<Save>(json);

    //    Debug.Log("Saving as JSON: " + json);
    //}
    private Save CreateSaveGameObject()
    {
        Save save = new Save();

        //foreach (GameObject targetGameObject in targets)
        //{
        //    Target target = targetGameObject.GetComponent<Target>();
        //    if (target.activeRobot != null)
        //    {
        //        save.livingTargetPositions.Add(target.position);
        //        save.livingTargetsTypes.Add((int)target.activeRobot.GetComponent<Robot>().type);
        //        i++;
        //    }
        //}

        save.g = Globals.getGold();
        save.p = Globals.getPlatinum();
        //save.c = Globals_Customer.GetGameObjects();
        save.cd = Globals_Customer.GetCustomers();

        return save;
    }
}
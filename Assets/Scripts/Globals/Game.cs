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
    private string path = "/pharmagamesave.save";

    private void Awake()
    {
        LoadGame();
    }

    void OnApplicationQuit()
    {
        SaveGame();
    }
    private void OnApplicationPause(bool pause)
    {
        SaveGame();
    }

    //not used yet but might when go to monthly report
    public void Pause()
    {
        isPaused = true;

    }
    //not used yet but might when go to monthly report
    public void Unpause()
    {

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
        //create save object
        Save save = CreateSaveGameObject();
        BinaryFormatter bf = new BinaryFormatter();
        //write out to device with save file
        FileStream file = File.Create(Application.persistentDataPath + path);
        //add save object to file
        bf.Serialize(file, save);
        file.Close();
        Debug.Log("Game Saved");
    }

    public void LoadGame()
    {
        //check if file exists
        //if so, read file and set global varables
        
        Globals.sv = new StoreValues();
        if (File.Exists(Application.persistentDataPath + path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + path, FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            
            if (!TutorialMonitor.doesSaveExist)
                Globals_Items.generateItems(null);

            // If tutorial was finished, then load
            if (save.tutorialIndex > 17 || !TutorialMonitor.isActive)
            {
                //set globals from save object
                Clock.time = save.time;
                Globals_Tutorials.tutorialIndex = save.tutorialIndex;
                Globals.setGold(save.g);
                Globals.setPlatinum(save.p);
                if (save.cd != null)
                    Globals_Customer.setCustomers(save.cd, save.cd.Count);
                if (save.si != null)
                    Globals_Items.setItems(save.si, save.si.Count);
                Obsticals.obstical = save.obstical;
                Globals_Pharmacist.load(save.pharmacistCounter);
                if (save.item != null)
                    Globals_Items.generateItems(save.item);
                if (save.sv != null)
                    Globals.sv = save.sv;
                Globals_Items.setIsUnlocked(save.isUnlocked);
                Globals_Customer.limit = save.limit;
                Globals_Customer._limit = save._limit;
                TutorialMonitor.doesSaveExist = save.doesSaveExist;
                Calendar.isReport = save.isReport;
                Globals.month = save.month;
                Globals_Customer.cumulativeMood = save.cumulativeMood;
                Globals_Customer.customersServed = save.customersServed;
            }
            Debug.Log("Game Loaded");
            Unpause();
        }
        //no saved game, just proceed with default globals
        else
        {
            Globals_Items.generateItems(null);
            Debug.Log("No game saved!");
        }
    }
    private Save CreateSaveGameObject()
    {
        //create save object using the object class
        Save save = new Save();

        if (Globals_Tutorials.tutorialIndex > 17 || !TutorialMonitor.isActive)
        {
            //save globals, eventualy can change to a void setVarables fuction
            save.g = Globals.getGold();
            save.p = Globals.getPlatinum();
            save.cd = Globals_Customer.GetCustomers();
            save.si = Globals_Items.GetItems();
            save.obstical = Obsticals.obstical;
            save.item = Globals_Items.item;
            save.pharmacistCounter = Globals_Pharmacist.pharmacistCounter;
            save.tutorialIndex = Globals_Tutorials.tutorialIndex;
            save.sv = Globals.sv;
            save.isUnlocked = Globals_Items.isUnlocked;
            save.time = Clock.time;
            save.limit = Globals_Customer.limit;
            save._limit = Globals_Customer._limit;
            save.doesSaveExist = true;
            save.isReport = Calendar.isReport;
            save.month = Globals.month;
            save.cumulativeMood = Globals_Customer.cumulativeMood;
            save.customersServed = Globals_Customer.customersServed;
        }

        //return the object to write to the file
        return save;
    }
}
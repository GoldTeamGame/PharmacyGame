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
        Globals.generateDrugList(null);
        Globals.generateOverCounterList(null);
        Globals_Items.generateServices(null);
        if (File.Exists(Application.persistentDataPath + path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + path, FileMode.Open);
            Save save = (Save)bf.Deserialize(file);

            //set globals from save object
            Globals.setGold(save.g);
            Globals.setPlatinum(save.p);
            Globals_Customer.setCustomers(save.cd, save.cd.Count);
            Globals_Items.setItems(save.si, save.si.Count);
            Obsticals.obstical = save.obstical;
            Globals.generateDrugList(save.drugList);
            Globals.generateOverCounterList(save.overCounterList);
            Globals_Items.generateServices(save.service);
            Globals_Pharmacist.load(save.pharmacistCounter, save.pharmacistList);
            Debug.Log("Game Loaded");
            Unpause();
        }
        //no saved game, just proceed with default globals
        else
        {
            Debug.Log("No game saved!");
        }
    }
    private Save CreateSaveGameObject()
    {
        //create save object using the object class
        Save save = new Save();

        //save globals, eventualy can change to a void setVarables fuction
        save.g = Globals.getGold();
        save.p = Globals.getPlatinum();
        save.cd = Globals_Customer.GetCustomers();
        save.si = Globals_Items.GetItems();
        save.obstical = Obsticals.obstical;
        save.drugList = Globals.prescriptionList;
        save.overCounterList = Globals.overCounterList;
        save.service = Globals_Items.serviceList;
        save.pharmacistList = Globals_Pharmacist.pharmacistList;
        save.pharmacistCounter = Globals_Pharmacist.pharmacistCounter;

        //return the object to write to the file
        return save;
    }
}
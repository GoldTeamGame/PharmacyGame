// File: Service
// Author: Alexander Jacks
// Last Modified: 4/16/19
// Version: 1.0.1
// Description: Data that is stored for a unique service placement

[System.Serializable]
public class Service
{
    public string name; // name of service
    public int cost; // platinum cost to unlock service
    public bool isUnlocked; // determines if the service has been unlocked
    public bool isPlaced; // determines if the service has been placed on the storefront
    public int limit; // the max number of the particular service that you are allowed to place
    public int amount; // the number of the particular service that is currently placed down
    public string description; // info about the service

    public Service(string name, int cost, bool isUnlocked, int limit, string description)
    {
        this.name = name;
        this.cost = cost;
        this.isUnlocked = isUnlocked;
        this.limit = limit;
        this.description = description;
    }
}

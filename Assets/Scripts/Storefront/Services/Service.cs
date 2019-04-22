// File: Service
// Author: Alexander Jacks
// Last Modified: 4/21/19
// Version: 1.1.1
// Description: Data that is stored for a unique service placement

[System.Serializable]
public class Service
{
    public string name; // name of service
    public int amountPlaced; // the number of the particular service that is current placed down
    public int amountOwned; // the number of the particular service that is in the players possesion
    public string description; // info about the service

    public Service(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    // Increase amount by specified value
    public void increaseAmount(int num)
    {
        amountOwned += num;
    }

    // Returns true if the service can be placed down
    public bool isAvailable()
    {
        return amountOwned > amountPlaced;
    }
}

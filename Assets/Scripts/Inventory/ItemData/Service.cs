// File: Service
// Author: Alexander Jacks
// Last Modified: 4/21/19
// Version: 1.1.1
// Description: Data that is stored for a unique service placement

[System.Serializable]
public class Service : Item
{
    public int amountPlaced; // the number of the particular service that is current placed down
    public int amountOwned; // the number of the particular service that is in the players possesion

    public Service(string name, int price, string description)
    {
        this.name = name;
        this.price = price;
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

    override public void action()
    {
        if (Globals.playerPlatinum - price >= 0)
        {
            Globals.playerPlatinum -= price;
            isUnlocked = true;
        }
    }

    override public string generateTooltip()
    {
        return "Effects: " + description + "\nStock: " + amountPlaced + "/" + amountOwned;
    }


    public static Service[] generateServiceList()
    {
        Service[] serviceList = new Service[4];

        serviceList[0] = new Service("Shelf +1", 0, "A Fixture for displaying over the counter drugs. Customers can only buy the drugs being displayed.");
        serviceList[1] = new Service("Flu Shot Station", 10, "Flut Shot Station Description");
        serviceList[2] = new Service("Vaccine Station", 10, "Vaccine Station Description");
        serviceList[3] = new Service("Blood Pressure Monitor", 10, "Blood Pressure Monitor Description");

        return serviceList;
    }

    // Get the total amount of "name"
    public void getNumber(string name)
    {
        int count = 0;

        for (int i = 0; i < Globals_Items.item[5].Length; i++)
        {
            if (name.Equals(Globals_Items.item[5][i].name) && Globals_Items.item[5][i].isUnlocked)
                count++;
        }

        for (int i = 0; i < Globals_Items.item[5].Length; i++)
        {
            if (name.Equals(Globals_Items.item[5][i].name))
            {
                amountOwned = count;
            }
        }
    }
}

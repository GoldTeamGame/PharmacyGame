// File: CartItem
// Author: Alexander Jacks
// Last Modified: 4/15/19
// Version: 1.0.1
// Description: Represents an item picked up or being searched for
//          by a customer.

[System.Serializable]
public class CartItem
{
    public Drug drug; // the drug being searched for
    public int attempts; // the number of attempts made to search for the item
    public bool hasPickedUp; // did the customer pick the item up?

    public CartItem(Drug drug)
    {
        this.drug = drug;
    }
}

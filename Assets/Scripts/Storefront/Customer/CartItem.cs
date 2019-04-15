using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CartItem
{
    public Drug drug;
    public int attempts;
    public bool hasPickedUp;

    public CartItem(Drug drug)
    {
        this.drug = drug;
    }
}

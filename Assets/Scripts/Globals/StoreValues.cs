// File: StoreValues
// Author: Alexander Jacks
// Last Modified: 4/21/19
// Version: 1.0.1
// Description: Holds values and multipliers used throughout the game.
//          Most of these values start at 0, but additional services increase them.

[System.Serializable]
public class StoreValues
{
    // General
    public float profitMultiplier = 1.5f; // the amount of profit made from each drug
    public int customerLimitBonus = 1; // flat bonus increasing the max number of customers allowed in the store

    // Pharmacist
    public float pharmacistSpeedMultiplier = 1; // multiplier to pharmacist speed;
    public float checkoutProcessingMultiplier = 1; // multiplier to pharmacist checkout processing speed
    public float computerProcessingMultiplier = 1; // multiplier to pharmacist computer processing speed
    public float fetchProcessingMultipler = 1; // multiplier to pharmacist drug fetching processing speed

    // Customer
    public float customerSpeedMultiplier = 1; // multiplier to customer speed;
    public int moodBonus; // flat bonus applied to customer mood upon procedural generation
    public int toleranceBonus; // flat bonus applied to tolerance upon procedural generation
    public int flexibilityBonus; // flat bonus applied to flexibility upon procedural generation
}

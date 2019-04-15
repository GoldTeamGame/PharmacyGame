/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.0
 * Date: 4/11/2019
 * Description: Handles grading a submitted monthly report. Rewards platinum relative to your score. Sends you back to the game afterwards.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradeReport : MonoBehaviour {

    //Assets
    public Text AnswerGold;
    public Text AnswerInventory;
    public Text AnswerAccountsRec; //Embellish

    //Long Term Assets
    public Text AnswerEquipment;
    public Text AnswerProperty; //Embellish
    public Text AnswerPlant; //Embellish

    //Liabilities
    public Text AnswerSalaries;

    //Long Term Liabilities
    public Text AnswerObligations; //Embellish? Add loan system?

    //Owner's Equity
    public Text AnswerStock; //Embellish
    public Text AnswerCapital; //Embellish
    public Text AnswerRetained; //Embellish
    public Text AnswerEquity; //Embellish

    

    //Caution: Add a submit button to report screen.

    public void Grade()
    {
        //reward for each correct
        Globals.setPlatinum(Globals.getPlatinum() + 10);
    }

}

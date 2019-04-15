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

    /*
    Reminder on potential fields:

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
    */

    //Caution: Currently setting size of these to 3 in the inspector (only tracking answers and amounts for Assets

    public Text[] answers;
    public Text[] amounts;

    //Caution: Add a submit button to report screen
    public void Grade()
    {
        //reward for each correct
        Globals.setPlatinum(Globals.getPlatinum() + 10);
    }

    public void PopPrev()
    {
        FillArrays(answers, amounts, Globals.month);
    }

    public void FillArrays(Text[] myAnswers, Text[] myAmounts, int month)
    {
        month--;
        //fill in answers
        string[] myStringAnswers = TextToString(myAnswers);
        Globals.answers[month] = new string[myAnswers.Length];
        for(int i = 0; i < answers.Length; i++)
        {
            Globals.answers[month][i] = myStringAnswers[i];
        }
        //fill in amounts
        string[] myStringAmounts = TextToString(myAmounts);
        Globals.amounts[month] = new string[myAmounts.Length];
        for(int i = 0; i < amounts.Length; i++)
        {
            Globals.amounts[month][i] = myStringAmounts[i];
        }
    }

    public string[] TextToString(Text[] myText)
    {
        string[] myStrings = new string[myText.Length];
        for(int i = 0; i < myText.Length; i++)
        {
            myStrings[i] = myText[i].text;
        }
        return myStrings;
    }

}

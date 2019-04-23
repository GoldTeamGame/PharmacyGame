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
using System;

public class GradeReport : MonoBehaviour {

    //Assets
    public Text AnswerAssets1; // gold
    public Text AnswerAssets2; // inventory
    public Text AnswerAssets3; //accounts recievable // Embellish

    //Long Term Assets
    public Text AnswerLongTermAssets1; // equipment
    public Text AnswerLongTermAssets2; // property // Embellish
    public Text AnswerLongTermAssets3; // plant // Embellish

    //Liabilities
    public Text AnswerLiabilities1; // salaries

    //Long Term Liabilities
    public Text AnswerLongTermLiabilities1; // obligations // Embellish

    //Owner's Equity
    public Text AnswerOwners1; // stock // Embellish
    public Text AnswerOwners2; // capital // Embellish
    public Text AnswerOwners3; // retained // Embellish
    public Text AnswerOwners4; // equity // Embellish

    

    //Caution: Add a submit button to report screen.

    public void Grade()
    {
        string [] answers = new string [13];
        answers[0] = AnswerAssets1.text;
        answers[1] = AnswerAssets2.text;
        answers[2] = AnswerAssets3.text;
        answers[3] = AnswerLongTermAssets1.text;
        answers[4] = AnswerLongTermAssets2.text;
        answers[5] = AnswerLongTermAssets3.text;
        answers[6] = AnswerLiabilities1.text;
        answers[7] = AnswerLongTermLiabilities1.text;
        answers[8] = AnswerOwners1.text;
        answers[9] = AnswerOwners2.text;
        answers[10] = AnswerOwners3.text;
        answers[11] = AnswerOwners4.text;
        answers[12] = PercentGrade(answers).ToString();

        //reward for each correct
        Console.WriteLine(PercentGrade(answers));
        Globals.setPlatinum(Globals.getPlatinum() +(int)(10 * PercentGrade(answers)));
    }

    public double PercentGrade(string [] answers){
        int count = 0;
        string currAnswer = ""; 

        // grade assests
        currAnswer = answers[0].Split(':')[0];
        if(currAnswer == "Cash" || currAnswer == "Inventory" || currAnswer == "Accounts Rec"){
            count++;
        }

        currAnswer = answers[1].Split(':')[0];
        if(currAnswer == "Cash" || currAnswer == "Inventory" || currAnswer == "Accounts Rec"){
            count++;
        }

        currAnswer = answers[2].Split(':')[0];
        if(currAnswer == "Cash" || currAnswer == "Inventory" || currAnswer == "Accounts Rec"){
            count++;
        }

        // grade long term assests
        currAnswer = answers[3].Split(':')[0];
        if(currAnswer == "Equipment" || currAnswer == "Property" || currAnswer == "Plant"){
            count++;
        }
        
        currAnswer = answers[4].Split(':')[0];
        if(currAnswer == "Equipment" || currAnswer == "Property" || currAnswer == "Plant"){
            count++;
        }
        
        currAnswer = answers[5].Split(':')[0];
        if(currAnswer == "Equipment" || currAnswer == "Property" || currAnswer == "Plant"){
            count++;
        }

        // grade liabilities
        currAnswer = answers[6].Split(':')[0];
        if(currAnswer == "Salaries"){
            count++;
        }

        // grade long term liabilities
        currAnswer = answers[7].Split(':')[0];
        if(currAnswer == "Obligations"){
            count++;
        }

        // grade owners equity
        currAnswer = answers[8].Split(':')[0];
        if(currAnswer == "Stock" || currAnswer == "Capital" || 
        currAnswer == "Retained" || currAnswer == "Equity"){
            count++;
        }
        
        currAnswer = answers[9].Split(':')[0];
        if(currAnswer == "Stock" || currAnswer == "Capital" || 
        currAnswer == "Retained" || currAnswer == "Equity"){
            count++;
        }
        
        currAnswer = answers[10].Split(':')[0];
        if(currAnswer == "Stock" || currAnswer == "Capital" || 
        currAnswer == "Retained" || currAnswer == "Equity"){
            count++;
        }
        
        currAnswer = answers[11].Split(':')[0];
        if(currAnswer == "Stock" || currAnswer == "Capital" || 
        currAnswer == "Retained" || currAnswer == "Equity"){
            count++;
        }

        return ((double)count) / 12;
    }

}

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
    public Text AnswerAssets1; // gold
    public Text AnswerAssets2; // inventory
    public Text AnswerAssets3; //accounts recievable

    //Long Term Assets
    public Text AnswerLongTermAssets1; // equipment
    public Text AnswerLongTermAssets2; // property
    public Text AnswerLongTermAssets3; // plant

    //Liabilities
    public Text AnswerLiabilities1; // salaries

    //Long Term Liabilities
    public Text AnswerLongTermLiabilities1; // obligations

    //Owner's Equity
    public Text AnswerOwners1; // stock
    public Text AnswerOwners2; // capital
    public Text AnswerOwners3; // retained
    public Text AnswerOwners4; // equity

    

    //Caution: Add a submit button to report screen.

    public void Grade()
    {
        string [] answers = new string [12];
        answers[0] = AnswerAssets1;
        answers[1] = AnswerAssets2;
        answers[2] = AnswerAssets3;
        answers[3] = AnswerLongTermAssets1;
        answers[4] = AnswerLongTermAssets2;
        answers[5] = AnswerLongTermAssets3;
        answers[6] = AnswerLiabilities1;
        answers[7] = AnswerLongTermLiabilities1;
        answers[8] = AnswerOwners1;
        answers[9] = AnswerOwners2;
        answers[10] = AnswerOwners3;
        answers[11] = AnswerOwners4;
        
        
        

        //reward for each correct
        Globals.setPlatinum(Globals.getPlatinum() + 10);
    }

    public double PercentGrade(string [] answers){
        int count = 0;

        // grade assests
        

        // grade long term assests

        // grade liabilities

        // grade long term liabilities

        // grade owners equity
    }

}

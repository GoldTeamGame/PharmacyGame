/* 
 * Most Recent Author: Dylan Cyphers
 * Version 1.0
 * Date: 3/19/2019
 * Description: Displays the expansion items alongside their price. Buttons are used as tabs, limiting the display.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayExpansions : MonoBehaviour {

    public Button fluBtn;
    public Text fluText;
    public Button vacBtn;
    public Text vacText;
    public Button vitaminsBtn;
    public Text vitaminsText;
    public Button setCBtn;
    public Text setCText;
    public Button employeeCapBtn;
    public Text employeeCapText;
    public Button nextStoreBtn;
    public Text nextStoreText;

    /* The selector [0,2] is the int used to designate which parts of the scrollbar are displayed
    *  0: Sets
    *  1: Upgrades
    *  2: Fixtures
    */
    public int selector;

    public Button[] tabButtons;

    public void SetSelector(int sel)
    {
        selector = sel;
    }

    void Update()
    {
        //Testing Limited Display
        //Reminder: 0 === Sets
        if (selector == 0)
        {
            vitaminsBtn.gameObject.SetActive(true);
            setCBtn.gameObject.SetActive(true);

            employeeCapBtn.gameObject.SetActive(false);
            nextStoreBtn.gameObject.SetActive(false);

            fluBtn.gameObject.SetActive(false);
            vacBtn.gameObject.SetActive(false);
        }
        //Reminder: 1 === Uprgrades
        else if (selector == 1)
        {
            vitaminsBtn.gameObject.SetActive(false);
            setCBtn.gameObject.SetActive(false);

            employeeCapBtn.gameObject.SetActive(true);
            nextStoreBtn.gameObject.SetActive(true);

            fluBtn.gameObject.SetActive(false);
            vacBtn.gameObject.SetActive(false);
        }
        //Reminder: 2 === Fixtures
        else if (selector == 2)
        {
            vitaminsBtn.gameObject.SetActive(false);
            setCBtn.gameObject.SetActive(false);

            employeeCapBtn.gameObject.SetActive(false);
            nextStoreBtn.gameObject.SetActive(false);

            fluBtn.gameObject.SetActive(true);
            vacBtn.gameObject.SetActive(true);
        }
    }
}

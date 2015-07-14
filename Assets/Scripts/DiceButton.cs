// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DiceButton : MonoBehaviour
{
    public Text ResultText;
    public GameObject DiceToRoll;


    public void RollTheDice()
    {
        int DiceSum = DiceToRoll.GetComponent<RollDice>().RollFourDice();
        ResultText.text = "Roll Result: " + DiceSum.ToString();
    }
}

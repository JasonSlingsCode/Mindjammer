// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RollDice : MonoBehaviour {

    public int Sum;
    public Text RollResult;

    public int RollFourDice() {

        int Roll1 = Random.Range(-1, 2);
        int Roll2 = Random.Range(-1, 2);
        int Roll3 = Random.Range(-1, 2);
        int Roll4 = Random.Range(-1, 2);
        Sum = Roll1 + Roll2 + Roll3 + Roll4;
        return Sum;
    }

    public int RollOneDie() {
        
        int Roll1 = Random.Range(-1, 2);
        Sum = Roll1;
        return Sum;
    }
}

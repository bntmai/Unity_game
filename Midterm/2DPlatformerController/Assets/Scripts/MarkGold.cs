using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkGold : MonoBehaviour
{
    public int mark = 0;

    public void addMark(int coin){
    	mark = mark + coin;
    }
}

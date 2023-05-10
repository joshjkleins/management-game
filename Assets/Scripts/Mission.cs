using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission
{
    public string location;
    public string boss;
    public int timeToComplete;
    public int experience;

    public Mission(string loc, string bos, int tim, int exp) {
        location = loc;
        boss = bos;
        timeToComplete = tim;
        experience = exp;
    }

    public Mission() {
        location = "test location";
        boss = "test boss";
        timeToComplete = 30;
        experience = 100;
    }
}

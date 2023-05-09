using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTransitions : MonoBehaviour
{

    public GameObject minions;
    public GameObject missions;

    public void showMissions() {
        minions.SetActive(false);
        missions.SetActive(true);
    }

    public void showMinions() {
        minions.SetActive(true);
        missions.SetActive(false);
    }

}

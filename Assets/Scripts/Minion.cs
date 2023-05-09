using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    public enum MinionClass {Warrior, Mage, Rogue, Priest}

    public MinionClass minClass;

    // Start is called before the first frame update
    void Start()
    {
        minClass = (MinionClass)Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

using UnityEngine;
using System.Collections;
using CardGameTypes;
using System.Collections.Generic;
using System;

public class NeutralCard : Card 
{
    #region Fields

    public Dictionary<string, Action> MinionPowers;
    public NeutralPowerType SelectedPower;
    private Action OwnMinionPower;

    #endregion //Fields

    #region Unity Methods

    public void Initalize()
    {
        MinionPowers = new Dictionary<string, Action>();
        MinionPowers.Add("Taunt", Taunt);
        MinionPowers.Add("Charge", Charge);
        MinionPowers.Add("Trap", Trap);
        Debug.Log("Minnion Card Initialize Finished");
    }

    #endregion //Unity Methods

    #region Abilities

    public void Taunt()
    {

    }

    public void Charge()
    {

    }

    public void Trap()
    {

    }

    #endregion // Abilities
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using CardGameTypes;

public class SpecialCard : Card 
{
    #region Fields

    public Dictionary<string, Action> SpecialPower;
    public SpecialPowerType SelectedPower;
    private Action OwnSpeacialPower;

    #endregion //Fields

    #region Unity Methods

    public void Initalize()
    {
        SpecialPower = new Dictionary<string, Action>();
        SpecialPower.Add("Taunt", Taunt);
        SpecialPower.Add("Charge", Charge);
        SpecialPower.Add("Trap", Trap);
        Debug.Log("Speacial Card Initialize Finished");
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

    public void DealDamage() // Select your card and attack.
    {
        Debug.Log("sa");
        //mDescription = "Deal 6 damage";
    }

	#endregion // Abilities
}

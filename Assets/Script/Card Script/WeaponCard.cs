using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using CardGameTypes;

public class WeaponCard : Card
{
	#region Fields

    public Dictionary<string, Action> WeaponSpecialPowers; // Editor Script' 
    private Action OwnSpecialPower;
    public WeaponPowerType SelectedPower;

	#endregion //Fields

	#region Public Methods

    public void Initialize()
    {
        WeaponSpecialPowers = new Dictionary<string, Action>();
        WeaponSpecialPowers.Add("Vur", HealthDamage);
        Debug.Log("WeaponCard Initialize Finished");
    }

	#endregion // Public Methods

    #region Ability

    public void HealthDamage()
    {
        Debug.Log("ASDS");
        // Öylesine special power denemesi
    }

    #endregion // Ability
}

/*
 * Special Power Dictionary dizim var bunun bir string key i var . Bu string key i json dan cekerek .Buna vericem adamın weapon card ını böyle belirleyeceğim.
 * 
*/
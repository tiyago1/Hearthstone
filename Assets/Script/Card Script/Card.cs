using UnityEngine;
using System.Collections;
using CardGameTypes;

public class Card : ScriptableObject 
{
	#region Properties

    public int ID;
    public string Name;     
    public int HP;          
    public int AttackDamage;
    public int ManaCost;
    public string Description;
    public ClassType Owner;
    public CardType CardType;

    #endregion // Properties
}


/*
   Note
 * http://us.battle.net/hearthstone/en/game-guide/heroes
 * http://hearthstone.gamepedia.com/Card
 *  
*/
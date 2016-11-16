using UnityEngine;
using System.Collections;

public class PlayerClass : MonoBehaviour 
{
	#region Properties

    public int HP          { get; set; }
    public int Shield      { get; set; }
    public int Attack      { get; set; }
    public int SpellDamage { get; set; }
    public int SpellShield { get; set; }
    public int Mana        { get; set; }

    #endregion // Properties

    #region Virtual Methods

    public virtual void SetCard(Card card)
    {

    }

    #endregion // Virtual Methods

}

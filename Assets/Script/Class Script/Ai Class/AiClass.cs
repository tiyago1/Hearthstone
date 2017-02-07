using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AiClass : MonoBehaviour 
{
    #region Player Properties

    public int HP           { get; set; }
    public int Shield       { get; set; }
    public int Attack       { get; set; }
    public int SpellDamage  { get; set; }
    public int SpellShield  { get; set; }
    public int Mana         { get; set; }

    #endregion // Player Properties

    #region Fields

    public List<Card> Cards = new List<Card>();
    public CardDeckUIElement CardDeckUIElement;
    public BattleFieldUI BattleFieldUIManager;
    public CardConfirmationPanel CardConfirmationPanel;
    // Bir Player'ın GameManager ı bilmesine gerek varmı ?

    public bool IsInitedInitialize = false;

    #endregion // Fields

    #region Virtual Methods

    public virtual void Initialize()
    {
        IsInitedInitialize = true;
    }

    public virtual void SetCard(Card card)
    {

    }

    #endregion // Virtual Methodss

    #region Private Methods

    //private void OnFinishedInitialize()
    //{
    //    if (FinishedInitialize != null)
    //    {
    //        FinishedInitialize();
    //    }
    //}

    #endregion // Private Methods 
}

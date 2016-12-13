using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CardGameTypes;
using UnityEngine.UI;

public class MinionUIElement : GuiPanel
{
    #region Fields

    public Card CardData;

    public int Index;
    public Image CardImage;
    public NumberUIElement AttacDamage;
    public NumberUIElement Hp;

    #endregion //Fields

    #region Public Methods

    public void SetMinionProperties(Card data, int index)
    {
        Index = index;
        CardData = data;
        AttacDamage.gameObject.SetActive(true);
        Hp.gameObject.SetActive(true);
        AttacDamage.SetNumberImage(data.AttackDamage);
        Hp.SetNumberImage(data.HP);
    }

    #endregion // Public Methods

    #region Events

    public void AddMinionButtonListener(int index)
    {
        if (mIngameUIManager != null)
        {
            this.GetComponent<Button>().onClick.AddListener(() => mIngameUIManager.PlayerBattleFieldUIManager.OnPlayerMinionSelected(index));
        }
    }

    public void AddAgentMinionButtonListener(int index)
    {
        if (mIngameUIManager != null)
        {
            this.GetComponent<Button>().onClick.AddListener(() => mIngameUIManager.EnemyBattleFieldUIManager.OnAgentMinionSelected(index));
        }
    }

    #endregion // Events
}

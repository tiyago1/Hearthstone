using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class BattleFieldMinionControler : HearthBehaviour 
{
	#region Fields

    public event Action<Card> SelectedMinion;
    public MinionUIElement MinionUIElement;
    public Card CardData;
    public MinionAnimationStateController mMinionAnimationStateController;
    public Button MinionButton;

    private bool mIsAgent;

	#endregion //Fields
	
	#region Public Methods
	
	public override void Initialize(InGameUIManager inGameUIManager)
	{
        mIngameUIManager = inGameUIManager;
        mMinionAnimationStateController.Initialize();
        MinionUIElement.Initialize(inGameUIManager);
        MinionButton = this.GetComponent<Button>();
	}

    public void InitData(int index, Card cardData, bool isAgent)
    {
        MinionUIElement.SetMinionProperties(cardData, index);
        CardData = cardData;

        mIsAgent = isAgent;

        if (isAgent)
            AddAgentMinionButtonListener(index);
        else
            AddMinionButtonListener(index);
    }

    public void UpdateIndex(int index)
    {
        MinionUIElement.Index = index;

        if (mIsAgent)
            AddAgentMinionButtonListener(index);
        else
            AddMinionButtonListener(index);
    }

	#endregion // Public Methods

    #region Events

    public void AddMinionButtonListener(int index)
    {
        if (mIngameUIManager != null)
        {
            MinionButton.onClick.RemoveAllListeners();
            MinionButton.onClick.AddListener(() => mIngameUIManager.PlayerBattleFieldUIManager.OnMinionSelected(index));
        }
    }

    public void AddAgentMinionButtonListener(int index)
    {
        if (mIngameUIManager != null)
        {
            MinionButton.onClick.RemoveAllListeners();
            MinionButton.onClick.AddListener(() => mIngameUIManager.EnemyBattleFieldUIManager.OnMinionSelected(index));
        }
    }

    #endregion // Events
}

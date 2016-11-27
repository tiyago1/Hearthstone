using UnityEngine;
using System;
using System.Collections;

public class CardConfirmationPanel : GuiPanel 
{
	#region Fields

    public CardUIElement mCardUIElement;
    public event Action<int> OnPlayerCardConfimated;
    public event Action<int> OnAgentCardConfirmated;

	#endregion //Fields
	
	#region Public Methods

	public override void Initialize(InGameUIManager inGameUIManager)
	{
        base.Initialize(inGameUIManager);
        mCardUIElement = this.GetComponent<CardUIElement>();
	}

    public void SetCardData(Card data, int index)
    {
        mCardUIElement.SetCardProperties(data, index);
    }

	#endregion // Public Methods

    #region Events

    /// <summary>
    /// Bind button click event to Button_PutBattlefield
    /// </summary>
    public void OnCardConfirmatedClicked()
    {
        OnPlayerCardConfimated(mCardUIElement.Index);
    }

    public void OnAgentCardConfirim()
    {
        OnAgentCardConfirmated(mCardUIElement.Index);
    }

    #endregion // Events
}

using UnityEngine;
using System;
using System.Collections;

public class CardConfirmationPanel : HearthBehaviour 
{
	#region Fields

    public CardUIElement mCardUIElement;
    public event Action<int> OnPlayerCardConfimated;
    public event Action<int> OnAgentCardConfirmated;

    private Card mCardData;

	#endregion //Fields
	
	#region Public Methods

	public override void Initialize(InGameUIManager inGameUIManager)
	{
        base.Initialize(inGameUIManager);
        mCardUIElement = this.GetComponent<CardUIElement>();
        mCardData = null;
	}

    public void SetCardData(Card data, int index)
    {
        if (data != null)
        {
            mCardData = data;
            mCardUIElement.SetCardProperties(mCardData, index);
            this.gameObject.SetActive(true);
        }
    }

	#endregion // Public Methods

    #region Events

    /// <summary>
    /// Bind button click event to Button_PutBattlefield
    /// </summary>
    public void OnCardConfirmatedClicked()
    {
        OnPlayerCardConfimated(mCardUIElement.Index);
        mCardData = null;
        this.gameObject.SetActive(false);
    }
    
    public void OnAgentCardConfirmatedClicked()
    {
        OnAgentCardConfirmated(mCardUIElement.Index);
        mCardData = null;
        this.gameObject.SetActive(false);
    }

    #endregion // Events
}

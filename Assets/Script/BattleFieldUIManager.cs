using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class BattleFieldUIManager : GuiPanel
{
    #region Constants

    public const string GROW = "Grow";
    public const string SHRINK = "Shrink";
    public const string NORMAL = "Normal";
    #endregion // Constants

    #region Fields

    public List<Card> Cards = new List<Card>();
    public List<Animator> CardAnimators = new List<Animator>();

    public Action OnPlayerCardDestroyed;
    public Action OnEnemyCardDestroyed;

    public GameObject MinionPrefab;

    private int mCounter;

	#endregion //Fields
	
	#region Public Methods
	
	public override void Initialize(InGameUIManager ingameUIManager)
	{
        base.Initialize(ingameUIManager);
        mCounter = 0;
	}

    public void PutBattleField(Card data, bool isAgent = false)
    {
        GameObject minion = Instantiate(MinionPrefab) as GameObject;
        minion.transform.SetParent(this.transform, false);
        CardAnimators.Add(minion.GetComponent<Animator>());
        MinionUIElement element = minion.GetComponent<MinionUIElement>();
        element.Initialize(mIngameUIManager);
        element.Index = mCounter;
        element.SetMinionProperties(data, element.Index);
        mCounter++;

        if (isAgent)
            element.AddAgentMinionButtonListener(element.Index);
        else
            element.AddMinionButtonListener(element.Index);
    }

	#endregion // Public Methods

    #region Private Methods

    private void SetAnimatorState(int index)
    {
        for (int i = 0; i < CardAnimators.Count; i++)
        {
            if (i != index && CardAnimators[i].GetBool("IsGrowed"))
            {
                CardAnimators[index].SetTrigger(SHRINK);
                CardAnimators[index].SetBool("IsGrowed", false);
                CardAnimators[index].SetBool("IsShrinked", true);        
            }
        }

        CardAnimators[index].SetTrigger(GROW);
        CardAnimators[index].SetBool("IsGrowed", true);
    }
    
    #endregion // Private Methods

    #region Events

    public void OnPlayerMinionSelected(int index)
    {
        SetAnimatorState(index);
    }

    public void OnAgentMinionSelected(int index)
    {
        SetAnimatorState(index);
    }

    #endregion // Events

}

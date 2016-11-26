using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleFieldUIManager : GuiPanel 
{
	#region Fields

    public List<Card> Cards = new List<Card>();
    public List<Animator> CardAnimators = new List<Animator>();

    public Action OnPlayerCardDestroyed;
    public Action OnEnemyCardDestroyed;

    public GameObject MinionPrefab;

    private int mCounter;

	#endregion //Fields
	
	#region Unity Methods
	
	private void Update () 
	{
	 
	}
	
	#endregion //Unity Methods
	
	#region Public Methods
	
	public override void Initialize(InGameUIManager ingameUIManager)
	{
        base.Initialize(ingameUIManager);
        mCounter = 0;
	}

    public void PutBattleField(Card data)
    {
        GameObject minion = Instantiate(MinionPrefab) as GameObject;
        minion.transform.SetParent(this.transform,false);
        CardAnimators.Add(minion.GetComponent<Animator>());
        CardUIElement element = minion.GetComponent<CardUIElement>();
        element.Initialize(mIngameUIManager);
        element.Index = mCounter;
        element.SetMinionProperties(data, element.Index);
        mCounter++;
    }

    public void OnMinionSelected(int index)
    {
        CardAnimators[index].SetTrigger("Grow");
    }

	#endregion // Public Methods
	
	#region Private Methods

	#endregion //Private Methods
}

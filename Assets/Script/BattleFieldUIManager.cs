using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class BattleFieldUIManager : HearthBehaviour
{
    #region Fields

    public List<Card> Cards = new List<Card>();
    public List<BattleFieldMinionControler> BattleFieldCardControllers;

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

        BattleFieldMinionControler element = minion.GetComponent<BattleFieldMinionControler>();

        element.Initialize(mIngameUIManager);
        BattleFieldCardControllers.Add(element);
        element.InitData(mCounter, data, isAgent);
        mCounter++;        
    }

	#endregion // Public Methods

    #region Private Methods

    private void SetAnimatorState(int index)
    {
        if (BattleFieldCardControllers[index].mMinionAnimationStateController.IsGrowing)
        {
            BattleFieldCardControllers[index].mMinionAnimationStateController.Shrink();
        }
        else
        {
            List<MinionAnimationStateController> growedMinions = BattleFieldCardControllers.Where(it => it.mMinionAnimationStateController.IsGrowing == true).Select(it => it.mMinionAnimationStateController).ToList();
            growedMinions.ForEach(it => it.Shrink());

            BattleFieldCardControllers[index].mMinionAnimationStateController.Grow();
        }
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

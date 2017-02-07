using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class BattleFieldUI : HearthBehaviour 
{
    #region Fields

    public GameObject MinionPrefab;

    public List<Card> Minions = new List<Card>();
    public List<BattleFieldMinionControler> BattleFieldMinionControllers;

    public event Action<Card> MinionSelected;
    public event Action MinionDeselected;
    private int mCounter;

    private int mSelectedCardIndex;


    #endregion //Fields

    #region Public Methods

    public virtual void Initialize(InGameUIManager ingameUIManager)
    {
        base.Initialize(ingameUIManager);
        mCounter = 0;
    }

    public virtual void PutTheBattleField(Card data, bool isAgent = false)
    {
        GameObject minion = Instantiate(MinionPrefab) as GameObject;
        minion.transform.SetParent(this.transform, false);

        BattleFieldMinionControler element = minion.GetComponent<BattleFieldMinionControler>();
        Minions.Add(data);
        element.Initialize(mIngameUIManager);
        BattleFieldMinionControllers.Add(element);
        element.InitData(mCounter, data, isAgent);
        mCounter++;
    }

    public virtual void DestroyMinion()
    {
        Debug.Log("Cards.Count" + Minions.Count() + " mSelectedCardIndex : " + mSelectedCardIndex);
        Minions.RemoveAt(mSelectedCardIndex);
        Destroy(BattleFieldMinionControllers[mSelectedCardIndex].gameObject);
        BattleFieldMinionControllers.RemoveAt(mSelectedCardIndex);

        for (int i = 0; i < BattleFieldMinionControllers.Count; i++)
        {
            Debug.Log(i);
            BattleFieldMinionControllers[i].UpdateIndex(i);
        }

        // this destroyed to selected minion
    }

    public virtual void DecraseHealthMinion(int finalHealth)
    {
        BattleFieldMinionControllers[mSelectedCardIndex].MinionUIElement.Hp.SetNumberImage(finalHealth);
        BattleFieldMinionControllers[mSelectedCardIndex].mMinionAnimationStateController.Shrink();
    }

    #endregion // Public Methods

    #region Private Methods

    public void SetAnimatorState(int index)
    {
        Debug.Log("BattleFieldMinionControllers[index].mMinionAnimationStateController.IsGrowing : " + BattleFieldMinionControllers[index].mMinionAnimationStateController.IsGrowing);
        if (BattleFieldMinionControllers[index].mMinionAnimationStateController.IsGrowing)
        {
            BattleFieldMinionControllers[index].mMinionAnimationStateController.Shrink();
            OnMinionDeselected();
        }
        else
        {
            List<MinionAnimationStateController> growedMinions = BattleFieldMinionControllers.Where(it => it.mMinionAnimationStateController.IsGrowing == true).Select(it => it.mMinionAnimationStateController).ToList();
            Debug.Log("SetAnimator State index : " + index);
            Debug.Log("growedMinion : " + growedMinions.Count());

            if (growedMinions.Count() != 0)
            {
                growedMinions.ForEach(it => it.Shrink());
            }

            BattleFieldMinionControllers[index].mMinionAnimationStateController.Grow();
            OnMinionSelected(Minions[index]);
            mSelectedCardIndex = index;
        }
    }

    private void OnMinionSelected(Card data)
    {
        if (MinionSelected != null)
        {
            MinionSelected(data);
        }
    }

    private void OnMinionDeselected()
    {
        if (MinionDeselected != null)
        {
            MinionDeselected();
        }
    }

    #endregion // Private Methods

    #region Events

    public virtual void OnMinionSelected(int index)
    {
        Debug.Log("On minion Selected : " + index);
        SetAnimatorState(index);
    }

    #endregion // Events
}

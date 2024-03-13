using AtoGame.Base;
using ScratchCardAsset;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DP
{
    public class Step : MonoBehaviour
    {
        [SerializeField] private ScratchCardManager[] allScratchCards;
        [SerializeField] private ConditionMono winCondition;

        private int tounchScratchCount;
        private Action onComplete;

        public void InitStep()
        {
            foreach (var card in allScratchCards)
            {
                card.Card.Init();
            }
        }


        public void StartStep()
        {
            tounchScratchCount = 0;
            foreach (var card in allScratchCards)
            {
                card.Card.ScratchCardInput.OnBeginScratch += OnBeginScratch;
                card.Card.ScratchCardInput.OnEndScratch += OnEndScratch;
            }
        }

        private void RestartStep()
        {
            tounchScratchCount = 0;
            foreach (var card in allScratchCards)
            {
                card.Card.ClearInstantly();

                if (card.Progress != null)
                {
                    card.Progress.ResetProgress();
                    card.Progress.UpdateProgress();
                }

            }
        }

        public void EndStep()
        {
            foreach (var card in allScratchCards)
            {
                card.Card.ScratchCardInput.OnBeginScratch -= OnBeginScratch;
                card.Card.ScratchCardInput.OnEndScratch -= OnEndScratch;
            }
        }

        private void OnBeginScratch()
        {
            tounchScratchCount++;

        }

        private void OnEndScratch()
        {
            tounchScratchCount--;
            if (tounchScratchCount <= 0)
            {
                CheckWin();
            }
        }

        private void CheckWin()
        {
            Debug.Log(gameObject.name);
            bool isWin = winCondition.CheckCondition();

            if (isWin)
            {
                onComplete?.Invoke();
            }
            else
            {
                RestartStep();
            }
        }

        public void SetOnComplete(Action onComplete)
        {
            this.onComplete = onComplete;
        }
    }
}

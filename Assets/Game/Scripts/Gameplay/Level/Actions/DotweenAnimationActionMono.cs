using AtoGame.Base;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DP
{
    public class DotweenAnimationActionMono : ActionMono
    {
        [SerializeField] private DOTweenAnimation startAnim;
        [SerializeField] private DOTweenAnimation endAnim;

        private Action onCompleted;
        public override void Execute(Action onCompleted = null)
        {
            this.onCompleted = onCompleted;
            startAnim?.DOPlay();
            if(endAnim != null)
            {
                if(endAnim.onComplete == null)
                {
                    endAnim.onComplete = new UnityEngine.Events.UnityEvent();
                }
                endAnim.onComplete.AddListener(OnComplete);
            }
        }

        private void OnComplete()
        {
            onCompleted?.Invoke();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AtoGame.TheKiwiCoder.BT
{
    public class Breakpoint : ActionNode
    {
        protected override void OnStart()
        {
            Debug.Log("Trigging Breakpoint");
            Debug.Break();
        }

        protected override void OnStop()
        {
        }

        protected override State OnUpdate()
        {
            return State.Success;
        }
    }
}
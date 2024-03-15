using AtoGame.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DP
{
    public class GameplayCamera : SingletonBind<GameplayCamera>
    {
        [SerializeField] private Camera _camera;

        public Camera Camera => _camera;

        protected override void OnAwake()
        {
            if(_camera == null)
            {
                _camera = GetComponent<Camera>();
            }
        }
    }
}

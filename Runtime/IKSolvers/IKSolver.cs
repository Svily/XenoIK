﻿using System;
using UnityEngine;

namespace XenoIK
{
    [Serializable]
    public abstract class IKSolver
    {
        public bool initiated { get; private set; }
        public bool firstInitiated = true;
        public Vector3 IKPosition;
        public Transform root;
        [Range(0, 1f)]
        public float IKWeight = 1f;
        
        public void Update(float deltaTime)
        {
            OnUpdate(deltaTime);
        }

        public void Init(Transform root)
        {
            if (this.root == null) this.root = root;
            this.OnInitialize();
            this.initiated = true;
            this.firstInitiated = false;
            this.StoreDefaultLocalState();
        }
        
        protected abstract void OnInitialize();
        protected abstract void OnUpdate(float deltaTime);
        public abstract void StoreDefaultLocalState();
        public abstract void FixTransform();
    }
}
using System;
using UnityEngine;

namespace _Main_Work.Dam.Temp
{
    public class BoClass : MonoBehaviour
    {

        public Action vaotran;


        public void Danhnhau()
        {
            
        }

        private void Awake()
        {
            vaotran += Danhnhau;
            vaotran?.Invoke();
        }

        public virtual void Start()
        {
            
        }
    }
}
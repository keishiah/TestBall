using System;
using CodeBase.Data;
using UnityEngine;

namespace CodeBase.Services.PlayerProgressService
{
    public class PlayerProgressService : IPlayerProgressService
    {
        public PlayerProgress Progress { get; set; }
    }


}
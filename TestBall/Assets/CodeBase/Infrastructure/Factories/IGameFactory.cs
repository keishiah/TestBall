using System.Collections.Generic;
using CodeBase.Services.PlayerProgressService;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
    public interface IGameFactory
    {
        void Cleanup();

        // List<IProgressReader>  ProgressReaders { get; }
        // List<IProgressSaver> ProgressSavers { get; }
        GameObject CreateRacket(Vector3 at);
        GameObject CreateBall(Vector3 at);
        void CreateGameobjectsRoot();
    }
}
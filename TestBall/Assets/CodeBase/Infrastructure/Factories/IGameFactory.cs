using System.Collections.Generic;
using CodeBase.Services.PlayerProgressService;

namespace CodeBase.Infrastructure.Factories
{
    public interface IGameFactory
    {
        void Cleanup();
        void CreateTestMono();
        List<IProgressReader>  ProgressReaders { get; }
        List<IProgressSaver> ProgressSavers { get; }
    }
}
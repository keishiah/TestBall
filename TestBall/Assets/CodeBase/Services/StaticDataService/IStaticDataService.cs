using System.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Services.StaticDataService
{
    public interface IStaticDataService
    {
        void Initialize();
        Color[] _colors { get; set; }
    }
}
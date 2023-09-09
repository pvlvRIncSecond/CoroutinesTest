using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Indicators
{
    public class IndicatorsImageHolder : MonoBehaviour
    {
        public List<Indicator> Indicators => _indicators;

        [SerializeField] private List<Indicator> _indicators;
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Indicators
{
    public class IndicatorsImageHolder : MonoBehaviour
    {
        public List<Image> Indicators => _indicators;

        [SerializeField] private List<Image> _indicators;
    }
}

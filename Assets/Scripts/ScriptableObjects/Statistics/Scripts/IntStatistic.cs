using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new IntStatistic", menuName = "Statistics/IntStatistic")]
public class IntStatistic : Statistic
{
    [SerializeField] private IntVariable statValue;

    public override string GetFormattedStat()
    {
        switch (format)
        {
            case FormatAs.Simple:
                return $"{statValue.Value}";
            case FormatAs.Money:
                return $"${statValue.Value}";
            case FormatAs.Time:
                break;
        }

        return "No value.";
    }
}

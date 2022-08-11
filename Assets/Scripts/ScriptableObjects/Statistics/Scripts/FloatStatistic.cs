using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new FloatStatistic", menuName = "Statistics/FloatStatistic")]
public class FloatStatistic : Statistic
{
    [SerializeField] private FloatVariable statValue;

    public override string GetFormattedStat()
    {
        switch (format)
        {
            case FormatAs.Simple:
                return $"{statValue.Value}";
            case FormatAs.Money:
                return $"${statValue.Value}";
            case FormatAs.Time:
                if (statValue.Value > 60f)
                {
                    return $"{Mathf.Floor(statValue.Value / 60f)}h {Mathf.FloorToInt(statValue.Value % 60)}m";
                }
                return $"{Mathf.FloorToInt(statValue.Value)}m";
        }

        return "No value.";
    }
}

using System.Collections.Generic;
using UnityEngine;
using VInspector;

public class CharacterStatistics : MonoBehaviour
{
    [ReadOnly] [SerializeField] private SerializedDictionary<StatisticType, CharacterStatistic> _statistics;

    private void Start()
    {
        InitStatistics();
    }

    public CharacterStatistic GetStatistic(StatisticType type)
    {
        return _statistics[type];
    }
    
    private void InitStatistics()
    {
        //later on, check what class are we playing and load the initial data from ClassStatisticsData (SO) + loaded data from saved file (permamently modified statistics)
        
        _statistics = new SerializedDictionary<StatisticType, CharacterStatistic>();
        
        _statistics[StatisticType.STRENGTH] = new CharacterStatistic(10f, 100f); 
        _statistics[StatisticType.INTELLIGENCE] = new CharacterStatistic(10f, 100f);
        _statistics[StatisticType.DEXTERITY] = new CharacterStatistic(10f, 100f);
        _statistics[StatisticType.CRIT_CHANCE] = new CharacterStatistic(0.1f, 1f); 
        _statistics[StatisticType.CRIT_DAMAGE] = new CharacterStatistic(1.5f, 2f);
        _statistics[StatisticType.ARMOR] = new CharacterStatistic(0f, 100f);
        _statistics[StatisticType.INITIAVITE] = new CharacterStatistic(5f, 100f);
    }
}
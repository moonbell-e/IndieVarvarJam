using Battle.Controller;
using System.Collections.Generic;
using UnityEngine;
using Units;
#if UNITY_EDITOR //Editor only pre-processor
using UnityEditor;
#endif 
namespace Battle.Group
{
    public class GuardGroup : MonoBehaviour, IBattleEvent
    {
        public event SendBattleData BattleEventStarted;
        [SerializeField]
        private List<GuardSO> _guardsSO;
        [SerializeField]
        private int _guardsMinCount;
        [SerializeField]
        private int _guardsMaxCount;
        private List<LoadGuardData> _loadGuardsData; 

        private void Awake()
        {
            _loadGuardsData = new List<LoadGuardData>();
            int count = Random.Range(_guardsMinCount, _guardsMaxCount);   
            for(int i = 0; i < count; i++)
            {
                int index = Random.Range(0, _guardsSO.Count);
                AddGuard(_guardsSO[index]);
            }
        }

        //[ContextMenu ("Find spells")]
        //private void FindSpells()
        //{
        //    string[] spellsGUID = AssetDatabase.FindAssets("t:GuardSO", new[] {"Assets/Units/ScriptableObjects/GuardsSO"});
        //    List<string> spellPaths = new List<string>();
        //    foreach(string GUID in spellsGUID)
        //        spellPaths.Add(AssetDatabase.GUIDToAssetPath(GUID));
        //    _guardsSO = new List<GuardSO>();
        //    foreach(string path in spellPaths)
        //        _guardsSO.Add(AssetDatabase.LoadAssetAtPath(path, typeof(GuardSO)) as GuardSO);;
        //}

        public void StartBattle(List<LoadUndeadData> loadUndeadsData)
        {
            BattleData battleData = FindObjectOfType<BattleData>();
            battleData.InitializeBattleData(50, loadUndeadsData, _loadGuardsData);
            BattleEventStarted.Invoke(battleData); 
        }

        public void AddGuard(GuardSO guard)
        {
            _loadGuardsData.Add(new LoadGuardData(guard.UnitPrefab.GetComponentInChildren<SkinnedMeshRenderer>().sharedMesh,
            guard.UnitPrefab.GetComponentInChildren<SkinnedMeshRenderer>().sharedMaterials, guard.Health, guard.UnitSkills));
        }

        public void ClearGroup()
        {
            _loadGuardsData.Clear();
        }
    }
}
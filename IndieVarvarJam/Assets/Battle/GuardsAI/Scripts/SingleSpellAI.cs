using Battle.Spells;
using Battle.Controller;
using UnityEngine;
using System.Collections.Generic;


namespace Battle.Units.AI
{
    public class SingleSpellAI : MonoBehaviour
    {
        public void CastSpell(Spell spell, UnitsKeeper unitsKeeper)
        {
            List<Undead> undeads = unitsKeeper.Units<Undead>();
            int index;
            List<Guard> guards = unitsKeeper.Units<Guard>();
            Guard guard = null;
            switch(spell.DamageType)
            {
                case DamageType.Heal:
                
                foreach(Guard g in guards)
                {
                    if(g.CurHealth < g.MaxHealth)
                    {
                        guard = g;
                        break;
                    }
                }
                if(guard == null) return;
                guard.ChangeHealth(spell.Damage);
                break;

                case DamageType.Physical:
                if(undeads.Count == 0) return;
                index = (Random.Range(0, undeads.Count));
                undeads[index].ChangeHealth(-spell.Damage);
                break;

                case DamageType.Shield:
                index = (Random.Range(0, guards.Count));
                guards[index].AddShield(spell.Damage);
                break;
            }
        }
    }
}
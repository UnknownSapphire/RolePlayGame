using System;
using System.Collections.Generic;

namespace Character {

    public class Wizard: Character {
        public const int MaxMana = 1000;
        private int _mana = MaxMana;
        private HashSet<Spell> _spells;

        public int Mana {
            get => _mana;
            internal set => _mana = Math.Max(0, Math.Min(value, MaxMana));
        }
        
        public Wizard(string name, Gender gender, Race race, int age, int maxHealth):
            base(name, gender, race, age, maxHealth) {
                _spells = new HashSet<Spell>();
        }

        public bool KnowSpell(Spell spell) {
            return _spells.Contains(spell);
        }

        public void LearnSpell(Spell spell) {
            if (Exp >= 1500 && !KnowSpell(spell)) {
               _spells.Add(spell);
               Exp -= 1500;
            }
        }

        public void ForgetSpell(Spell spell) {
            _spells.Remove(spell);
        }

        public void UseSpell(Character target, Spell spell, int power) {
            if (KnowSpell(spell)) {
                int prevMana = Mana;
                spell.SpellCast(this, target, power);
                if (!ReferenceEquals(this, target) && prevMana != Mana) {
                    Exp += 100;
                }
            }
        }
        
        public override object Clone() {
            Wizard wizard = this;
            wizard._id = _nextId++;
            return wizard;
        }

        public override string ToString() {
            return base.ToString() + $", Mana: {Mana}";
        }
    }
}
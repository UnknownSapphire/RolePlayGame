using System;

namespace Character {

    public enum PowerSpell {
        Heal
    }
    
    public class Wizard: Character {
        public const int MaxMana = 1000;
        private int _mana = MaxMana;

        public int Mana {
            get => _mana;
            internal set => _mana = Math.Max(0, Math.Min(value, MaxMana));
        }
        
        public Wizard(string name, Gender gender, Race race, int age, int maxHealth):
            base(name, gender, race, age, maxHealth) {}

        public void SpellCast(PowerSpell spell, Character other, int power) {
            switch (spell) {
                case PowerSpell.Heal:
                    if (other.State != State.Dead) {
                        int hp = Math.Min(power, Math.Min(Mana / 2, MaxHealth - other.Health));
                        other.Health += hp;
                        Mana -= hp * 2;
                    }
                    break;
            }
        }

        public void SpellCast(Spell spell, Character other) {
            //if ((int) spell <= Mana) {
                //Mana -= (int) spell;
            //}
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
using System;

namespace Character {
    public class AddHealth: Spell {
        AddHealth(bool haveVerbalComponent, bool haveMotorComponent):
            base(2, haveVerbalComponent, haveMotorComponent) {}

        public override void SpellCast(ref Wizard w, ref Character chr, int power = 0) {
            if (CanSpell(ref w, _minMana, _haveVerbalComponent, _haveMotorComponent) && chr.State == State.Sick) {
                int hp = Math.Min(power, Math.Min(w.Mana / 2, chr.MaxHealth - chr.Health));
                chr.Health += hp;
                w.Mana -= hp * 2;
            }
        }
    }
}
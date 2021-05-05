using System;

namespace Character {
    public class AddHealth: Spell {
        AddHealth(bool haveVerbalComponent, bool haveMotorComponent):
            base(2, haveVerbalComponent, haveMotorComponent) {}

        public override void SpellCast(object person1, object person2, int power = 0) {
            if (!(person1 is Wizard w) || !(person2 is Wizard) && !(person2 is Character))  return;
            Character chr = (Character) person2;
            if (CanSpell(w, _minMana, _haveVerbalComponent, _haveMotorComponent) && chr.State == State.Sick) {
                int hp = Math.Min(power, Math.Min(w.Mana / 2, chr.MaxHealth - chr.Health));
                chr.Health += hp;
                w.Mana -= hp * 2;
            }
        }

        public override void SpellCast(object person, int power) {
            SpellCast(person, person, power);
        }
    }
}
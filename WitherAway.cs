using System;


namespace Character {
    public class WitherAway : Spell {
        public WitherAway(bool haveVerbalComponent, bool haveMotorComponent) :
                          base(85, haveVerbalComponent, haveMotorComponent) {}

        public override void SpellCast(object person1, object person2, int power = 0) {
            if (!(person1 is Wizard w) || !(person2 is Wizard) && !(person2 is Character)) return;
            Character chr = (Character) person2;
            if (!ReferenceEquals(w, chr) && chr.State == State.Paralyzed 
                && CanSpell(w, _minMana, _haveVerbalComponent, _haveMotorComponent) 
                ) {
                chr.Health = 1;
                chr.State = State.Weakened;
            }
        }

        public override void SpellCast(object person, int power) {}
    }
}
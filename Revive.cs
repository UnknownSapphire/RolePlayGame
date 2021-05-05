namespace Character {
    public class Revive: Spell {
        public Revive(bool haveVerbalComponent, bool haveMotorComponent) :
                    base (150, haveVerbalComponent, haveMotorComponent) {}

        public override void SpellCast(object person1, object person2, int power = 0) {
            if (!(person1 is Wizard w) || !(person2 is Wizard) && !(person2 is Character)) return;
            Character chr = (Character) person2;
            if (CanSpell(w, _minMana, _haveVerbalComponent, _haveMotorComponent) && chr.State == State.Dead) {
                w.Mana -= _minMana;
                chr.Health = 1;
                chr.State = State.Weakened;
            }
        }

        public override void SpellCast(object person, int power) {}
    }
}
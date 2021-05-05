namespace Character {
    public class Revive: Spell {
        public Revive(bool haveVerbalComponent, bool haveMotorComponent) :
                    base (150, haveVerbalComponent, haveMotorComponent) {}

        public override void SpellCast(ref Wizard w, ref Character chr, int power = 0) {
            if (CanSpell(ref w, _minMana, _haveVerbalComponent, _haveMotorComponent) && chr.State == State.Dead) {
                w.Mana -= _minMana;
                chr.Health = 1;
                chr.State = State.Weakened;
            }
        }
    }
}
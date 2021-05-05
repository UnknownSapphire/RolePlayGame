namespace Character {
    public class WitherAway : Spell {
        public WitherAway(bool haveVerbalComponent, bool haveMotorComponent) :
                          base(85, haveVerbalComponent, haveMotorComponent) {}

        public override void SpellCast(ref Wizard w, ref Character chr, int seconds = 0) {
            if (CanSpell(ref w, _minMana, _haveVerbalComponent, _haveMotorComponent) && chr.State == State.Paralyzed) {
                chr.Health = 1;
                chr.State = State.Weakened;
            }
        }             
    }
}
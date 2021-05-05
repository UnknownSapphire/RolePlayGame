namespace Character {
    public class Cure: Spell {

        public Cure(bool haveVerbalComponent, bool haveMotorComponent) :
                    base(20, haveVerbalComponent, haveMotorComponent) {}

        public override void SpellCast(ref Wizard w, ref Character chr, int power = 0) {
            if (CanSpell(ref w, _minMana, _haveVerbalComponent, _haveMotorComponent) && chr.State == State.Poisoned) {
                w.Mana -= _minMana;
                chr.State = chr.Health <= 0.2 * chr.MaxHealth ? State.Weakened : State.Normal;
            }
        }
    }
}
namespace Character {
    public class Antidote: Spell {
        public Antidote(bool haveVerbalComponent, bool haveMotorComponent) :
                        base (30, haveVerbalComponent, haveMotorComponent) {}

        public override void SpellCast(ref Wizard w, ref Character chr, int power = 0) {
            if (CanSpell(ref w, _minMana, _haveVerbalComponent, _haveMotorComponent) && chr.State != State.Dead) {
                w.Mana -= _minMana;
                chr.State = chr.Health <= 0.2 * chr.MaxHealth ? State.Weakened : State.Normal;
            }
        }
    }
}
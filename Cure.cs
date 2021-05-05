namespace Character {
    public class Cure: Spell {

        public Cure(bool haveVerbalComponent, bool haveMotorComponent) :
                    base(20, haveVerbalComponent, haveMotorComponent) {}

        public override void SpellCast(object person1, object person2, int power = 0) {
            if (person1 is Wizard w && person2 is Character chr && chr.State == State.Poisoned
                && CanSpell(w, _minMana, _haveVerbalComponent, _haveMotorComponent)) {
                w.Mana -= _minMana;
                chr.State = chr.Health <= 0.2 * chr.MaxHealth ? State.Weakened : State.Normal;
            }
        }

        public override void SpellCast(object person, int power) {
            SpellCast(person, person, power);
        }
    }
}
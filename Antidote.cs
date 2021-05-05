namespace Character {
    public class Antidote: Spell {
        public Antidote(bool haveVerbalComponent, bool haveMotorComponent) :
                        base (30, haveVerbalComponent, haveMotorComponent) {}

        public override void SpellCast(object person1, object person2, int power = 0) {
            if (!(person1 is Wizard w) || !(person2 is Wizard) && !(person2 is Character)) return;
            Character chr = (Character) person2;
            if (CanSpell(w, _minMana, _haveVerbalComponent, _haveMotorComponent) && chr.State != State.Dead) {
                w.Mana -= _minMana;
                chr.State = chr.Health <= 0.2 * chr.MaxHealth ? State.Weakened : State.Normal;
            }
        }
        public override void SpellCast(object person, int power) {
            SpellCast(person, person, power);
        }
    }
}
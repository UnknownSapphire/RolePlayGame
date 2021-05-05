namespace Character {
    public abstract class Spell: IMagic {
        protected int _minMana;
        protected bool _haveVerbalComponent;
        protected bool _haveMotorComponent;

        public Spell(int minMana, bool haveVerbalComponent, bool haveMotorComponent) {
            _minMana = minMana;
            _haveVerbalComponent = haveVerbalComponent;
            _haveMotorComponent = haveMotorComponent;
        }

        public abstract void SpellCast(object person1, object person2, int power = 0);

        public abstract void SpellCast(object person, int power);

        protected bool CanSpell(Wizard w, int minMana, bool haveVerbalComponent, bool haveMotorComponent) {
            return w.Mana >= minMana && w.State != State.Dead &&
                   (w.CanMove || !haveMotorComponent) && (w.CanTalk || !haveVerbalComponent);
        }

        
        
    }
}
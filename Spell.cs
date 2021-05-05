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

        public abstract void SpellCast(ref Wizard w, ref Character chr, int power = 0);

        protected bool CanSpell(ref Wizard w, int minMana, bool haveVerbalComponent, bool haveMotorComponent) {
            return w.Mana >= minMana && w.State != State.Dead &&
                   (w.CanMove || !haveMotorComponent) && (w.CanTalk || !haveVerbalComponent);
        }

        
        
    }
}
namespace Character {
    public abstract class Artifact: IMagic {
        protected int _power;
        protected bool _isRenewable;

        public Artifact(int power, bool isRenewable) {
            _power = power;
            _isRenewable = isRenewable;
        }
        
        public abstract void SpellCast(object person1, object person2, int power = 0);
        public abstract void SpellCast(object person, int power) ;
    }
}
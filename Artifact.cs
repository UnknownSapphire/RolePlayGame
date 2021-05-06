namespace Character {
    public enum BottleSize {
        Small = 10,
        Medium = 25,
        Big = 50
    }
    public abstract class Artifact: IMagic {
        protected int _power;
        public bool IsRenewable { get; }

        public int Power => _power;
        public Artifact(int power, bool isRenewable) {
            _power = power;
            IsRenewable = isRenewable;
        }
        
        public abstract void SpellCast(object person1, object person2, int power = 0);
        public abstract void SpellCast(object person, int power);
    }
}
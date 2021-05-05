namespace Character {
    public class DeadWaterBottle: Artifact {
        private BottleSize _bottleSize;
        public DeadWaterBottle(int power, BottleSize bottleSize) : base(power, false) {
            _bottleSize = bottleSize;
        }

        public override void SpellCast(object person1, object person2, int power = 0) {
            if (ReferenceEquals(person1, person2) && person1 is Wizard w) {
                w.Mana += (int) _bottleSize;
            }
        }

        public override void SpellCast(object person, int power) {}
    }
}
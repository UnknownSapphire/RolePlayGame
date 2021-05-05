namespace Character {
    public class DeadWaterBottle: Artifact {
        private BottleSize _bottleSize;
        public DeadWaterBottle(int power, BottleSize bottleSize) : base(power, false) {
            _bottleSize = bottleSize;
        }

        public override void SpellCast(object person1, object person2, int power = 0) {
            if (!ReferenceEquals(person1, person2) || !(person1 is Wizard w) || !(person2 is Wizard)
                && !(person2 is Character)) return;
            Character chr = (Character) person2;
            w.Mana += (int) _bottleSize;
            // delete from inventory
        }

        public override void SpellCast(object person, int power) {}
    }
}
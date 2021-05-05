namespace Character {
    public class LightningWand: Artifact {
        public const int MaxPower = 450;
        public LightningWand(int power) : base(power, true) {}

        public override void SpellCast(object person1, object person2, int power = 0) {
            if (!ReferenceEquals(person1, person2) && person1 is Character 
                && person2 is Character && _power >= power) {
                //threads
            }
        }

        public override void SpellCast(object person, int power) {
            
        }
    }
}
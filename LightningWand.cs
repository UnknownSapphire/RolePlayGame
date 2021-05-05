namespace Character {
    public class LightningWand: Artifact {
        public const int MaxPower = 450;
        public LightningWand(int power) : base(power, true) {}

        public override void SpellCast(object person1, object person2, int power) {
            if (!ReferenceEquals(person1, person2) && _power >= power) {
                
            }
        }

        public override void SpellCast(object person, int power) {
            
        }
    }
}
namespace Character {
    public class PoisonousSaliva : Artifact {
        public const int MaxPower = 450;
        
        PoisonousSaliva(int power) : base(power, true) {}

        public override void SpellCast(object person1, object person2, int power = 0) {
            if (!ReferenceEquals(person1, person2) && person1 is Character && person2 is Character chr
                 && (chr.State == State.Normal || chr.State == State.Weakened)) {
                chr.State = State.Poisoned;
                // threads
            }
        }

        public override void SpellCast(object person, int power) {}
    }
}
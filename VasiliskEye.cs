namespace Character {
    public class VasiliskEye: Artifact {
        public VasiliskEye(int power) : base(power, false) {}

        public override void SpellCast(object person1, object person2, int power = 0) {
            if (!ReferenceEquals(person1, person2) && person2 is Character chr && person1 is Character) {
                if (chr.State != State.Dead) {
                    chr.State = State.Paralyzed;
                }
            } 
        }

        public override void SpellCast(object person, int power) {}
    }
}
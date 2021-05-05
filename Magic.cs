namespace Character {
    public interface IMagic { 
        void SpellCast(object person1, object person2, int power);
        void SpellCast(object person, int power);
    }
}
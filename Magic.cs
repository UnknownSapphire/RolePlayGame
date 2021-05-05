namespace Character {
    public interface IMagic { 
        void SpellCast(ref Wizard w, ref Character chr, int power);
    }
}
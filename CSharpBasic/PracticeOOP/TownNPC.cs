namespace PracticeOOP
{
    abstract class TownNPC : NPC
    {
        protected TownNPC(string name, int hpMax) : base(name, hpMax) {
        }

        public abstract void Interaction(PC pc);
    }
}

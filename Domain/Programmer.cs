namespace Domain
{
    public class Programmer
    {
        public void Learn(Skill skill)
        {
            Skill = skill;
        }

        public Skill Skill { get; private set; }
    }
}
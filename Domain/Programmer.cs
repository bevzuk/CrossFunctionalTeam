namespace Domain
{
    public class Programmer
    {
        public void Learn(string skill)
        {
            Skill = skill;
        }

        public string Skill { get; private set; }
    }
}
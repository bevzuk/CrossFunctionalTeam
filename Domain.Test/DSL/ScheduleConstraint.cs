using NUnit.Framework.Constraints;

namespace Domain.Test.DSL
{
    internal class ScheduleConstraint : Constraint
    {
        private readonly string expected;
            
        public ScheduleConstraint(string expected) : base(expected)
        {
            this.expected = expected;
        }

        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            return new ConstraintResult(this, actual, AreEquivalent(actual));
        }

        //public override string Description => "Azazazaza";

        private bool AreEquivalent<TActual>(TActual actual)
        {
            if (actual.GetType() != typeof(Schedule)) return false;
            
            var actualSchedule = actual as Schedule;
            
            var trimmedExpected = expected.Replace(" ", "").Trim('\n');
            var trimmedSchedule = actualSchedule.AsString().Replace(" ", "").Trim('\n');
            
            return trimmedExpected == trimmedSchedule;
        }
    }
}
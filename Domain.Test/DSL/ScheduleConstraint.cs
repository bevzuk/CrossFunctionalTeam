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

        public override string Description => $"\"{expected}\"";

        private bool AreEquivalent<TActual>(TActual actual)
        {
            if (actual.GetType() != typeof(string)) return false;
            
            var actualSchedule = actual as string;
            
            var trimmedExpected = expected.Replace(" ", "").Trim('\n');
            var trimmedSchedule = actualSchedule.Replace(" ", "").Trim('\n');
            
            return trimmedExpected == trimmedSchedule;
        }
    }
}
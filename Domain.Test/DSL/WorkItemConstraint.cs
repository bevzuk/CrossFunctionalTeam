using NUnit.Framework.Constraints;

namespace Domain.Test.DSL
{
    internal class WorkItemConstraint : Constraint
    {
        private readonly string expected;

        public WorkItemConstraint(string expected) : base(expected)
        {
            this.expected = expected;
        }

        public override string Description => $"\"{expected}\"";

        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            return new ConstraintResult(this, actual, AreEquivalent(actual));
        }

        private bool AreEquivalent<TActual>(TActual actual)
        {
            if (!(actual is WorkItem)) return false;

            var actualWorkItem = actual as WorkItem;

            return $"{actualWorkItem.BacklogItem.Name}.{actualWorkItem.Component.Name}" == expected;
        }
    }
}